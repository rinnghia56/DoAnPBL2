using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.BLL;
using PBL3.DTO;

namespace PBL3.GUI.FrmCon
{
    
    public partial class FrmDanhMuc : Form
    {
        string madm = "";
        bool isFinish = false;
        private bool chk = false;
        public FrmDanhMuc()
        {
            InitializeComponent();
            ShowListDanhMuc();
        }
       
        public void ShowListDanhMuc()
        {
            foreach (DanhMuc sp in BLL_DanhMuc.Instance.getDanhMuc_BLL())
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = sp.maDm;
                listViewItem.SubItems.Add(sp.tenDM);
                lvDanhMuc.Items.Add(listViewItem);
            }
        }
        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
        }
        void getTextBox()
        {
            txtMa.Text = madm;
            /*txtTen.Text = tenSp;
            cbbDanhMuc.SelectedItem = Dm;
            txtSoLuong.Text = Sl.ToString();
            txtDonGia.Text = giaban.ToString();*/
        }
        void xoa()
        {
            txtMa.Text = string.Empty;
            txtTen.Text = string.Empty;  
        }
        bool isValid(DanhMuc dm)
        {
            if (txtMa.Text.Length < 1)
            {
                btnThem.PerformClick();
            }
            if ((txtTen.Text.Length < 1))
            {
                MessageBox.Show("Không được bỏ trống thông tin");
                return false;
            }
            return true;
        }
        private void add(DanhMuc dm)
        {
            if (isValid(dm))
            {
                foreach (ListViewItem i in lvDanhMuc.Items)
                {
                    if (i.SubItems[0].Text == dm.maDm)
                    {
                        MessageBox.Show("Danh Mục này đã có trong danh sách");
                        txtTen.Text = "";
                        return;
                    }
                }
                ListViewItem lvi = new ListViewItem(dm.maDm);
                lvi.SubItems.Add(dm.tenDM);
                lvDanhMuc.Items.Add(lvi);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            string dm = "";
            txtMa.Text = BLL_DanhMuc.Instance.CreateKeyBll(dm);
            if (isFinish || txtMa.Text.Length < 0)
            {
                getTextBox();
                isFinish = false;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            lvDanhMuc.Items.Clear();
            DanhMuc dm = new DanhMuc
            {
                maDm = txtMa.Text,
               tenDM = txtTen.Text,
            };
            BLL_DanhMuc.Instance.executeDBAddOrEdit(dm);
            ShowListDanhMuc();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            LinkedList<DanhMuc> ldm = new LinkedList<DanhMuc>();
            foreach(DanhMuc dm in BLL_DanhMuc.Instance.getDanhMuc_BLL())
            {
                if (dm.tenDM.Contains(txtUsername.Text))
                {
                    ldm.add(dm);
                }
                
            }
            lvDanhMuc.Items.Clear();
            foreach (DanhMuc sp in ldm)
            {

                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = sp.maDm;
                listViewItem.SubItems.Add(sp.tenDM);
                lvDanhMuc.Items.Add(listViewItem);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDanhMuc.SelectedItems.Count > 0)
            {
                string message = "Chắc không ông nội";
                string title = "Chú ý";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    for (int i = lvDanhMuc.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        ListViewItem itm = lvDanhMuc.SelectedItems[i];
                        lvDanhMuc.Items[itm.Index].Remove();
                    }
                }
            }
            else
            {
                MessageBox.Show(">>>>>>>>>");
            }
        }
    }
}
