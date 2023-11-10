﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Model
{
    public class HoaDonNhapModel : ProcessDatabase
    {
        private SqlDbType tongTien;

        public int SoHDN { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayNhap { get; set; }
        public int MaNCC { get; set; }
        public decimal TongTien { get; set; }


        public HoaDonNhapModel()
        {

        }

        public HoaDonNhapModel(int maNV, DateTime ngayNhap, int maNCC)
        {
            MaNV = maNV;
            NgayNhap = ngayNhap;
            MaNCC = maNCC;
        }

        public HoaDonNhapModel(int soHDN)
        {
            SoHDN = soHDN;
        }

        public int ThemHoaDonNhap()
        {
            int SoHDN = 0;
            string sql = @"
                INSERT INTO HoaDonNhap (MaNV, NgayNhap, MaNCC)
                VALUES (@MaNV, @NgayNhap, @MaNCC) SELECT SCOPE_IDENTITY();;
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@NgayNhap", NgayNhap),
                new SqlParameter("@MaNCC", MaNCC)
            };

            object result = ExecuteScalar(sql, sqlParameters);
            if (result != null && result is decimal)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                throw new InvalidOperationException("Could not retrieve the order number after insertion.");
            }
        }
        public void CapNhatHoaDonNhap()
        {
            string sql = @"
                UPDATE HoaDonNhap
                SET MaNV = @MaNV, NgayNhap = @NgayNhap, MaNCC = @MaNCC, TongTien = @TongTien, TrangThai = @TrangThai
                WHERE SoHDN = @SoHDN;
            ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoHDN", SoHDN),
                new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@NgayNhap", NgayNhap),
                new SqlParameter("@MaNCC", MaNCC),
                new SqlParameter("@TongTien", tongTien)
            };

            ExecuteNonQuery(sql, parameters);
        }

        public DataTable LayDuLieuHoaDonNhapChuaNhap()
        {
            DataTable dt = new DataTable();

            string sql = @"
                SELECT HDN.SoHDN, HDN.MaNV, NV.TenNV, HDN.MaNCC, NCC.TenNCC, HDN.NgayNhap, HDN.TongTien
                FROM HoaDonNhap HDN
                JOIN Nhanvien NV ON HDN.MaNV = NV.MaNV
                JOIN NhaCungCap NCC ON HDN.MaNCC = NCC.MaNCC WHERE HDN.TrangThai = 0;
             ";

            dt = DocBang(sql);

            return dt;
        }
        public DataTable LayDuLieuHoaDonNhapDaNhap()
        {
            DataTable dt = new DataTable();

            string sql = @"
                SELECT HDN.SoHDN, HDN.MaNV, NV.TenNV, HDN.MaNCC, NCC.TenNCC, HDN.NgayNhap, HDN.TongTien
                FROM HoaDonNhap HDN
                JOIN Nhanvien NV ON HDN.MaNV = NV.MaNV
                JOIN NhaCungCap NCC ON HDN.MaNCC = NCC.MaNCC WHERE HDN.TrangThai = 1;
             ";

            dt = DocBang(sql);

            return dt;
        }



    }
}
