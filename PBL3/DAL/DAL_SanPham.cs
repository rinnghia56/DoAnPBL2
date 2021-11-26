using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.DTO;

namespace PBL3.DAL
{
    class DAL_SanPham
    {
        private static DAL_SanPham _Instance;
        public static DAL_SanPham Instance
        {
            get
            {
                if (_Instance == null)
                {
                    return _Instance = new DAL_SanPham();
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
        private DAL_SanPham()
        {

        }
        public LinkedList<SanPham> getAlllSanPham_DAL()
        {
            LinkedList<SanPham> spList = new LinkedList<SanPham>();
            string query = "SELECT * FROM SanPham";
            SanPham sp = new SanPham();
            foreach (DataRow dr in DBHelper.Instance.GetRecord(query).Rows)
            {
                sp = getSanPham(dr);
                spList.add(sp);
            }
            return spList;
        }
        public SanPham getSanPham(DataRow dr)
        {
            return new SanPham()
            {
                maSp = dr["MaSp"].ToString(),
                tenSP = dr["tenSp"].ToString(),
                maDM = dr["maDM"].ToString(),
                SLTon = int.Parse(dr["SLTon"].ToString()),
                giaBan = int.Parse(dr["giaBan"].ToString())

            };
        }
       
       
    }
}
