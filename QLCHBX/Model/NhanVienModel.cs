using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLCHBX.Model
{
    internal class NhanVienModel : ProcessDatabase
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string Diachi { get; set; }
        public string Gioitinh { get; set; }
        public int MaCV { get; set; }

        public string NgaySinh { get; set; }
        public string DienThoai { get; set; }

        public NhanVienModel(int maNV)
        {
            MaNV = maNV;
        }

        public NhanVienModel(string tenNV, string gioiTinh, string ngaySinh, int maCV, string diaChi, string dienThoai)
        {
            TenNV = tenNV;
            Gioitinh = gioiTinh;
            NgaySinh = ngaySinh;
            MaCV = maCV;
            Diachi = diaChi;
            DienThoai = dienThoai;
        }

        public NhanVienModel()
        {
        }

        public NhanVienModel(int maNV, string tenNV, string gioiTinh, string ngaySinh, int maCV, string diaChi, string dienThoai)
        {
            MaNV = maNV;
            TenNV = tenNV;
            Gioitinh = gioiTinh;
            NgaySinh = ngaySinh;
            MaCV = maCV;
            Diachi = diaChi;
            DienThoai = dienThoai;
        }

        public DataTable LayDuLieuNhanVien()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM NhanVien;";

            dt = DocBang(sql);
            return dt;
        }

        public bool ThemNV()
        {
            string sql = "INSERT INTO NhanVien (TenNV ,Gioitinh ,NgaySinh, MaCV ,Diachi ,DienThoai) VALUES (@TenNV, @Gioitinh ,@NgaySinh , @CongViec ,@Diachi, @DienThoai)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@TenNV", TenNV),
                new SqlParameter("@Gioitinh", Gioitinh),
                new SqlParameter("@NgaySinh", NgaySinh),
                new SqlParameter("@CongViec", MaCV),
                new SqlParameter("@Diachi", Diachi),
                new SqlParameter("@DienThoai", DienThoai)
            };
            return ExecuteNonQuery(sql, sqlParameters);
        }

        public bool XoaNV()
        {
            string sql = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", MaNV)
            };
            return ExecuteNonQuery(sql, sqlParameters);
        }

        public bool CapNhatNV()
        {
            string sql = "UPDATE NhanVien SET TenNV = @TenNV, MaCV = @MaCV, DienThoai = @DienThoai WHERE MaNV = @MaNV";
            SqlParameter[] sqlParameters = new SqlParameter[]
        {
                new SqlParameter("@TenNV", TenNV),
                new SqlParameter("@Gioitinh", Gioitinh),
                new SqlParameter("@NgaySinh", NgaySinh),
                new SqlParameter("@MaCV", MaCV),
                new SqlParameter("@Diachi", Diachi),
                new SqlParameter("@DienThoai", DienThoai)
        };
            return ExecuteNonQuery(sql, sqlParameters);
        }

        public NhanVienModel LayNVTheoNV(int maNV)
        {
            NhanVienModel nhanVien = new NhanVienModel();
            string sql = "SELECT * FROM NhanVien WHERE MaNV = @MaNV";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", maNV)
            };
            DataTable dt = DocBang(sql, sqlParameters);

            if (dt.Rows.Count > 0)
            {
                nhanVien.MaNV = maNV;
                nhanVien.TenNV = dt.Rows[0]["TenNV"].ToString();
                nhanVien.Gioitinh = dt.Rows[0]["Gioitinh"].ToString();
                nhanVien.NgaySinh = dt.Rows[0]["NgaySinh"].ToString();
                nhanVien.MaCV = dt.Rows[0]["MaCV"].GetHashCode();
                nhanVien.Diachi = dt.Rows[0]["Diachi"].ToString();
                nhanVien.DienThoai = dt.Rows[0]["DienThoai"].ToString();
            }

            return nhanVien;
        }
        public DataTable TimKiemNV(string key)
        {
            DataTable dataTable = new DataTable();
            string sql = "SELECT * FROM NhanVien WHERE MaNV = @Key OR DienThoai = @Key";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
        new SqlParameter("@Key", key)
            };
            dataTable = DocBang(sql, sqlParameters);
            return dataTable;
        }

    }
}