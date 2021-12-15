using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.DAL;
using PBL3.DTO;

namespace PBL3.BLL
{
    class BLL_TaiKhoan
    {
        private static BLL_TaiKhoan _Instance;
        public static BLL_TaiKhoan Instance
        {
            get
            {
                if (_Instance == null)
                {
                    return _Instance = new BLL_TaiKhoan();
                }
                else
                {
                    return _Instance;
                }
            }
        }
        public LinkedList<TaiKhoan> getTaiKhoan_BLL(string idtk)
        {
            return DAL_TaiKhoan.Instance.getAllTaiKhoan_DAL();
        }
        public void DelBLL(LinkedList<string> tk)
        {
            foreach (string i in tk)
            {
                DAL_TaiKhoan.Instance.deleteTK_DAL(i);
            }
        }
        public string CreateKeyTK(string tiento)
        {
            string t;
            t = String.Format("TK");

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
        public void executeDBAddOrEdit(TaiKhoan tk)
        {
            if (GetTKBYID(tk.idTK) != null) //svInput ton tai trong DB-> edit
            {
                DAL_TaiKhoan.Instance.EditTK_DAL(tk);
            }
            else //Nếu ko có => add mới
            {
                DAL_TaiKhoan.Instance.AddTK_DAL(tk);
            }
        }
        public TaiKhoan GetTKBYID(string tk)
        {
            foreach (TaiKhoan i in DAL_TaiKhoan.Instance.getAllTaiKhoan_DAL())
            {
                if (i.idTK == tk) return i;
            }
            return null;
        }
        //sort 
        public TaiKhoan[] SortTK_BLL(LinkedList<TaiKhoan> input, myCompare dele)
        {
            TaiKhoan[] ipreturn = input.ToArray();
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
        public delegate bool myCompare(TaiKhoan tk1, TaiKhoan tk2);
        private void Swap(ref TaiKhoan Tks1, ref TaiKhoan Tks2)
        {
            TaiKhoan tem = new TaiKhoan();
            tem = Tks1;
            Tks1 = Tks2;
            tem = Tks2;

        }
        public LinkedList<TaiKhoan> GetTKByVaNameTK(string IDTK, string name)
        {
            LinkedList<TaiKhoan> dsreturn = new LinkedList<TaiKhoan>();
            if (IDTK == null)
            {
                if (name == null)
                {
                    return DAL_TaiKhoan.Instance.getAllTaiKhoan_DAL();
                }
                else
                {
                    foreach (TaiKhoan i in DAL_TaiKhoan.Instance.getAllTaiKhoan_DAL())
                    {
                        if (i.hoTen.ToLower().Contains(name))
                            dsreturn.add(i);
                    }
                }
            }
            else
            {
                if (name == null)
                {
                    return getTaiKhoan_BLL(IDTK);
                }
                else
                {
                    foreach (TaiKhoan i in DAL_TaiKhoan.Instance.getAllTaiKhoan_DAL())
                    {
                        if (i.hoTen.ToLower().Contains(name) && i.idTK == IDTK)
                            dsreturn.add(i);
                    }
                }
            }
            return dsreturn;
        }
        public TaiKhoan GetTKByIDTK(string idtk)
        {
            foreach (TaiKhoan i in DAL_TaiKhoan.Instance.getAllTaiKhoan_DAL())
            {
                if (i.idTK == idtk) return i;

            }
            return null;
        }
    }
}
