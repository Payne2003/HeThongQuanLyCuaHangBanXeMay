using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Model
{
    public class DmhModel : ProcessDatabase
    {
        public int MaHang { get; set; }
        public string TenHang { get; set;}
        public int MaTheLoai { get; set; }
        public int MaHangSX { get; set; }
        public int MaMau { get; set; }
        public string NamSX { get; set; }
        public int MaPhanh { get; set;}

        public int MaDongCo { get; set; }
        public decimal DungTichBinhXang { get; set; }   
        public int MaNuocSx { get; set; }
        public int MaTinhTrang { get; set; }
        public byte Anh { get; set; }
        public int SoLuong { get; set;}
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public int ThoiGianBaoHanh { get; set; }
        public DataTable LayDuLieuDmhTheoTenHangSX(string tenHangSX)
        {
            DataTable dt = new DataTable();
            string sql = @"
                        SELECT Dmh.TenHang, Dmh.NamSX, Dmh.DungTichBinhXang, Dmh.SoLuong, Dmh.DonGiaNhap, Dmh.DonGiaBan, Dmh.ThoiGianBaoHanh,
                               Theloai.TenTheLoai, Dongco.TenDongCo, Mausac.TenMau, Nuocsanxuat.TenNuocSX, Tinhtrang.TenTinhTrang, Phanhxe.TenPhanh
                        FROM Dmh
                        INNER JOIN Hangsanxuat ON Dmh.MaHangSX = Hangsanxuat.MaHangSX
                        LEFT JOIN Theloai ON Dmh.MaTheLoai = Theloai.MaTheLoai
                        LEFT JOIN Dongco ON Dmh.MaDongCo = Dongco.MaDongCo
                        LEFT JOIN Mausac ON Dmh.MaMau = Mausac.MaMau
                        LEFT JOIN Nuocsanxuat ON Dmh.MaNuocSX = Nuocsanxuat.MaNuocSX
                        LEFT JOIN Tinhtrang ON Dmh.MaTinhTrang = Tinhtrang.MaTinhTrang
                        LEFT JOIN Phanhxe ON Dmh.MaPhanh = Phanhxe.MaPhanh
                        WHERE Hangsanxuat.TenHangSX = @TenHangSX";

            SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@TenHangSX", tenHangSX)
            };
            dt = DocBang(sql, parameters);
            return dt;
        }

    }
}
