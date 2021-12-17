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
    public partial class FrmSanPham : Form
    {
        string masp = "";
        bool isFinish = false;
        public FrmSanPham()
        {
           
            InitializeComponent();
            ShowListSanPham("");
            setCBBDM();
            showListDM();

        }

        public void ShowListSanPham(String masp)
        {
            lvSanPham.Items.Clear();
            foreach(SanPham sp in BLL_SanPham.Instance.getSanPham_BLL())
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = sp.maSp;
                listViewItem.SubItems.Add(sp.tenSP);
                listViewItem.SubItems.Add(sp.maDM);
                listViewItem.SubItems.Add(sp.SLTon.ToString());
                listViewItem.SubItems.Add(sp.giaBan.ToString());
                lvSanPham.Items.Add(listViewItem);
            }
        }
        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            
            /*lbDanhMuc.SelectedIndex = -1;
            string[] str = {"Tên","Số lượng","Giá bán" };
            for(int i = 0; i < 3; i++)
            {
                ComboBoxItem Cbb = new ComboBoxItem(i + "", str[i]);
                cbbSort.Items.Add(Cbb);
            }*/



        }
        private void Show(string maSp, string tenSp)
        {
            ListViewItem listViewItem = new ListViewItem();
            

        }
        private void setCBBDM()
        {
            foreach(DanhMuc dm in BLL_DanhMuc.Instance.getDanhMuc_BLL())
            {
                cbbDanhMuc.Items.Add(new ComboBoxItem { valueMember = dm.maDm, displayMeber = dm.tenDM });
            }
            if (cbbDanhMuc.Items.Count > 0) cbbDanhMuc.SelectedIndex = 0;
        }
         void getTextBox()
        {
            txtMA.Text = masp;
            /*txtTen.Text = tenSp;
            cbbDanhMuc.SelectedItem = Dm;
            txtSoLuong.Text = Sl.ToString();
            txtDonGia.Text = giaban.ToString();*/
        }
        void xoa()
        {
            txtMA.Text = string.Empty;
            txtTen.Text = string.Empty;
            cbbDanhMuc.SelectedItem = string.Empty;
            txtSoLuong.Text = null;
            txtDonGia.Text = null;
        }
        bool isValid(SanPham sp)
        {
            int soLuong;
            if (txtMA.Text.Length < 1)
            {
                btnThem.PerformClick();
            }
            if ((cbbDanhMuc.SelectedIndex == -1) || txtSoLuong.Text.Length < 1)
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
        private void add(SanPham sp)
        {
            if (isValid(sp))
            {
                foreach (ListViewItem i in lvSanPham.Items)
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
                lvSanPham.Items.Add(lvi);
            }
        }
        private void tinhTong()
        {
            decimal tong = 0;
            for (int i = 0; i < lvSanPham.Items.Count; i++)
            {
                tong += Convert.ToDecimal(lvSanPham.Items[i].SubItems[4].Text);
            }

        }
        public void showListDM()
        {
            lbDanhMuc.Items.Clear();
            foreach (DanhMuc dm in BLL_DanhMuc.Instance.getTenDanhMuc_BLL())
            {
                ListBox lb = new ListBox();
                lb.Text = dm.tenDM;
              
                lbDanhMuc.Items.Add(dm);


            }
            lbDanhMuc.DisplayMember = "tenDM";
        }


        private void btn_them_Click(object sender, EventArgs e)
        {
            string sp = "";
            txtMA.Text = BLL_SanPham.Instance.CreateKey(sp);
            if (isFinish || txtMA.Text.Length < 0)
            {
                getTextBox();
                isFinish = false;
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string id = (cbbDanhMuc.SelectedItem as ComboBoxItem).valueMember;
            SanPham sp = new SanPham
            {
                maSp = txtMA.Text,
                tenSP = txtTen.Text,
                maDM = id,
                SLTon = int.Parse(txtSoLuong.Text),
                giaBan = decimal.Parse(txtDonGia.Text),
            };
            BLL_SanPham.Instance.executeDBAddOrEdit(sp);
            ShowListSanPham("");
        }
        

        private void btnAll_Click(object sender, EventArgs e)
        {
            ShowListSanPham("");
        }

        private void lbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            /*LinkedList<string> msspDel = new LinkedList<string>();
            foreach (ListViewItem i in lvSanPham.Items)
            {
                msspDel.add(i.SubItems[0].Text.ToString());
            }
            BLL_SanPham.Instance.DelBLL(msspDel);
            Show(((ComboBoxItem)cbbDanhMuc.SelectedItem).valueMember, txtSearch.Text);*/
            if(lvSanPham.SelectedItems.Count > 0)
            {
                string message = "Chắc không ông nội";
                string title = "Chú ý";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    for(int i = lvSanPham.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        ListViewItem itm = lvSanPham.SelectedItems[i];
                        lvSanPham.Items[itm.Index].Remove();
                    }
                }
            }
            else
            {
                MessageBox.Show(">>>>>>>>>");
            }

        }

        private void lbDanhMuc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string madm = (lbDanhMuc.SelectedItem as DanhMuc).maDm;
            Console.WriteLine(madm);
            lvSanPham.Items.Clear();
            foreach (SanPham sp in BLL_SanPham.Instance.getSPBYIDDMBLL(madm))
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = sp.maSp;
                listViewItem.SubItems.Add(sp.tenSP);
                listViewItem.SubItems.Add(sp.maDM);
                listViewItem.SubItems.Add(sp.SLTon.ToString());
                listViewItem.SubItems.Add(sp.giaBan.ToString());
                lvSanPham.Items.Add(listViewItem);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LinkedList<SanPham> lsp = new LinkedList<SanPham>();
            foreach (SanPham sp in BLL_SanPham.Instance.getSanPham_BLL())
            {
                if (sp.tenSP.Contains(txtSearch.Text))
                {
                    lsp.add(sp);
                }

            }
            lvSanPham.Items.Clear();
            foreach (SanPham sp in lsp)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = sp.maSp;
                listViewItem.SubItems.Add(sp.tenSP);
                listViewItem.SubItems.Add(sp.maDM);
                listViewItem.SubItems.Add(sp.SLTon.ToString());
                listViewItem.SubItems.Add(sp.giaBan.ToString());
                lvSanPham.Items.Add(listViewItem);
            }
        }

        private void lvSanPham_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lvSanPham.SelectedItems.Count > 0)
                {
                    String masp = lvSanPham.SelectedItems[0].SubItems[0].Text;
                    String ten = lvSanPham.SelectedItems[0].SubItems[1].Text;
                    String mam = lvSanPham.SelectedItems[0].SubItems[2].Text;
                    int solo = int.Parse(lvSanPham.SelectedItems[0].SubItems[3].Text);
                    decimal gia = decimal.Parse(lvSanPham.SelectedItems[0].SubItems[4].Text);
                    txtMA.Text = masp;
                    txtTen.Text = ten;
                    for(int i = 0; i < cbbDanhMuc.Items.Count; i++)
                    {
                        ComboBoxItem item = cbbDanhMuc.Items[i] as ComboBoxItem;
                        if(item.valueMember == mam)
                        {
                            cbbDanhMuc.SelectedIndex = i;
                            break;
                        }
                    }
                   
                   // cbbDanhMuc.SelectedItem = mam.ToString();
                    txtSoLuong.Text = solo.ToString();
                    txtDonGia.Text = gia.ToString();
                }
                //BLL_SanPham.Instance.();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }
        
    }
}
