using QLCHBX.Db;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Model
{
    public class DmhItem
    {
        public DmhItem(string tenHang, int maLoai, int maHangSX, int maMau, string namSX, int maPhanh, decimal dungTichBinhXang, int maNuocSX, int maTinhTrang, int soLuong, int thoiGianBaoHanh)
        {
            TenHang = tenHang;
            MaLoai = maLoai;
            MaHangSX = maHangSX;
            MaMau = maMau;
            NamSX = namSX;
            MaPhanh = maPhanh;
            DungTichBinhXang = dungTichBinhXang;
            MaNuocSX = maNuocSX;
            MaTinhTrang = maTinhTrang;
            SoLuong = soLuong;
            ThoiGianBaoHanh = thoiGianBaoHanh;
        }

        public DmhItem(string tenHang, int maLoai, int maHangSX, int maMau, string namSX, int maPhanh, int maDongCo, decimal dungTichBinhXang, int maNuocSX, int maTinhTrang, int soLuong, int thoiGianBaoHanh)
        {
            TenHang = tenHang;
            MaLoai = maLoai;
            MaHangSX = maHangSX;
            MaMau = maMau;
            NamSX = namSX;
            MaPhanh = maPhanh;
            MaDongCo = maDongCo;
            DungTichBinhXang = dungTichBinhXang;
            MaNuocSX = maNuocSX;
            MaTinhTrang = maTinhTrang;
            SoLuong = soLuong;
            ThoiGianBaoHanh = thoiGianBaoHanh;
        }

        public int MaHang { get; set; }
        public string TenHang { get; set; }
        public int MaLoai { get; set; }
        public int MaHangSX { get; set; }
        public int MaMau { get; set; }
        public string NamSX { get; set; }
        public int MaPhanh { get; set; }
        public int MaDongCo { get; set; }
        public decimal DungTichBinhXang { get; set; }
        public int MaNuocSX { get; set; }
        public int MaTinhTrang { get; set; }
        public byte[] Anh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public int ThoiGianBaoHanh { get; set; }
    }

    public class ThemDmhModel : DbConnection
    {
        public ThemDmhModel()
        {

        }

        public bool ThemDmHangMoi(DmhItem item)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string sql = "INSERT INTO Dmh (TenHang, MaTheLoai, MaHangSX, MaMau, NamSX, MaPhanh, MaDongCo, DungTichBinhXang, MaNuocSX, MaTinhTrang, SoLuong, ThoiGianBaoHanh) " +
                             "VALUES (@TenHang, @MaLoai, @MaHangSX, @MaMau, @NamSX, @MaPhanh, @MaDongCo, @DungTichBinhXang, @MaNuocSX, @MaTinhTrang, @SoLuong, @ThoiGianBaoHanh)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@TenHang", item.TenHang);
                    cmd.Parameters.AddWithValue("@MaLoai", item.MaLoai);
                    cmd.Parameters.AddWithValue("@MaHangSX", item.MaHangSX);
                    cmd.Parameters.AddWithValue("@MaMau", item.MaMau);
                    cmd.Parameters.AddWithValue("@NamSX", item.NamSX);
                    cmd.Parameters.AddWithValue("@MaPhanh", item.MaPhanh);
                    cmd.Parameters.AddWithValue("@MaDongCo", item.MaDongCo);
                    cmd.Parameters.AddWithValue("@DungTichBinhXang", item.DungTichBinhXang);
                    cmd.Parameters.AddWithValue("@MaNuocSX", item.MaNuocSX);
                    cmd.Parameters.AddWithValue("@MaTinhTrang", item.MaTinhTrang);
                    cmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                    cmd.Parameters.AddWithValue("@ThoiGianBaoHanh", item.ThoiGianBaoHanh);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public bool ThemDmHangPhanh(DmhItem item)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string sql = "INSERT INTO Dmh (MaLoai, MaHangSX, MaMau, NamSX, MaPhanh, MaNuocSX, MaTinhTrang, SoLuong, ThoiGianBaoHanh) " +
                             "VALUES (@MaLoai, @MaHangSX, @MaMau, @NamSX, @MaPhanh, @MaNuocSX, @MaTinhTrang, @SoLuong, @ThoiGianBaoHanh)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@MaLoai", item.MaLoai);
                    cmd.Parameters.AddWithValue("@MaHangSX", item.MaHangSX);
                    cmd.Parameters.AddWithValue("@MaMau", item.MaMau);
                    cmd.Parameters.AddWithValue("@NamSX", item.NamSX);
                    cmd.Parameters.AddWithValue("@MaPhanh", item.MaPhanh);
                    cmd.Parameters.AddWithValue("@MaNuocSX", item.MaNuocSX);
                    cmd.Parameters.AddWithValue("@MaTinhTrang", item.MaTinhTrang);
                    cmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                    cmd.Parameters.AddWithValue("@ThoiGianBaoHanh", item.ThoiGianBaoHanh);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public bool ThemDmHangDongCo(DmhItem item)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string sql = "INSERT INTO Dmh (MaLoai, MaHangSX, MaMau, NamSX, MaDongCo, DungTichBinhXang, MaNuocSX, MaTinhTrang, SoLuong, ThoiGianBaoHanh) " +
                             "VALUES (@MaLoai, @MaHangSX, @MaMau, @NamSX, @MaDongCo, @DungTichBinhXang, @MaNuocSX, @MaTinhTrang, @SoLuong, @ThoiGianBaoHanh)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@MaLoai", item.MaLoai);
                    cmd.Parameters.AddWithValue("@MaHangSX", item.MaHangSX);
                    cmd.Parameters.AddWithValue("@MaMau", item.MaMau);
                    cmd.Parameters.AddWithValue("@NamSX", item.NamSX);
                    cmd.Parameters.AddWithValue("@MaDongCo", item.MaDongCo);
                    cmd.Parameters.AddWithValue("@DungTichBinhXang", item.DungTichBinhXang);
                    cmd.Parameters.AddWithValue("@MaNuocSX", item.MaNuocSX);
                    cmd.Parameters.AddWithValue("@MaTinhTrang", item.MaTinhTrang);
                    cmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                    cmd.Parameters.AddWithValue("@ThoiGianBaoHanh", item.ThoiGianBaoHanh);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }


        public bool CapNhatDmHang(DmhItem item)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string sql = "UPDATE Dmh " +
                             "SET TenHang = @TenHang, MaTheLoai = @MaLoai, MaHangSX = @MaHangSX, MaMau = @MaMau, " +
                             "NamSX = @NamSX, MaPhanh = @MaPhanh, MaDongCo = @MaDongCo, " +
                             "DungTichBinhXang = @DungTichBinhXang, MaNuocSX = @MaNuocSX, MaTinhTrang = @MaTinhTrang, " +
                             "SoLuong = @SoLuong, DonGiaNhap = @DonGiaNhap, DonGiaBan = @DonGiaBan, ThoiGianBaoHanh = @ThoiGianBaoHanh " +
                             "WHERE MaHang = @MaHang";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@TenHang", item.TenHang);
                    cmd.Parameters.AddWithValue("@MaLoai", item.MaLoai);
                    cmd.Parameters.AddWithValue("@MaHangSX", item.MaHangSX);
                    cmd.Parameters.AddWithValue("@MaMau", item.MaMau);
                    cmd.Parameters.AddWithValue("@NamSX", item.NamSX);
                    cmd.Parameters.AddWithValue("@MaPhanh", item.MaPhanh);
                    cmd.Parameters.AddWithValue("@MaDongCo", item.MaDongCo);
                    cmd.Parameters.AddWithValue("@DungTichBinhXang", item.DungTichBinhXang);
                    cmd.Parameters.AddWithValue("@MaNuocSX", item.MaNuocSX);
                    cmd.Parameters.AddWithValue("@MaTinhTrang", item.MaTinhTrang);
                    cmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                    cmd.Parameters.AddWithValue("@DonGiaNhap", item.DonGiaNhap);
                    cmd.Parameters.AddWithValue("@DonGiaBan", item.DonGiaBan);
                    cmd.Parameters.AddWithValue("@ThoiGianBaoHanh", item.ThoiGianBaoHanh);
                    cmd.Parameters.AddWithValue("@MaHang", item.MaHang);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Phương thức xóa
        public bool XoaDmHang(int maHang)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string sql = "DELETE FROM Dmh WHERE MaHang = @MaHang";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@MaHang", maHang);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

    }



}
