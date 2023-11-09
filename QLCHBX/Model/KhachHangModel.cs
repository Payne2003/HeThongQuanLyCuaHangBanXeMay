using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLCHBX.Model
{
    public class KhachHangModel : ProcessDatabase
    {
        public int MaKhach { get; set; }
        public string TenKhach { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public KhachHangModel(int maKhach)
        {
            MaKhach = maKhach;
        }

        public KhachHangModel(string tenKhach, string diaChi, string dienThoai)
        {
            TenKhach = tenKhach;
            DiaChi = diaChi;
            DienThoai = dienThoai;
        }

        public KhachHangModel()
        {
        }

        public KhachHangModel(int maKhach, string tenKhach, string diaChi, string dienThoai) : this(maKhach)
        {
            TenKhach = tenKhach;
            DiaChi = diaChi;
            DienThoai = dienThoai;
        }

        public DataTable LayDuLieuKhachHang()
        {
            DataTable dt = new DataTable(); 
            string sql = "SELECT * FROM KhachHang;";

            dt = DocBang(sql);
            return dt;
        }

        public bool ThemKhachHang()
        {
            string sql = "INSERT INTO KhachHang (TenKhach, DiaChi, DienThoai) VALUES (@TenKhach, @DiaChi, @DienThoai)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@TenKhach", TenKhach),
                new SqlParameter("@DiaChi", DiaChi),
                new SqlParameter("@DienThoai", DienThoai)
            };
            return ExecuteNonQuery(sql, sqlParameters);
        }

        public bool XoaKhachHang()
        {
            string sql = "DELETE FROM KhachHang WHERE MaKhach = @MaKhach";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhach", MaKhach)
            };
            return ExecuteNonQuery(sql, sqlParameters);
        }

        public bool CapNhatKhachHang()
        {
            string sql = "UPDATE KhachHang SET TenKhach = @TenKhach, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaKhach = @MaKhach";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhach", MaKhach),
                new SqlParameter("@TenKhach", TenKhach),
                new SqlParameter("@DiaChi", DiaChi),
                new SqlParameter("@DienThoai", DienThoai)
            };
            return ExecuteNonQuery(sql, sqlParameters);
        }

        public KhachHangModel LayKhachHangTheoMaKhach(int maKhach)
        {
            KhachHangModel khachHang = new KhachHangModel();
            string sql = "SELECT * FROM KhachHang WHERE MaKhach = @MaKhach";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhach", maKhach)
            };
            DataTable dt = DocBang(sql, sqlParameters);

            if (dt.Rows.Count > 0)
            {
                khachHang.MaKhach = maKhach;
                khachHang.TenKhach = dt.Rows[0]["TenKhach"].ToString();
                khachHang.DiaChi = dt.Rows[0]["DiaChi"].ToString();
                khachHang.DienThoai = dt.Rows[0]["DienThoai"].ToString();
            }

            return khachHang;
        }

    }
}
