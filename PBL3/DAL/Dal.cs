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
            string tenTaiKhoan = i[1].ToString();
            bool right = Convert.ToBoolean(i[5].ToString());

            return new TaiKhoan(tenTaiKhoan, right);
        }
    }
}
