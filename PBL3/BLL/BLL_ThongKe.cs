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
                foreach(PhieuXuat x in Dal_ThongKe.Instance.getPhieuXuatByDate_DAL(tuNgay, denNgay)){
                    if (x.maHD.Equals(ma))
                    pxList.add(x);
                }
            }
            else{
                pxList = Dal_ThongKe.Instance.getPhieuXuatByDate_DAL(tuNgay, denNgay);
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
                foreach (PhieuNhap x in Dal_ThongKe.Instance.getPhieuNhapByDate_DAL(tuNgay, denNgay))
                {
                    pnList.add(x);
                }
            }
            else
            {
                pnList = Dal_ThongKe.Instance.getPhieuNhapByDate_DAL(tuNgay, denNgay);
            }
            return pnList;
        }
    }
}
