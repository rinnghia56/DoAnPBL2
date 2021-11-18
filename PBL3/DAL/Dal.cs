using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DAL
{
    public class Dal
    {
        private static Dal _Instance;
        public static Dal Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Dal();
                }
                return _Instance;
            }
        }
        private Dal(){}

        public TaiKhoan getTaiKhoan(string username, string password)
        {
            
            TaiKhoan tk= null;
            string query = "select * from taikhoan where username  = '" + username +
                                               "' and password = '" + password + "'";

            foreach (DataRow i in DBHelper.Instance.GetRecord(query).Rows)
            {
                tk=getValidAccount(i);
            }
            return tk;
        }
        public TaiKhoan getValidAccount(DataRow i)             //Sử dụng để lấy SV từ hàm getRecord trong DBHelper
        {
            string id = i[0].ToString();
            string tenTaiKhoan = i[1].ToString();
            bool right = Convert.ToBoolean(i[5].ToString());
            return new TaiKhoan(id,tenTaiKhoan, right);
        }

        public SanPham getSanPham(DataRow dr)
        {
            return new SanPham()
            {
                maSp = dr[0].ToString().Trim(),
                tenSP= dr[1].ToString(),
                maDM = dr[2].ToString(),
                SLTon=Convert.ToInt32(dr[3].ToString()) ,
                giaBan=Convert.ToDecimal(dr[4].ToString())
            };
        }

        public LinkedList<SanPham> getAllSP_DAL()
        {
            LinkedList<SanPham> list = new LinkedList<SanPham>();
            string query = "select * from sanpham";
            SanPham sp = null;
            foreach (DataRow dr in DBHelper.Instance.GetRecord(query).Rows)
            {
                sp = getSanPham(dr);
                list.add(sp);
            }
            return list;
        }

        internal SanPham getSanPhamByID_DAL(string id)
        {
            string query = "select * from sanpham where masp = '"+id+"'";
            DataRow dr=DBHelper.Instance.GetRecord(query).Rows[0];
            SanPham sp = getSanPham(dr);
            return sp;
        }
    }
}
