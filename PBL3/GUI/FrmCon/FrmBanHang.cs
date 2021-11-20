using PBL3.BLL;
using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.GUI.FrmCon
{
    public partial class FrmBanHang : Form
    {
        string maTK = "";
        string tenTK = "";
        bool isFinish = false;
        public FrmBanHang()
        {
            InitializeComponent();
        }
        public FrmBanHang(string MaTK, string tenTK)
        {
            InitializeComponent();
            this.maTK = MaTK;
            this.tenTK = tenTK;
        }
        void setTextbox()
        {
            txtMaTK.Text = maTK;
            txtTenTK.Text = tenTK;
            txtMaHd.Text = BLL_QL.Instance.CreateKey("HD");
            txtTime.Text = DateTime.Now.ToString("dd/MM//yyyy HH:mm:ss");
        }
        void clear()
        {
            txtMaTK.Text = string.Empty;
            txtTenTK.Text = string.Empty;
            txtMaHd.Text = string.Empty;
            txtTime.Text = string.Empty;
            lvsanpham.Items.Clear();
            cbbSanPham.SelectedIndex = -1;
            txtSoLuong.Text = string.Empty; ;
            txtTong.Text = "";
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (isFinish || txtMaHd.Text.Length < 2)
            {
                setTextbox();
                isFinish = false;
            }
            else
            {
                MessageBox.Show("Hãy lưu hoặc huỷ hoá đơn");
            }
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            ComboBoxItem cbb;
            LinkedList<SanPham> list = BLL_QL.Instance.getAllSP_BLL();
            LinkedNode<SanPham> cur = list.Head;
            while (cur != null)
            {
                SanPham sp = cur.item;
                cbb = new ComboBoxItem(sp.maSp, sp.tenSP);
                cbbSanPham.Items.Add(cbb);
                cur = cur.next;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (lvsanpham.Items.Count == 0)
            {
                MessageBox.Show("Hay them san pham vao danh sach");
                return;
            }
            PhieuXuat hd = new PhieuXuat()
            {
                maHD = txtMaHd.Text,
                idTK = txtMaTK.Text,
                ngayLap = DateTime.Now,
                tongTien = Convert.ToDecimal(txtTong.Text)
            };
            BLL_QL.Instance.createHD(hd);


            for (int i = 0; i < lvsanpham.Items.Count; i++)
            {
                CTPhieuXuat ct = new CTPhieuXuat()
                {
                    maHD = txtMaHd.Text,
                    maSp = lvsanpham.Items[i].SubItems[0].Text,
                    soLuong = Convert.ToInt32(lvsanpham.Items[i].SubItems[2].Text),
                    thanhTien = Convert.ToDecimal(txtTong.Text)
                };
                BLL_QL.Instance.createChiTietHD(ct);
                BLL_QL.Instance.banHang(ct);


            }

            /*
            for (int i = 0; i < lvsanpham.Items.Count; i++)
            {
                CTPhieuNhap ct = new CTPhieuNhap()
                {
                    maPN = pn.maPhieuNhap,
                    maSP = lvsanpham.Items[i].SubItems[0].Text,
                    soLuong = Convert.ToInt32(lvsanpham.Items[i].SubItems[2].Text)
                };

                BLL_QL.Instance.creatCtPhieuNhap(ct);
            }*/
            isFinish = true;
            MessageBox.Show("Luu thanh cong");
            clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = (cbbSanPham.SelectedItem as ComboBoxItem).valueMember;
            SanPham sp = BLL_QL.Instance.getSanPhamByID_BLL(id);

            addSP(sp);
        }

        private void addSP(SanPham sp)
        {
            if (isValid(sp))
            {
                foreach (ListViewItem i in lvsanpham.Items)
                {
                    if (i.SubItems[0].Text == sp.maSp)
                    {
                        MessageBox.Show("Sản phẩm này đã có trong danh sách, hãy cập nhật số lượng");
                        txtSoLuong.Text = "";
                        return;
                    }
                }

                ListViewItem lvi = new ListViewItem(sp.maSp);
                lvi.SubItems.Add(sp.tenSP);
                lvi.SubItems.Add(txtSoLuong.Text);
                
                string giaBan = string.Format("{0:N}", sp.giaBan);
                lvi.SubItems.Add(giaBan);

                
                int sl = Convert.ToInt32(txtSoLuong.Text);
                decimal thanhTien = sl * sp.giaBan;
                String thanhTienText = string.Format("{0:N}", Math.Round(thanhTien, 2));
                lvi.SubItems.Add(thanhTienText);
                lvsanpham.Items.Add(lvi);
                
                tinhTong();
            }
           
        }

        private void tinhTong()
        {
            decimal tong = 0;
            for (int i = 0; i < lvsanpham.Items.Count; i++)
            {
                tong += Convert.ToDecimal(lvsanpham.Items[i].SubItems[4].Text);
            }
                txtTong.Text = string.Format("{0:N}", Math.Round(tong, 2));

        }

        bool isValid(SanPham sp)
        {
            int soLuong;
            if (txtMaHd.Text.Length < 1)
            {
                btnTao.PerformClick();
            }
            if ((cbbSanPham.SelectedIndex == -1) || txtSoLuong.Text.Length < 1)
            {
                MessageBox.Show("Không được bỏ trống thông tin");
                return false;
            }
            if (!Int32.TryParse(txtSoLuong.Text, out soLuong))
            {
                MessageBox.Show("Số lượng ko hợp lệ");
                return false;
            }
            if (sp.SLTon < soLuong)
            {
                MessageBox.Show("Chỉ còn lại " + sp.SLTon + " sản phẩm này trong kho");
                return false;
            }
            return true;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool check=false;
            string id = (cbbSanPham.SelectedItem as ComboBoxItem).valueMember;
            SanPham sp = BLL_QL.Instance.getSanPhamByID_BLL(id);
            if (isValid(sp))
            {
                foreach (ListViewItem i in lvsanpham.Items)
                {
                    if (i.SubItems[0].Text == id)
                    {
                        check = true; //da co san pham trong list
                        break;
                    }
                }
                if (check)
                {
                    lvsanpham.SelectedItems[0].SubItems[2].Text = txtSoLuong.Text;
                    decimal thanhtien = Convert.ToDecimal(lvsanpham.SelectedItems[0].SubItems[3].Text);
                    int soLuong = Convert.ToInt32(lvsanpham.SelectedItems[0].SubItems[2].Text);
                    thanhtien = thanhtien * soLuong;
                    lvsanpham.SelectedItems[0].SubItems[4].Text = string.Format("{0:N}", Math.Round(thanhtien, 2));
                }
                else
                {
                    addSP(sp);
                }
                tinhTong();

            }
        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in lvsanpham.SelectedItems)
            {
               
                lvsanpham.Items.Remove(i);
            }
            tinhTong();
            txtSoLuong.Text = "";
            cbbSanPham.SelectedIndex = -1;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void lvsanpham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvsanpham.SelectedItems.Count == 0 || lvsanpham.SelectedItems.Count > 1) return;
            ListViewItem lvi = lvsanpham.SelectedItems[0];
            txtSoLuong.Text = lvi.SubItems[2].Text.Trim();
            string id = lvi.SubItems[0].Text;
            cbbSanPham.SelectedValue = cbbSanPham.FindString(id);

            foreach (ComboBoxItem cbi in cbbSanPham.Items)
            {
                if (cbi.valueMember==id)
                {
                    cbbSanPham.SelectedItem = cbi;
                    break;
                }
            }
        }
    }
}
