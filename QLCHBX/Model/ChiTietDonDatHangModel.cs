using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Model
{
    public class ChiTietDonDatHangModel : ProcessDatabase
    {
        public ChiTietDonDatHangModel(int soDDH, int maHang, int soLuong, decimal giamGia)
        {
            SoDDH = soDDH;
            MaHang = maHang;
            SoLuong = soLuong;
            GiamGia = giamGia;
        }

        public ChiTietDonDatHangModel()
        {
        }

        public ChiTietDonDatHangModel(int soDDH)
        {
            SoDDH = soDDH;
        }

        public ChiTietDonDatHangModel(int soDDH, int maHang) : this(soDDH)
        {
            MaHang = maHang;
        }

        public int SoDDH { get; set; }
        public int MaHang { get; set; }
        public int SoLuong { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }


        public bool ThemMatHangVaoHoaDonMua()
        {
            string sql = @" INSERT INTO ChiTietDonDatHang(SoDDH, MaHang, SoLuong, GiamGia)
                        VALUES (@SoDDH, @MaHang, @SoLuong, @GiamGia)";

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SoDDH", SoDDH),
                    new SqlParameter("@MaHang", MaHang),
                    new SqlParameter("@SoLuong", SoLuong),
                    new SqlParameter("@GiamGia", GiamGia)
                    };
            return ExecuteNonQuery(sql, parameters);
        }
        public void CapNhatChiTietDonDatHang()
        {
            // Define your SQL statement to update the ChiTietDonDatHang record.
            string sql = @"UPDATE ChiTietDonDatHang 
                  SET SoLuong = @SoLuong, GiamGia = @GiamGia
                  WHERE SoDDH = @SoDDH AND MaHang = @MaHang";

            // Create an array of SQL parameters for the update.
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@SoDDH", SoDDH),
                new SqlParameter("@MaHang", MaHang),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@GiamGia", GiamGia)
            };

            // Execute the SQL update statement.
            ExecuteNonQuery(sql, parameters);
        }
        public bool KiemTraHangDaDuocNhapHayChua()
        {
            string sql = @"
            SELECT COUNT(*)
            FROM ChiTietDonDatHang
            WHERE SoDDh = @SoDDH AND MaHang = @MaHang;
            ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoDDH", SoDDH),
                new SqlParameter("@MaHang", MaHang)
            };

            int rowCount = (int)ExecuteScalar(sql, parameters);
            return rowCount > 0;
        }
        public void XoaHang()
        {
            string sql = @"DELETE FROM ChiTietDonDatHang WHERE SoDDH = @SoDDH AND MaHang = @MaHang";

            // Create an array of SQL parameters for the update.
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@SoDDH", SoDDH),
                new SqlParameter("@MaHang", MaHang)
            };

            // Execute the SQL update statement.
            ExecuteNonQuery(sql, parameters);
        }   
        public DataTable LayDuLieuCuaHoaDon()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT c.MaHang, d.TenHang, c.SoLuong, d.DonGiaBan, c.GiamGia, c.ThanhTien
                   FROM ChiTietDonDatHang AS c
                   INNER JOIN Dmh AS d ON c.MaHang = d.MaHang
                   WHERE c.SoDDH = @SoDDH";

            SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@SoDDH", SoDDH)
            };

            dt = DocBang(sql, parameters);
            return dt;
        }
        public bool KiemTraHangDaNhap()
        {
            string sql = @"
                            SELECT COUNT(1)
                            FROM ChiTietDonDatHang
                            WHERE SoDDH = @SoDDH AND MaHang = @MaHang";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@SoDDH", SoDDH),
                new SqlParameter("@MaHang", MaHang)
            };
            object result = ExecuteScalar(sql, parameters);
            return (result != null) && (Convert.ToInt32(result) > 0);
        }

        public decimal LayTongTienChuaThue()
        {
            string sql = "SELECT SUM(ThanhTien) AS TongTien FROM ChiTietDonDatHang WHERE SoDDH = @SoDDH;";

            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@SoDDH",SoDDH)
            };

            object tongTien = ExecuteScalar(sql, parameters);
            if (tongTien!=null)
            {
                return Convert.ToDecimal(tongTien);
            }
            else
            {
                return 0;
            }
        }
        
    }
}
