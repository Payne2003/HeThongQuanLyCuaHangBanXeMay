using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Model
{
    public class ChiTietHoaDonNhapModel : ProcessDatabase
    {
        public ChiTietHoaDonNhapModel(int soHDN)
        {
            SoHDN = soHDN;
        }

        public int SoHDN { get; set; }
        public int MaHang { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }
        public DataTable LayChiTietHoaDonNhap()
        {
            DataTable dt = new DataTable();

            string sql = @"
                SELECT MaHang, SoLuong, DonGia, GiamGia
                FROM ChiTietHoaDonNhap
                WHERE SoHDN = @SoHDN;
            ";

            // Set the parameter for SoHDN
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoHDN", SoHDN)
            };

            // Execute the query and get the result
            dt = DocBang(sql, parameters);

            return dt;
        }

        public void CapNhatChiTietHoaDonNhap()
        {
            // Define your SQL query to update details based on SoHDN and MaHang
            string sql = @"
                UPDATE ChiTietHoaDonNhap
                SET SoLuong = @SoLuong, DonGia = @DonGia, GiamGia = @GiamGia
                WHERE SoHDN = @SoHDN AND MaHang = @MaHang;
            ";

            // Set parameters for the update
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoHDN", SoHDN),
                new SqlParameter("@MaHang", MaHang),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@DonGia", DonGia),
                new SqlParameter("@GiamGia", GiamGia)
            };

            // Execute the update query
            ExecuteNonQuery(sql, parameters);
        }

        public void XoaDonNhap()
        {
            // Define your SQL query to delete both HoaDonNhap and ChiTietHoaDonNhap
            string sqlDeleteChiTiet = @"
                DELETE FROM ChiTietHoaDonNhap
                WHERE SoHDN = @SoHDN;
            ";

            string sqlDeleteHoaDon = @"
                DELETE FROM HoaDonNhap
                WHERE SoHDN = @SoHDN;
            ";

            // Set the parameter for SoHDN
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoHDN", SoHDN)
            };

            // Execute the delete queries
            ExecuteNonQuery(sqlDeleteChiTiet, parameters);
            ExecuteNonQuery(sqlDeleteHoaDon, parameters);
        }
    }
}
