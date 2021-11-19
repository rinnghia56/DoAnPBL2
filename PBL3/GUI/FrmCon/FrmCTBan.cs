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
    public partial class FrmCTBan : Form
    {
        string maPhieuXuat;
        public FrmCTBan(String ma)
        {
            InitializeComponent();
            maPhieuXuat = ma;
        }

        private void FormCTBan_Load(object sender, EventArgs e)
        {
            foreach (CTPhieuXuat ctXuat in BLL_ThongKe.Instance.getCTPhieuXuatById_BLL(maPhieuXuat))
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = BLL_ThongKe.Instance.getTenSanPhamByID_BLL(ctXuat.maSp);
                listViewItem.SubItems.Add(ctXuat.soLuong.ToString());
                listViewItem.SubItems.Add(ctXuat.thanhTien.ToString());
                listView1.Items.Add(listViewItem);

            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
