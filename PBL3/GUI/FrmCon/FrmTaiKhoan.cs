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
    public partial class FrmTaiKhoan : Form
    {
        string idtk = "";
        private bool isFinish;

        public FrmTaiKhoan()
        {
            InitializeComponent();
            ShowListTaiKhoan("");
        }
        public void ShowListTaiKhoan(String idtk)
        {
            foreach (TaiKhoan sp in BLL_TaiKhoan.Instance.getTaiKhoan_BLL(idtk))
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = sp.idTK;
                listViewItem.SubItems.Add(sp.hoTen);
                listViewItem.SubItems.Add(sp.SDT);
                listViewItem.SubItems.Add(sp.username);
                listViewItem.SubItems.Add(sp.userRight.ToString());
                lvTaiKhoan.Items.Add(listViewItem);
            }
        }
        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
           
            
        }
        void getTextBox()
        {
            txtMa.Text = idtk;
            /*txtTen.Text = tenSp;
            cbbDanhMuc.SelectedItem = Dm;
            txtSoLuong.Text = Sl.ToString();
            txtDonGia.Text = giaban.ToString();*/
        }
        void xoa()
        {
            txtMa.Text = string.Empty;
            txtName.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtpass2.Text = string.Empty;
            txtUsername.Text = string.Empty;
            groupBox1.Text = string.Empty;
            
        }
        bool isValid(TaiKhoan tk)
        {
            if (txtMa.Text.Length < 1)
            {
                btnThem.PerformClick();
            }
            if ((txtName.Text.Length < 1) || txtUsername.Text.Length < 1)
            {
                MessageBox.Show("Không được bỏ trống thông tin");
                return false;
            }
            if (groupBox1.Enabled)
            {
                MessageBox.Show("hãy chọn");
                return false;
            }
            return true;
        }
        private void add(TaiKhoan TK)
        {
            if (isValid(TK))
            {
                foreach (ListViewItem i in lvTaiKhoan.Items)
                {
                    if (i.SubItems[0].Text == TK.idTK)
                    {
                        MessageBox.Show("user này đã có trong danh sách, hãy cập nhật số lượng");
                        txtUsername.Text = "";
                        return;
                    }
                }
                ListViewItem lvi = new ListViewItem(TK.idTK);
                lvi.SubItems.Add(TK.hoTen);
                lvi.SubItems.Add(txtUsername.Text);
                lvi.SubItems.Add(txtPass.Text);
                lvi.SubItems.Add(txtpass2.Text);
                lvi.SubItems.Add(txtSDT.Text);
                lvTaiKhoan.Items.Add(lvi);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tk = "";
            txtMa.Text = BLL_TaiKhoan.Instance.CreateKeyTK(tk);
            if (isFinish || txtMa.Text.Length < 0)
            {
                getTextBox();
                isFinish = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            /*string id = (cbbDanhMuc.SelectedItem as ComboBoxItem).valueMember;*/
            TaiKhoan tk = new TaiKhoan
            {
                idTK = txtMa.Text,
                hoTen = txtName.Text,
                SDT = txtSDT.Text,
                username = txtUsername.Text,
                password = txtPass.Text,
                userRight = groupBox1.Enabled
            };
            BLL_TaiKhoan.Instance.executeDBAddOrEdit(tk);
            ShowListTaiKhoan("");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count > 0)
            {
                string message = "Chắc không ông nội";
                string title = "Chú ý";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    for (int i = lvTaiKhoan.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        ListViewItem itm = lvTaiKhoan.SelectedItems[i];
                        lvTaiKhoan.Items[itm.Index].Remove();
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
