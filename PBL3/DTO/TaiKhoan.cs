using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DTO
{
    public class TaiKhoan
    {
        public string idTK { get; set; }
        public string hoTen { get; set; }
        public string SDT { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool userRight { get; set; }
        public TaiKhoan() { }
        public TaiKhoan(string name, bool right)
        {
            this.hoTen = name;
            this.userRight = right;
        }
        public TaiKhoan(string id,string name, bool right)
        {
            this.idTK = id;
            this.hoTen = name;
            this.userRight = right;
        }
        public override string ToString()
        {
            return this.hoTen + " " + this.userRight;
        }

    }
}
