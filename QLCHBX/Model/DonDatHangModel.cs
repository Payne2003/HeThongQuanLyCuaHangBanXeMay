﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Model
{
    public class DonDatHangModel : ProcessDatabase
    {
        public DonDatHangModel(int maNV, DateTime ngayMua)
        {
            MaNV = maNV;
            NgayMua = ngayMua;
        }

        public DonDatHangModel(int soDDH, int maNV, DateTime ngayMua, decimal datCoc, decimal thue, decimal tongTien)
        {
            SoDDH = soDDH;
            MaNV = maNV;
            NgayMua = ngayMua;
            DatCoc = datCoc;
            Thue = thue;
            TongTien = tongTien;
        }

        public DonDatHangModel()
        {
        }

        public int SoDDH { get; set; }
        public int MaNV { get; set; }
        public int MaKhach { get; set; }
        public DateTime NgayMua { get ; set; }
        public decimal DatCoc { get ; set; }
        public decimal Thue { get; set; }
        public decimal TongTien { get; set; }    



        public DataTable LayDonDatHangChuaThanhToan()
        {
            string query = @"
                SELECT ddh.SoDDH, 
                       nv.MaNV, 
                       nv.TenNV, 
                       ISNULL(kh.TenKhach, 'Không rõ') AS TenKhach, 
                       ddh.Thue, 
                       ddh.DatCoc, 
                       ddh.NgayMua, 
                       ddh.TongTien
                FROM DonDatHang ddh
                INNER JOIN NhanVien nv ON ddh.MaNV = nv.MaNV
                LEFT JOIN KhachHang kh ON ddh.MaKhachHang = kh.MaKhachHang WHERE ddh.TrangThai = 0";

            DataTable dt = DocBang(query);
            return dt;
        }
        public DataTable LayDonDatHangDaThanhToan()
        {
            string query = @"
                SELECT ddh.SoDDH, 
                       nv.MaNV, 
                       nv.TenNV, 
                       ISNULL(kh.TenKhach, 'Không rõ') AS TenKhach, 
                       ddh.Thue, 
                       ddh.DatCoc, 
                       ddh.NgayMua, 
                       ddh.TongTien
                FROM DonDatHang ddh
                INNER JOIN NhanVien nv ON ddh.MaNV = nv.MaNV
                LEFT JOIN KhachHang kh ON ddh.MaKhachHang = kh.MaKhachHang WHERE ddh.TrangThai = 1";

            DataTable dt = DocBang(query);
            return dt;
        }

        public bool CapNhatDonDatHang(int soDDH,DateTime ngayNhap, decimal datCoc, decimal thue, decimal tongTien)
        {
            string sql = @"
                            UPDATE DonDatHang
                            SET 
                                NgayMua = @NgayNhap, 
                                DatCoc = @DatCoc,
                                Thue = @Thue, 
                                TongTien = @TongTien
                            WHERE SoDDH = @SoDDH";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter ("@NgayNhap",ngayNhap),
                new SqlParameter("@DatCoc", datCoc),
                new SqlParameter("@Thue", thue),
                new SqlParameter("@TongTien", tongTien),
                new SqlParameter("@SoDDH", soDDH)
            };

            return ExecuteNonQuery(sql, sqlParameters);
        }
        public int ThemDonDatHang(int maNV, DateTime ngayNhap)
        {
            string sql = @"
                            INSERT INTO DonDatHang (MaNV, NgayMua)
                            VALUES (@MaNV, @NgayMua) SELECT SCOPE_IDENTITY();"; // This retrieves the last inserted identity value

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@NgayMua", ngayNhap)
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



    }

}