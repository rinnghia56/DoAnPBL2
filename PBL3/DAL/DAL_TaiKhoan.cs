using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.DTO;

namespace PBL3.DAL
{
    class DAL_TaiKhoan
    {
        private static DAL_TaiKhoan _Instance;
        public static DAL_TaiKhoan Instance
        {
            get
            {
                if (_Instance == null)
                {
                    return _Instance = new DAL_TaiKhoan();
                }
                else
                {
                    return _Instance;
                }
            }
            set
            {

            }
        }
        public LinkedList<TaiKhoan> getAllTaiKhoan_DAL()
        {
            LinkedList<TaiKhoan> ltk = new LinkedList<TaiKhoan>();
            string query = "select * from TaiKhoan";
            TaiKhoan tk = new TaiKhoan();
            foreach (DataRow dr in DBHelper.Instance.GetRecord(query).Rows)
            {
                tk = getTaiKhoan(dr);
                ltk.add(tk);
            }
            return ltk;
        }

        private TaiKhoan getTaiKhoan(DataRow dr)
        {
            return new TaiKhoan()
            {
                idTK = dr["idTK"].ToString(),
                hoTen = dr["hoTen"].ToString(),
                SDT = dr["SDT"].ToString(),
                username = dr["username"].ToString(),
                password = dr["password"].ToString()
            };
        }
    }
}
