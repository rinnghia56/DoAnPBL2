using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.DAL;
using PBL3.DTO;

namespace PBL3.BLL
{
    class BLL_SanPham
    {
        private static BLL_SanPham _Instance;
        public static BLL_SanPham Instance
        {
            get
            {
                if ( _Instance == null)
                {
                    return _Instance = new BLL_SanPham();
                }
                else
                {
                    return _Instance;
                }
            }
        }
        private BLL_SanPham()
        {

        }
        public LinkedList<SanPham> getSanPham_BLL()
        {
            return DAL_SanPham.Instance.getAlllSanPham_DAL();
        }
        // del 
        public void DelBLL(LinkedList<string> sp )
        {
            foreach(string i in sp)
            {
                DAL_SanPham.Instance.deleteSP_DAL(i);
            }
        }
        public string CreateKey(string tiento)
        {
            string t;
            t = String.Format("SP");
            
            return t;
        }
        public string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
        // add or edit 
        public void executeDBAddOrEdit(SanPham sp)
        {
            if(GetSPBYID(sp.maSp) !=null) //svInput ton tai trong DB-> edit
            {
                DAL_SanPham.Instance.EditSP_DAL(sp);
            }
            else //Nếu ko có => add mới
            {
                DAL_SanPham.Instance.AddSP_DAL(sp);
            }
        }
        public SanPham GetSPBYID(string sp)
        {
            foreach(SanPham i in DAL_SanPham.Instance.getAlllSanPham_DAL())
            {
                if (i.maSp == sp) return i;
            }
            return null;
        }
        //sort 
        public SanPham[] SortSP_DAL(LinkedList<SanPham> input, myCompare dele)
        {
            SanPham[] ipreturn = input.ToArray();
            for (int i = 0; i < ipreturn.Length; i++)
            {
                for (int j = 0; j < ipreturn.Length; j++)
                {
                    if (dele(ipreturn[i], ipreturn[j]))
                    {
                        Swap(ref ipreturn[i], ref ipreturn[i]);
                    }
                }
            }
            return ipreturn;
        }
        public delegate bool myCompare(SanPham sp1, SanPham sp2);
        private void Swap(ref SanPham Sps1, ref SanPham Sps2)
        {
            SanPham tem = new SanPham();
            tem = Sps1;
            Sps1 = Sps2;
            tem = Sps2;

        }
        public LinkedList<SanPham> GetSPByDMVaNameSP(string maDm ,string name)
        {
            LinkedList<SanPham> dsreturn = new LinkedList<SanPham>();
            if(maDm == null)
            {
                if(name == null)
                {
                    return DAL_SanPham.Instance.getAlllSanPham_DAL();
                }
                else
                {
                    foreach(SanPham i in DAL_SanPham.Instance.getAlllSanPham_DAL())
                    {
                        if (i.tenSP.ToLower().Contains(name))
                            dsreturn.add(i);
                    }
                }
            }
            else
            {
                if (name == null)
                {
                    return getSanPham_BLL();
                }
                else
                {
                    foreach(SanPham i in DAL_SanPham.Instance.getAlllSanPham_DAL())
                    {
                        if (i.tenSP.ToLower().Contains(name) && i.maDM == maDm)
                            dsreturn.add(i);
                    }
                }
            }
            return dsreturn;
        }
        public SanPham GetSVBymaSp(string maSp)
        {
            foreach (SanPham i in DAL_SanPham.Instance.getAlllSanPham_DAL())
            {
                if (i.maSp == maSp) return i;

            }
            return null;
        }
        public LinkedList<SanPham> getSPBYIDDMBLL(string madm)
        {
            return DAL_SanPham.Instance.getSPbyIDDM(madm);
           
        }

    }
}
