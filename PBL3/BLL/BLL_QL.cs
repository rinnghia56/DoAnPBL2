using PBL3.DAL;
using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BLL
{
    public class BLL_QL
    {
        private static BLL_QL _Instance;

        public static BLL_QL Instance
        {
            get
            {
                if (_Instance == null)
                {

                    _Instance = new BLL_QL();
                }
                return _Instance;
            }
        }
        public TaiKhoan getTkDangNhap(string username, string pw)
        {
            return Dal.Instance.getTaiKhoan(username, pw);
        }
    }
}
