﻿using PBL3.BLL;
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
    public partial class FrmCTNhap : Form
    {
        string maPhieuNhap = "";
        public FrmCTNhap(string maPN)
        {
            InitializeComponent();
            maPhieuNhap = maPN;
        }

        private void FrmCTNhap_Load(object sender, EventArgs e)
        {

            foreach (CTPhieuNhap ctNhap in BLL_ThongKe.Instance.getCTPhieuNhapById_BLL(maPhieuNhap))
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = BLL_ThongKe.Instance.getTenSanPhamByID_BLL(ctNhap.maSP);
                listViewItem.SubItems.Add(ctNhap.soLuong.ToString());   
                listView1.Items.Add(listViewItem);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
