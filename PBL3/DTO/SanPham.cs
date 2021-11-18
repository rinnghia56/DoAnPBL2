using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DTO
{
    public class SanPham
    {
        public string maSp{ get; set; }
        public string tenSP { get; set; }
        public string maDM { get; set; }
        public int SLTon { get; set; }
        public decimal giaBan { get; set; }

        public override string ToString()
        {
            return maSp + " - " + tenSP;
        }
    }
}
