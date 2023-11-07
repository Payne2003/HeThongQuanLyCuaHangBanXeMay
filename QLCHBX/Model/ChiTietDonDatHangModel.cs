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


        public DataTable LayDuLieuCuaHoaDon()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT c.MaHang, d.TenHang, c.SoLuong, d.DonGiaBan, c.GiamGia, c.ThanhTien
                   FROM chitietdondathang AS c
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
    }
}
