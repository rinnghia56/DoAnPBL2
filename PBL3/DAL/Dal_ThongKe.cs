using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DAL
{
    public class Dal_ThongKe
    {
        private static Dal_ThongKe _Instance;
        public static Dal_ThongKe Instance
        {
            get
            {
                if(_Instance == null)
                {
                    return _Instance = new Dal_ThongKe();
                }
                else
                {
                    return _Instance;
                }
            }

        }
        private Dal_ThongKe() { }
        public LinkedList<PhieuXuat> getPhieuXuatByDate_DAL(DateTime tuNgay, DateTime denNgay)
        {
            LinkedList<PhieuXuat> pxList = new LinkedList<PhieuXuat>();
            string query = "SELECT * FROM Phieuxuat WHERE NgayLap BETWEEN '"+ tuNgay + "' AND '"+denNgay+"'";
            PhieuXuat px = new PhieuXuat();
            foreach(DataRow dr in DBHelper.Instance.GetRecord(query).Rows)
            {
                px = getPhieuXuat(dr);
                pxList.add(px);
            }

            return pxList;
        }
        public LinkedList<PhieuNhap> getPhieuNhapByDate_DAL(DateTime tuNgay, DateTime denNgay)
        {
            LinkedList<PhieuNhap> pxList = new LinkedList<PhieuNhap>();
            string query = "SELECT * FROM Phieunhap WHERE NgayNhap BETWEEN '" + tuNgay + "' AND '" + denNgay + "'";
            PhieuNhap px = new PhieuNhap();
            foreach (DataRow dr in DBHelper.Instance.GetRecord(query).Rows)
            {
                px = getPhieuNhap(dr);
                pxList.add(px);
            }

            return pxList;
        }
        public LinkedList<PhieuNhap> getAllPhieuNhap_DAL()
        {
            LinkedList<PhieuNhap> pxList = new LinkedList<PhieuNhap>();
            string query = "SELECT * FROM Phieunhap";
            PhieuNhap px = new PhieuNhap();
            foreach (DataRow dr in DBHelper.Instance.GetRecord(query).Rows)
            {
                px = getPhieuNhap(dr);
                pxList.add(px);
            }

            return pxList;
        }
        public LinkedList<PhieuXuat> getAllPhieuXuat_DAL()
        {
            LinkedList<PhieuXuat> pxList = new LinkedList<PhieuXuat>();
            string query = "SELECT * FROM Phieuxuat";
            PhieuXuat px = new PhieuXuat();
            foreach (DataRow dr in DBHelper.Instance.GetRecord(query).Rows)
            {
                px = getPhieuXuat(dr);
                pxList.add(px);
            }

            return pxList;
        }
        public PhieuNhap getPhieuNhap(DataRow dr)
        {
            return new PhieuNhap()
            {
                maPhieuNhap = dr["MaPhieuNhap"].ToString(),
                ngayNhap = DateTime.Parse(dr["NgayNhap"].ToString()),
                idtk = dr["ID_TK"].ToString()
            };
        }
        public PhieuXuat getPhieuXuat(DataRow dr)
        {
            return new PhieuXuat()
            {
                maHD = dr["MaHD"].ToString(),
                idTK = dr["ID_TK"].ToString(),
                tongTien = decimal.Parse(dr["TongTien"].ToString()),
                ngayLap = DateTime.Parse(dr["NgayLap"].ToString())
            };
        }
        private CTPhieuNhap getCTPhieuNhap(DataRow dr)
        {
            return new CTPhieuNhap()
            {
                maPN = dr["MaPhieuNhap"].ToString(),
                maSP = dr["MaSP"].ToString(),
                soLuong = Int32.Parse(dr["SoLuong"].ToString())

            };
        }
        private CTPhieuXuat getCTPhieuXuat(DataRow dr)
        {
            return new CTPhieuXuat()
            {
                maHD = dr["MaHD"].ToString(),
                maSp = dr["MaSP"].ToString(),
                soLuong = Int32.Parse(dr["SoLuong"].ToString()),
                thanhTien = decimal.Parse(dr["ThanhTien"].ToString())
            };
        }
        public string getTenSanPhambyId_DAL(string ma)
        {
            string query = "SELECT TenSP FROM SanPham where MaSP = '" + ma + "'";
            DataRow dr = DBHelper.Instance.GetRecord(query).Rows[0];
            return dr["TenSP"].ToString();
        }
        public LinkedList<CTPhieuNhap> getCTPhieuNhapById(string id)
        {
            LinkedList<CTPhieuNhap> ctPnList = new LinkedList<CTPhieuNhap>();
            string query = "SELECT * FROM CT_PhieuNhap WHERE MaPhieuNhap = '" + id + "'";
            CTPhieuNhap ctPn = new CTPhieuNhap();
            foreach(DataRow dr in DBHelper.Instance.GetRecord(query).Rows)
            {
                ctPn = getCTPhieuNhap(dr);
                ctPnList.add(ctPn);
            }
            return ctPnList;
        }
        public LinkedList<CTPhieuXuat> getCTPhieuXuatById(string id)
        {
            LinkedList<CTPhieuXuat> ctPxList = new LinkedList<CTPhieuXuat>();
            string query = "SELECT * FROM CT_PhieuXuat WHERE MaHD = '" + id + "'";
            CTPhieuXuat  ctPx = new CTPhieuXuat();
            foreach (DataRow dr in DBHelper.Instance.GetRecord(query).Rows)
            {
                ctPx = getCTPhieuXuat(dr);
                ctPxList.add(ctPx);
            }
            return ctPxList;
        }
        public string getHotenByIDTK_DAL(string IDTK)
        {
            string query = "SELECT Hoten FROM TaiKhoan where IDTK = '" + IDTK + "'";
            DataRow dr = DBHelper.Instance.GetRecord(query).Rows[0];
            return dr["Hoten"].ToString();
        }
    }
}
