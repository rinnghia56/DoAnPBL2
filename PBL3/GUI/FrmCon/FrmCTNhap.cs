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
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
