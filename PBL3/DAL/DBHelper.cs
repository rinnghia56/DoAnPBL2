using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DAL
{
    public class DBHelper
    {
        private static DBHelper _Instance;
        SqlConnection cnn;
        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    string cnnstr = @" Data Source=LAPTOP-013CEDQ8\SQLEXPRESS;Initial Catalog=PBL2;Integrated Security = True";
                    _Instance = new DBHelper(cnnstr);
                }
                return _Instance;
            }
        }
        private DBHelper(string s)
        {
            cnn = new SqlConnection(s);
        }
        public DataTable GetRecord(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }

        public void ExcuteDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, cnn);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void ProcNhapHang(CTPhieuNhap ct)
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "NhapHang";
            cmd.Connection=cnn;
            // @ma = 'SP002',@sl = 1
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ct.maSP;
            cmd.Parameters.Add("@sl", SqlDbType.Int).Value = ct.soLuong;

            cmd.ExecuteNonQuery();

            cnn.Close();
        }

        public void ProcBanHang(CTPhieuXuat ct)
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "XuatHang";
            cmd.Connection = cnn;
            // @ma = 'SP002',@sl = 1
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ct.maSp;
            cmd.Parameters.Add("@sl", SqlDbType.Int).Value = ct.soLuong;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
