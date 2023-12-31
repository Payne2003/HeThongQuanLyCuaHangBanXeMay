﻿using Org.BouncyCastle.Asn1.X509.Qualified;
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
        public DmhModel()
        {
        }

        public DmhModel(int maHang)
        {
            MaHang = maHang;
        }

        public DmhModel(int maHang, byte[] anh) : this(maHang)
        {
            Anh = anh;
        }

        public int MaHang { get; set; }
        public string TenHang { get; set; }
        public int MaTheLoai { get; set; }
        public int MaHangSX { get; set; }
        public int MaMau { get; set; }
        public string NamSX { get; set; }
        public int MaPhanh { get; set; }

        public int MaDongCo { get; set; }
        public decimal DungTichBinhXang { get; set; }
        public int MaNuocSx { get; set; }
        public int MaTinhTrang { get; set; }
        public byte[] Anh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public int ThoiGianBaoHanh { get; set; }
        public DataTable LayDuLieuDmhTheoTenHangSX(string tenHangSX)
        {
            DataTable dt = new DataTable();
            string sql = @"
                        SELECT Dmh.MaHang, Dmh.TenHang, Dmh.NamSX, Dmh.DungTichBinhXang, Dmh.SoLuong, Dmh.DonGiaNhap, Dmh.DonGiaBan, Dmh.ThoiGianBaoHanh,
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
        public DataTable LayDuLieuDmhTheoMaHangSX(string maHangSX)
        {
            DataTable dt = new DataTable();
            string sql = @"
                        SELECT Dmh.MaHang, Dmh.TenHang, Dmh.NamSX, Dmh.DungTichBinhXang, Dmh.SoLuong, Dmh.DonGiaNhap, Dmh.DonGiaBan, Dmh.ThoiGianBaoHanh,
                               Theloai.TenTheLoai, Dongco.TenDongCo, Mausac.TenMau, Nuocsanxuat.TenNuocSX, Tinhtrang.TenTinhTrang, Phanhxe.TenPhanh
                        FROM Dmh
                        INNER JOIN Hangsanxuat ON Dmh.MaHangSX = Hangsanxuat.MaHangSX
                        LEFT JOIN Theloai ON Dmh.MaTheLoai = Theloai.MaTheLoai
                        LEFT JOIN Dongco ON Dmh.MaDongCo = Dongco.MaDongCo
                        LEFT JOIN Mausac ON Dmh.MaMau = Mausac.MaMau
                        LEFT JOIN Nuocsanxuat ON Dmh.MaNuocSX = Nuocsanxuat.MaNuocSX
                        LEFT JOIN Tinhtrang ON Dmh.MaTinhTrang = Tinhtrang.MaTinhTrang
                        LEFT JOIN Phanhxe ON Dmh.MaPhanh = Phanhxe.MaPhanh
                        WHERE Hangsanxuat.MaHangSX = @MaHangSX";

            SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@MaHangSX", maHangSX)
            };
            dt = DocBang(sql, parameters);
            return dt;
        }
        public DataTable LayDuLieuDongCo()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT MaHang, TenHang, MaDongCo,MaPhanh,SoLuong, DonGiaNhap, DonGiaBan,Anh, ThoiGianBaoHanh
FROM Dmh
WHERE MaDongCo IS NOT NULL AND MaPhanh IS NULL;";
            dt = DocBang(sql);
            return dt;
        }
        public DataTable LayDuLieuDongCoTheoMaDongCo(string MaDongCo)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT MaHang, TenHang, MaDongCo,MaPhanh,SoLuong, DonGiaNhap, DonGiaBan,Anh, ThoiGianBaoHanh
FROM Dmh
WHERE MaDongCo IS NOT NULL AND MaPhanh IS NULL AND MaDongCo = @MaDongCo;";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaDongCo", MaDongCo)
            };

            dt = DocBang(sql, sqlParameters);
            return dt;
        }
        public DataTable LayDuLieuPhanh()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT MaHang, TenHang, MaDongCo,MaPhanh, SoLuong, DonGiaNhap, DonGiaBan,Anh, ThoiGianBaoHanh
FROM Dmh
WHERE MaPhanh IS NOT NULL AND MaDongCo IS NULL;

                ";
            dt = DocBang(sql);
            return dt;
        }
        public DataTable LayDuLieuPhanhTheoMaPhanh(string MaPhanh)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT MaHang, TenHang, MaDongCo,MaPhanh, SoLuong, DonGiaNhap,DonGiaBan,Anh,  ThoiGianBaoHanh
FROM Dmh
WHERE MaPhanh IS NOT NULL AND MaDongCo IS NULL AND MaPhanh = @MaPhanh;

                ";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhanh", MaPhanh)
            };
            dt = DocBang(sql,sqlParameters);
            return dt;
        }
        public DataTable LayDuLieuDmh()
        {
            DataTable dt = new DataTable();
            string sql = @"
                        SELECT Dmh.MaHang, Dmh.TenHang, Dmh.NamSX, Dmh.DungTichBinhXang, Dmh.SoLuong, Dmh.DonGiaNhap, Dmh.DonGiaBan, Dmh.ThoiGianBaoHanh,
                               Theloai.TenTheLoai, Dongco.TenDongCo, Mausac.TenMau, Nuocsanxuat.TenNuocSX, Tinhtrang.TenTinhTrang, Phanhxe.TenPhanh
                        FROM Dmh
                        INNER JOIN Hangsanxuat ON Dmh.MaHangSX = Hangsanxuat.MaHangSX
                        LEFT JOIN Theloai ON Dmh.MaTheLoai = Theloai.MaTheLoai
                        LEFT JOIN Dongco ON Dmh.MaDongCo = Dongco.MaDongCo
                        LEFT JOIN Mausac ON Dmh.MaMau = Mausac.MaMau
                        LEFT JOIN Nuocsanxuat ON Dmh.MaNuocSX = Nuocsanxuat.MaNuocSX
                        LEFT JOIN Tinhtrang ON Dmh.MaTinhTrang = Tinhtrang.MaTinhTrang
                        LEFT JOIN Phanhxe ON Dmh.MaPhanh = Phanhxe.MaPhanh;";
            dt = DocBang(sql);
            return dt;
        }

        public DataTable LayDuLieuLichSuGia()
        {
            DataTable dt = new DataTable();

            string sql = "SELECT * FROM ViewLichSuGiaNhap WHERE MaHang = @MaHang;";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@MaHang", MaHang)
            };

            dt = DocBang(sql,parameters);

            return dt;

        }
        public int LaySoLuongKho()
        {
            string sql = "SELECT SoLuong FROM Dmh WHERE MaHang = @MaHang;";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@MaHang", MaHang)
            };

            DataTable result = DocBang(sql, parameters);

            if (result.Rows.Count > 0)
            {

                return Convert.ToInt32(result.Rows[0]["SoLuong"]);
            }
            else
            {
                return -1;
            }
        }
        public void CapNhatSoLuong(int SoLuongCapNhat)
        {

            string sql = @"UPDATE Dmh
                  SET SoLuong = @SoLuongCapNhat
                  WHERE MaHang = @MaHang";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@MaHang", MaHang),
                new SqlParameter("@SoLuongCapNhat", SoLuongCapNhat)
            };

            ExecuteNonQuery(sql, parameters);
        }
        public string LayTenHang()
        {
            string sql = "SELECT TenHang FROM Dmh WHERE MaHang = @MaHang;";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@MaHang", MaHang)
            };

            DataTable result = DocBang(sql, parameters);

            if (result.Rows.Count > 0)
            {

                return Convert.ToString(result.Rows[0]["TenHang"]);
            }
            else
            {
                return "";
            }
        }
        public void CapNhatAnh(byte[] Anh)
        {
            string sql = @"UPDATE Dmh
                   SET Anh = @Anh
                   WHERE MaHang = @MaHang";

            SqlParameter[] parameters;

            if (Anh != null)
            {
                parameters = new SqlParameter[]
                {
            new SqlParameter("@MaHang", MaHang),
            new SqlParameter("@Anh", SqlDbType.VarBinary) { Value = Anh }
                };
            }
            else
            {
                parameters = new SqlParameter[]
                {
            new SqlParameter("@MaHang", MaHang),
            new SqlParameter("@Anh", DBNull.Value)
                };
            }

            ExecuteNonQuery(sql, parameters);
        }
    }
}
