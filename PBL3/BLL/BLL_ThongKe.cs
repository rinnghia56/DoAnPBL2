using PBL3.DAL;
using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BLL
{
    public class BLL_ThongKe
    {
        private static BLL_ThongKe _Instance;
        public static BLL_ThongKe Instance
        {
            get
            {
                if(_Instance == null)
                {
                    return _Instance = new BLL_ThongKe();
                }
                else
                {
                    return _Instance;
                }
            }
        }
        private BLL_ThongKe()
        {

        }

        public LinkedList<PhieuXuat> getPhieuXuat_BLL(DateTime tuNgay, DateTime denNgay,string ma,bool isAll)
        {
            LinkedList<PhieuXuat> pxList = new LinkedList<PhieuXuat>();
            if (isAll)
            {
                pxList = Dal_ThongKe.Instance.getAllPhieuXuat_DAL();
            }
            else if ("".Equals(ma))
            {
                pxList = Dal_ThongKe.Instance.getPhieuXuatByDate_DAL(tuNgay, denNgay);
            }
            else{
                
                foreach (PhieuXuat x in Dal_ThongKe.Instance.getPhieuXuatByDate_DAL(tuNgay, denNgay))
                {
                    if (x.maHD.Contains(ma))
                        pxList.add(x);
                }
            }
            return pxList; 
        }

        public LinkedList<PhieuNhap> getPhieuNhap_BLL(DateTime tuNgay, DateTime denNgay, string ma,bool isAll)
        {
            LinkedList<PhieuNhap> pnList = new LinkedList<PhieuNhap>();
            if (isAll)
            {
                pnList = Dal_ThongKe.Instance.getAllPhieuNhap_DAL();
            }
            else if ("".Equals(ma))
            {
                
                pnList = Dal_ThongKe.Instance.getPhieuNhapByDate_DAL(tuNgay, denNgay);
            }
            else
            {
               
                foreach (PhieuNhap x in Dal_ThongKe.Instance.getPhieuNhapByDate_DAL(tuNgay, denNgay))
                {
                    if(x.maPhieuNhap.Contains(ma))
                    pnList.add(x);
                }
            }
            return pnList;
        }
        public LinkedList<CTPhieuNhap> getCTPhieuNhapById_BLL(string ma)
        {
            return Dal_ThongKe.Instance.getCTPhieuNhapById(ma);
        }
        public LinkedList<CTPhieuXuat> getCTPhieuXuatById_BLL(string ma)
        {
            return Dal_ThongKe.Instance.getCTPhieuXuatById(ma);
        }
        public string getHotenByIDTK_BLL(string ma)
        {
            return Dal_ThongKe.Instance.getHotenByIDTK_DAL(ma);
        }
        public void sortPhieuXuat(LinkedList<PhieuXuat> pxList, String option)
        {

                switch (option)
                {
                    case "ASC":
                    pxList.sort(sortTASC);
                        break;
                    case "DES":
                    pxList.sort(sortTDES);
                        break;
                    default:
                    pxList.sort(sortTASC);
                    break;

                }
            }
        public void sortPhieuNhap(LinkedList<PhieuNhap> pnList,String option)
        {
            switch (option)
            {
                case "ASC":
                    pnList.sort(sortDateASC);
                    break;
                case "DES":
                    pnList.sort(sortDateDes);
                    break;
                default:
                    pnList.sort(sortDateASC);
                    break;

            }
        }

        private bool sortDateDes(PhieuNhap t1,PhieuNhap t2) { 

            return t1.ngayNhap > t2.ngayNhap;
        }
        private bool sortDateASC(PhieuNhap t1, PhieuNhap t2)
        {
            Console.WriteLine(t1.ngayNhap > t2.ngayNhap);
            return t1.ngayNhap < t2.ngayNhap;
        }
        private bool sortTDES(PhieuXuat t1, PhieuXuat t2)
        {
            return t1.tongTien > t2.tongTien;
        }
        private bool sortTASC(PhieuXuat t1, PhieuXuat t2)
        {
            return t1.tongTien < t2.tongTien;
        }
        

        public string getTenSanPhamByID_BLL(string ma)
        {
            return Dal_ThongKe.Instance.getTenSanPhambyId_DAL(ma);
        }
    }
}
