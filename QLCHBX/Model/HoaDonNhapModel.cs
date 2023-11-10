using System;
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
        public int SoHDN { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayNhap { get; set; }
        public int MaNCC { get; set; }
        public decimal TongTien { get; set; }


        public HoaDonNhapModel()
        {

        }


        public bool ThemHoaDonNhap()
        {
            string sql = @"
                INSERT INTO HoaDonNhap (MaNV, NgayNhap, MaNCC)
                VALUES (@MaNV, @NgayNhap, @MaNCC);
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@NgayNhap", NgayNhap),
                new SqlParameter("@MaNCC", MaNCC)
            };

            return ExecuteNonQuery(sql, sqlParameters);
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
