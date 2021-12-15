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
    public partial class FrmThongKe : Form
    {
        public FrmThongKe()
        {
            InitializeComponent();
        }
        public void showListPhieuNhap(string ma, bool isAll)
        {
            DateTime tuNgay = dt_TimeTruoc.Value;
            DateTime denNgay = dt_TimeSau.Value;
            lvPhieuNhap.Items.Clear();
            foreach (PhieuNhap pn in BLL_ThongKe.Instance.getPhieuNhap_BLL(tuNgay, denNgay, ma, isAll))
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = pn.maPhieuNhap;
                listViewItem.SubItems.Add(BLL_ThongKe.Instance.getHotenByIDTK_BLL(pn.idtk)); 
                listViewItem.SubItems.Add(pn.ngayNhap.ToString());
                lvPhieuNhap.Items.Add(listViewItem);

            }
        }
        public void showListPhieuXuat(string ma,bool isAll)
        {
            DateTime tuNgay = dt_ThgianTruoc.Value;
            DateTime denNgay = dt_ThoiGianSau.Value;
            Console.WriteLine("meow");
            listviewKQ.Items.Clear();
            foreach(PhieuXuat pn in BLL_ThongKe.Instance.getPhieuXuat_BLL(tuNgay, denNgay, ma, isAll))
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = pn.maHD;
                listViewItem.SubItems.Add(BLL_ThongKe.Instance.getHotenByIDTK_BLL(pn.idTK));
                listViewItem.SubItems.Add(pn.ngayLap.ToString());
                listViewItem.SubItems.Add(pn.tongTien.ToString());
                listviewKQ.Items.Add(listViewItem);

            }
        }
        private void btnAll_Click(object sender, EventArgs e)
        {
            showListPhieuNhap("", true);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            showListPhieuXuat("", false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showListPhieuXuat("", true);
        }

        private void btnSearchMa_Click(object sender, EventArgs e)
        {
            showListPhieuXuat(txtMa.Text, false);
        }

        private void listviewKQ_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            showListPhieuNhap("", false);
        }

        private void txtSearchMa2_Click(object sender, EventArgs e)
        {
            showListPhieuNhap(txtMa2.Text, false);
        }

        private void mnuStripPhieuNhap_Opening(object sender, CancelEventArgs e)
        {

        }
        private void mnuStripPhieuNhap_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          
        }

        private void listviewKQ_Click(object sender, EventArgs e)
        {
        }

        private void mnuStripPhieuNhap_Click(object sender, EventArgs e)
        {
            if (lvPhieuNhap.Items.Count == 0) return;
            if (lvPhieuNhap.SelectedItems.Count == 0) return;
            FrmCTNhap frm = new FrmCTNhap(lvPhieuNhap.SelectedItems[0].Text.Trim());
            frm.ShowDialog();
        }

        private void mnustriptBan_Opening(object sender, CancelEventArgs e)
        {

        }

        private void mnustriptBan_Click(object sender, EventArgs e)
        {
            if (listviewKQ.Items.Count == 0) return;
            if (listviewKQ.SelectedItems.Count == 0) return;
            FrmCTBan frm = new FrmCTBan(listviewKQ.SelectedItems[0].Text.Trim());
            frm.ShowDialog();
        }
    }
}
