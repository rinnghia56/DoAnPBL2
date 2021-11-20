using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.DTO;
using PBL3.GUI.FrmCon;

namespace PBL3.GUI
{
    public partial class FrmMain : Form
    {
        string idTK = "";
        string nameAccount="";   
        bool right=false; 
        
        private Form currentchildform;

        
        public FrmMain(TaiKhoan TK)
        {
            this.idTK = TK.idTK;
            this.nameAccount = TK.hoTen;
            this.right = TK.userRight;

            InitializeComponent();
        }


        //Chuyển màu button khi click
        private void clickButton(Panel pn1, Panel pn2, Panel pn3, Panel pn4)
        {
            if (pn1.Visible == false) pn1.Visible = true;
            pn2.Visible = false;
            pn3.Visible = false;
            pn4.Visible = false;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            pnChay.Visible = false;
            pnChay.Height = btnBan.Height;
            pnChay_Danhmuc.Visible = false;
            pnChay_Kho.Visible = false;
            pnChay_SP.Visible = false;
            pnbtnKho.Height = 50;

            //Set label theo tên của tài khoản đăng nhập
            lblTenTaiKhoan.Text = nameAccount;
            motrangcon(new FrmHome());
        }
       
        private void motrangcon(Form trangcon)
        {
            if (currentchildform != null)
            {
                currentchildform.Close();
            }
            currentchildform = trangcon;
            trangcon.TopLevel = false;
            trangcon.Dock = DockStyle.Fill;
            panelFormCon.Controls.Add(trangcon);
            panelFormCon.Tag = trangcon;
            trangcon.BringToFront();
            trangcon.Show();
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            clickButton(pnChay, pnChay_Danhmuc, pnChay_Kho, pnChay_SP);
            pnChay.Top = btnBan.Top;
            if (pnbtnKho.Height == 151) pnbtnKho.Height = 50;
            
            FrmBanHang frm = new FrmBanHang(idTK, nameAccount);
            motrangcon(frm);
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            
            clickButton(pnChay, pnChay_Danhmuc, pnChay_Kho, pnChay_SP);
            pnChay.Top = btnNhap.Top;
            if (pnbtnKho.Height == 151) pnbtnKho.Height = 50;
            FrmNhapHang frm = new FrmNhapHang(idTK,nameAccount);
           motrangcon(frm);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            clickButton(pnChay, pnChay_Danhmuc, pnChay_Kho, pnChay_SP);
            pnChay.Top = btnTaiKhoan.Top;
            if (pnbtnKho.Height == 151) pnbtnKho.Height = 50;
            motrangcon(new FrmTaiKhoan());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
          
            clickButton(pnChay, pnChay_Danhmuc, pnChay_Kho, pnChay_SP);
            pnChay.Top = btnThongKe.Top;
            if (pnbtnKho.Height == 151) pnbtnKho.Height = 50;
            motrangcon(new FrmThongKe());
        }

        

        private void btnKho_Click(object sender, EventArgs e)
        {
            clickButton(pnChay_Kho, pnChay, pnChay_Danhmuc, pnChay_SP);
            if (pnbtnKho.Height == 151) pnbtnKho.Height = 50;
            else pnbtnKho.Height = 151;
        }
       
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            clickButton(pnChay_SP, pnChay, pnChay_Danhmuc, pnChay_Kho);
            motrangcon(new FrmSanPham());
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            if (pnChay_Danhmuc.Visible == false) pnChay_Danhmuc.Visible = true;
            pnChay.Visible = false;
            pnChay_SP.Visible = false;
            pnChay_Kho.Visible = false;
            clickButton(pnChay_Danhmuc, pnChay, pnChay_SP, pnChay_Kho);

            motrangcon(new FrmDanhMuc());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            new FrmLogin().Show();
        }

        //Close and minimized form 
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

       
    }
}
