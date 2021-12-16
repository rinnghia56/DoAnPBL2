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
        public LinkedList<DanhMuc> getTenDanhMuc_DAL()
        {
            LinkedList<DanhMuc> ldm = new LinkedList<DanhMuc>();
            string query = "select * from DanhMuc";
            DanhMuc dm = new DanhMuc();
            foreach (DataRow dr in DBHelper.Instance.GetRecord(query).Rows)
            {
                dm = getTenDanhMuc(dr);
                ldm.add(dm);
                
            }
            return ldm;
        }

        private DanhMuc getTenDanhMuc(DataRow dr)
        {
            return new DanhMuc()
            {
                tenDM = dr["tenDm"].ToString(),
                maDm =dr["maDM"].ToString()
            };
        }
        public void deleteDM_DAL(string iddm)
        {
            LinkedList<DanhMuc> spList = new LinkedList<DanhMuc>();
            string query = "delete from DanhMuc where MaDm = '" + iddm +
                "'"; DBHelper.Instance.ExcuteDB(query);
        }
        // add 
        public void AddDM_DAL(DanhMuc dm)
        {
            string query = string.Format("Insert into DanhMuc values('{0}','{1}')",
                dm.maDm, dm.tenDM);
            DBHelper.Instance.ExcuteDB(query);
        }
        public void EditDM_DAL(DanhMuc dm)
        {
            string query = "update DanhMuc set " +
                "TenDM = '" + dm.tenDM + "'," + 
                "MaDM = '" + dm.maDm + "'" + "where MaDm ='" + dm.maDm + "'";
            DBHelper.Instance.ExcuteDB(query);
        }
    }
}
