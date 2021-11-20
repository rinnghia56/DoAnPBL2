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
    public partial class FrmNhapHang : Form
    {

        string maTK = "";
        string tenTK = "";
        bool isFinish=false ;

        public FrmNhapHang(string MaTK,string tenTK)
        {
            InitializeComponent();
            this.maTK = MaTK;
            this.tenTK = tenTK;
        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            ComboBoxItem cbb;
            LinkedList<SanPham> list = BLL_QL.Instance.getAllSP_BLL();
            LinkedNode<SanPham> cur = list.Head;
            while (cur != null)
            {
                SanPham sp = cur.item;
                cbb = new ComboBoxItem(sp.maSp,sp.tenSP);
                cbbSanPham.Items.Add(cbb);
                cur = cur.next;
            }
        }

        void setTextbox()
        {
            txtMaTK.Text = maTK;
            txtTenTK.Text = tenTK;
            txtMaPN.Text = BLL_QL.Instance.CreateKey("PN");
            txtTime.Text = DateTime.Now.ToString("dd/MM//yyyy HH:mm:ss");
        }
        void clear()
        {
            txtMaTK.Text=string.Empty;
            txtTenTK.Text = string.Empty;
            txtMaPN.Text = string.Empty;
            txtTime.Text = string.Empty;
            lvsanpham.Items.Clear();
            cbbSanPham.SelectedIndex = -1;
            txtSoLuong.Text= string.Empty; ;
        }

        private void btnTaoPhieuNhap_Click(object sender, EventArgs e)
        {
            if (isFinish || txtMaPN.Text.Length<2)
            {
                setTextbox();
                isFinish = false;
            }
            else
            {
                MessageBox.Show("Hãy lưu hoặc huỷ phiếu nhập");
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (lvsanpham.Items.Count == 0)
            {
                MessageBox.Show("Hay them san pham vao danh sach");
                return;
            }
            PhieuNhap pn = new PhieuNhap()
            {
                maPhieuNhap = txtMaPN.Text,
                idtk = txtMaTK.Text,
                ngayNhap = DateTime.Now

            };
            BLL_QL.Instance.createPhieuNhap(pn);

            for (int i=0;i<lvsanpham.Items.Count;i++)
            {
                CTPhieuNhap ct = new CTPhieuNhap()
                {
                    maPN = pn.maPhieuNhap,
                    maSP = lvsanpham.Items[i].SubItems[0].Text,
                    soLuong = Convert.ToInt32(lvsanpham.Items[i].SubItems[2].Text)
                };

                BLL_QL.Instance.creatCtPhieuNhap(ct);
                BLL_QL.Instance.nhapHang(ct);
            }
            isFinish = true;
            MessageBox.Show("Luu thanh cong");
            clear();

        }


        void addSP(string id,SanPham sp)
        {
            if (txtMaPN.Text.Length < 1)
            {
                btnTaoPhieuNhap.PerformClick();
            }
            if ((cbbSanPham.SelectedIndex == -1) || txtSoLuong.Text.Length < 1)
            {
                MessageBox.Show("Không được bỏ trống thông tin");
                return;
            }

            int soLuong;
            if (!Int32.TryParse(txtSoLuong.Text, out soLuong))
            {
                MessageBox.Show("Số lượng ko hợp lệ");
                return;
            }

            foreach (ListViewItem i in lvsanpham.Items)
            {
                if (i.SubItems[0].Text == id)
                {
                    MessageBox.Show("Sản phẩm này đã có trong danh sách, hãy cập nhật số lượng");
                    txtSoLuong.Text = "";
                    return;
                }
            }

            ListViewItem lvi = new ListViewItem(id);
            lvi.SubItems.Add(sp.tenSP);
            lvi.SubItems.Add(txtSoLuong.Text);
            lvsanpham.Items.Add(lvi);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = (cbbSanPham.SelectedItem as ComboBoxItem).valueMember;
            SanPham sp = BLL_QL.Instance.getSanPhamByID_BLL(id);

            addSP(id, sp);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = (cbbSanPham.SelectedItem as ComboBoxItem).valueMember;
            SanPham sp = BLL_QL.Instance.getSanPhamByID_BLL(id);
            bool check = false;
            if (lvsanpham.SelectedItems.Count == 0 || lvsanpham.SelectedItems.Count > 1)
            {
                MessageBox.Show("Chọn 1 sản phẩm cần cập nhật");
                return;
            }
            int soLuong;
            if (!Int32.TryParse(txtSoLuong.Text, out soLuong))
            {
                MessageBox.Show("Số lượng ko hợp lệ");
                txtSoLuong.Text = "";
                return;
            }

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
            }
            else
            {
                addSP(id, sp);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
          
        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem i in lvsanpham.SelectedItems)
            {
                lvsanpham.Items.Remove(i);
            }
            txtSoLuong.Text = "";
            cbbSanPham.SelectedIndex = -1;
        }

        private void lvsanpham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvsanpham.SelectedItems.Count == 0 || lvsanpham.SelectedItems.Count > 1) return;
            ListViewItem lvi = lvsanpham.SelectedItems[0];
            txtSoLuong.Text = lvi.SubItems[2].Text.Trim();
            string id= lvi.SubItems[0].Text;
            cbbSanPham.SelectedValue = cbbSanPham.FindString(id);
            
            foreach (ComboBoxItem cbi in cbbSanPham.Items)
            {
                if (cbi.valueMember.Contains(id))
                {
                    cbbSanPham.SelectedItem = cbi;
                    break;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
