using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.DTO;

namespace PBL3.DAL
{
    class DAL_DanhMuc
    {
        private static DAL_DanhMuc _Instance;
        public static DAL_DanhMuc Instance
        {
            get
            {
                if (_Instance == null)
                {
                    return _Instance = new DAL_DanhMuc();
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
        public LinkedList<DanhMuc> getAllDanhMuc_DAL()
        {
            LinkedList<DanhMuc> ldm = new LinkedList<DanhMuc>();
            string query = "select * from DanhMuc";
            DanhMuc dm = new DanhMuc();
            foreach (DataRow dr in DBHelper.Instance.GetRecord(query).Rows)
            {
                dm = getDanhMuc(dr);
                ldm.add(dm);

            }
            return ldm;
        }

        private DanhMuc getDanhMuc(DataRow dr)
        {
            return new DanhMuc()
            {
                maDm = dr["maDm"].ToString(),
                tenDM = dr["tenDm"].ToString()
            };
        }
    }
}
