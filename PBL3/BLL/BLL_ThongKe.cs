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
        public LinkedNode<PhieuXuat> paritionLast(LinkedNode<PhieuXuat> start, LinkedNode<PhieuXuat> end,Func<decimal,decimal,bool> checkSort)
        {
            if (start == end || start == null || end == null)
                return start;
            LinkedNode<PhieuXuat> cur = start;
           
            LinkedNode<PhieuXuat> pivot_pre = start;
       
            PhieuXuat pivot = end.item;
            PhieuXuat temp;
            while (start != end)
            {
                 if (checkSort(start.item.tongTien,pivot.tongTien))
                {
                    pivot_pre = cur;
                    temp = cur.item;
                    cur.item = start.item;
                    start.item = temp;
                    cur = cur.next;
                }
                start = start.next;
            }
            temp = cur.item;
            cur.item = pivot;
            end.item = temp;
            return pivot_pre;
        }
        public void SortList(LinkedList<PhieuXuat> pxList, String option)
        {
            LinkedNode<PhieuXuat> start = pxList.Head;
            if (start != null)
            {
                LinkedNode<PhieuXuat> end = start;
                while (end.next != null) end = end.next;

                switch (option)
                {
                    case "ASC":
                        quickSortPhieuXuat(start, end, sortASC);
                        break;
                    case "DES":
                        quickSortPhieuXuat(start, end, sortDES);
                        break;
                    default:
                        quickSortPhieuXuat(start, end, sortASC);
                        break;

                }
            }
        }
        public bool sortDES(decimal t1,decimal t2)
        {
            return t1 > t2;
        }
        public bool sortASC(decimal t1, decimal t2)
        {
            return t1 < t2;
        }
        public void quickSortPhieuXuat(LinkedNode<PhieuXuat> start, LinkedNode<PhieuXuat> end, Func<decimal, decimal, bool> checkSort)
        {
            if (start == end) return;
             LinkedNode<PhieuXuat> pivot_pre = paritionLast(start, end,checkSort);
            quickSortPhieuXuat(start, pivot_pre,checkSort);
            if (pivot_pre != null && pivot_pre == start)
            {
                quickSortPhieuXuat(pivot_pre.next, end, checkSort);
            }
            else if (pivot_pre != null && pivot_pre.next != null)
            {
                quickSortPhieuXuat(pivot_pre.next.next, end, checkSort);
            }
          
        }
        

        public string getTenSanPhamByID_BLL(string ma)
        {
            return Dal_ThongKe.Instance.getTenSanPhambyId_DAL(ma);
        }
    }
}
