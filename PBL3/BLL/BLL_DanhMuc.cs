using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.DAL;
using PBL3.DTO;

namespace PBL3.BLL
{
    class BLL_DanhMuc
    {
        private static BLL_DanhMuc _Instance;
        public static BLL_DanhMuc Instance
        {
            get
            {
                if (_Instance == null)
                {
                    return _Instance = new BLL_DanhMuc();
                }
                else
                {
                    return _Instance;
                }
            }
        }
        public LinkedList<DanhMuc> getDanhMuc_BLL()
        {
            return DAL_DanhMuc.Instance.getAllDanhMuc_DAL();
        }
        public LinkedList<DanhMuc> getTenDanhMuc_BLL()
        {
            return DAL_DanhMuc.Instance.getTenDanhMuc_DAL();
        }
        public void DelBLL(LinkedList<string> sp)
        {
            foreach (string i in sp)
            {
                DAL_DanhMuc.Instance.deleteDM_DAL(i);
            }
        }
        public string CreateKey(string tiento)
        {
            string t;
            t = String.Format("DM");

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
        public void executeDBAddOrEdit(DanhMuc dm)
        {
            if (GetDMBYID(dm.maDm) != null) //svInput ton tai trong DB-> edit
            {
                DAL_DanhMuc.Instance.EditDM_DAL(dm);
            }
            else //Nếu ko có => add mới
            {
                DAL_DanhMuc.Instance.AddDM_DAL(dm);
            }
        }
        public DanhMuc GetDMBYID(string dm)
        {
            foreach (DanhMuc i in DAL_DanhMuc.Instance.getAllDanhMuc_DAL())
            {
                if (i.maDm == dm) return i;
            }
            return null;
        }
        //sort 
        public DanhMuc[] SortDM_BLL(LinkedList<DanhMuc> input, myCompare dele)
        {
            DanhMuc[] ipreturn = input.ToArray();
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
        public delegate bool myCompare(DanhMuc dm1, DanhMuc dm2);
        private void Swap(ref DanhMuc Dms1, ref DanhMuc Dms2)
        {
             DanhMuc tem = new DanhMuc();
            tem = Dms1;
            Dms1 = Dms2;
            tem = Dms2;

        }
        public LinkedList<DanhMuc> GetDMBySP(string maDm, string name)
        {
            LinkedList<DanhMuc> dsreturn = new LinkedList<DanhMuc>();
            if (maDm == null)
            {
                if (name == null)
                {
                    return DAL_DanhMuc.Instance.getAllDanhMuc_DAL();
                }
                else
                {
                    foreach (DanhMuc i in DAL_DanhMuc.Instance.getAllDanhMuc_DAL())
                    {
                        if (i.tenDM.ToLower().Contains(name))
                            dsreturn.add(i);
                    }
                }
            }
            else
            {
                if (name == null)
                {
                    return getDanhMuc_BLL();
                }
                else
                {
                    foreach (DanhMuc i in DAL_DanhMuc.Instance.getAllDanhMuc_DAL())
                    {
                        if (i.tenDM.ToLower().Contains(name) && i.maDm == maDm)
                            dsreturn.add(i);
                    }
                }
            }
            return dsreturn;
        }
        public DanhMuc GetDMBymaDM(string maSp)
        {
            foreach (DanhMuc i in DAL_DanhMuc.Instance.getAllDanhMuc_DAL())
            {
                if (i.maDm == maSp) return i;

            }
            return null;
        }
        public string CreateKeyBll(string tiento)
        {
            string t;
            t = String.Format("DM");

            return t;
        }
    }
}
