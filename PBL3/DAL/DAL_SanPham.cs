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
                maSp = dr["MaSP"].ToString(),
                tenSP = dr["TenSP"].ToString(),
                maDM = dr["MaDM"].ToString(),
                SLTon = int.Parse(dr["SLTon"].ToString()),
                giaBan = decimal.Parse(dr["GiaBan"].ToString())

            };
        }
        
        public void deleteSP_DAL(string idSp)
        {
            LinkedList<SanPham> spList = new LinkedList<SanPham>();
            string query = "delete from SanPham where MaSp = '" + idSp +
                "'"; DBHelper.Instance.ExcuteDB(query);
        }
        // add 
        public void AddSP_DAL(SanPham sp)
        {
            string query = string.Format("Insert into SanPham values('{0}','{1}','{2}','{3}','{4}')",
                sp.maSp, sp.tenSP, sp.maDM, sp.SLTon, (sp.giaBan));
            DBHelper.Instance.ExcuteDB(query);
        }
        public void EditSP_DAL(SanPham sp)
        {
            string query = "update SanPham set TenSP = '" +sp.tenSP+
                "'," +
                "MaDM = '" + sp.maDM +
                "'," +
                "SLTon = " + sp.SLTon + "," +
                "GiaBan = " + sp.giaBan +
                " where MaSp ='" + sp.maSp +
                "'";
            DBHelper.Instance.ExcuteDB(query);
            
        }
        public LinkedList<SanPham> getSPbyIDDM(string madm)
        {
            LinkedList<SanPham> spList = new LinkedList<SanPham>();
            string query = string.Format(" select * from SanPham where maDM = '{0}'", madm);
            SanPham sp = new SanPham();
            foreach (DataRow dr in DBHelper.Instance.GetRecord(query).Rows)
            {
                sp = getSanPham(dr);

                spList.add(sp);
            }
            return spList;

        }




    }
}
