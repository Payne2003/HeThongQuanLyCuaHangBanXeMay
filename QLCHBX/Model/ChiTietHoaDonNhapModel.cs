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

        public ChiTietHoaDonNhapModel(int soHDN, int maHang) : this(soHDN)
        {
            MaHang = maHang;
        }

        public ChiTietHoaDonNhapModel(int soHDN, int maHang, int soLuong, decimal donGia, decimal giamGia) : this(soHDN, maHang)
        {
            SoLuong = soLuong;
            DonGia = donGia;
            GiamGia = giamGia;
        }

        public int SoHDN { get; set; }
        public int MaHang { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }

        public void ThemHang()
        {
            string sql = @"
            INSERT INTO ChiTietHoaDonNhap (SoHDN, MaHang, SoLuong, DonGia, GiamGia)
            VALUES (@SoHDN, @MaHang, @SoLuong, @DonGia, @GiamGia);
        ";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@SoHDN", SoHDN),
            new SqlParameter("@MaHang", MaHang),
            new SqlParameter("@SoLuong", SoLuong),
            new SqlParameter("@DonGia", DonGia),
            new SqlParameter("@GiamGia", GiamGia)
            };

            ExecuteNonQuery(sql, parameters);
        }

        public DataTable LayChiTietHoaDonNhap()
        {
            DataTable dt = new DataTable();

            string sql = @"
                SELECT CT.MaHang, DMH.TenHang, CT.SoLuong, CT.GiamGia, CT.DonGia, CT.ThanhTien
                FROM ChiTietHoaDonNhap CT
                INNER JOIN Dmh ON CT.MaHang = DMH.MaHang
                WHERE CT.SoHDN = @SoHDN;
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

        public void XoaChiTietHoaDonNhap()
        {
            string sqlDeleteChiTiet = @"
                DELETE FROM ChiTietHoaDonNhap
                WHERE SoHDN = @SoHDN;
            ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoHDN", SoHDN)
            };
            ExecuteNonQuery(sqlDeleteChiTiet, parameters);
        }
        public void XoaHang()
        {
            string sqlDeleteChiTiet = @"
                DELETE FROM ChiTietHoaDonNhap
                WHERE SoHDN = @SoHDN AND MaHang = @MaHang;
            ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoHDN", SoHDN),
                new SqlParameter("@MaHang", MaHang)
            };
            ExecuteNonQuery(sqlDeleteChiTiet, parameters);
        }
        public void XoaHoaDonNhap()
        {
            string sqlDelete = @"
                DELETE FROM HoaDonNhap
                WHERE SoHDN = @SoHDN;
            ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoHDN", SoHDN)
            };
            ExecuteNonQuery(sqlDelete, parameters);
        }
        public bool KiemTraHangDaDuocNhapHayChua()
        {
            string sql = @"
            SELECT COUNT(*)
            FROM ChiTietHoaDonNhap
            WHERE SoHDN = @SoHDN AND MaHang = @MaHang;
            ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoHDN", SoHDN),
                new SqlParameter("@MaHang", MaHang)
            };

            int rowCount = (int)ExecuteScalar(sql, parameters);
            return rowCount > 0;
        }

    }
}
