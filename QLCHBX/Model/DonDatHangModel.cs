using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        public DonDatHangModel(int soDDH)
        {
            SoDDH = soDDH;
        }

        public int SoDDH { get; set; }
        public int MaNV { get; set; }
        public int MaKhach { get; set; }
        public DateTime NgayMua { get ; set; }
        public decimal DatCoc { get ; set; }
        public decimal Thue { get; set; }
        public decimal TongTien { get; set; }

        public bool IsMaKhachNull()
        {
            string sql = @"SELECT MaKhach FROM DonDatHang WHERE SoDDH = @SoDDH";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@SoDDH", SoDDH)
            };
            object result = ExecuteScalar(sql, parameters);

            // Kiểm tra nếu result không phải là null và MaKhach không phải là null
            return result != null && result != DBNull.Value;
        }



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
                LEFT JOIN KhachHang kh ON ddh.MaKhach = kh.MaKhach WHERE ddh.TrangThai = 0";

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
                LEFT JOIN KhachHang kh ON ddh.MaKhach = kh.MaKhach WHERE ddh.TrangThai = 1";

            DataTable dt = DocBang(query);
            return dt;
        }

        public bool CapNhatDonDatHang(DateTime date,decimal thueCapNhat,decimal datCocCapNhat,decimal tongTien)
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
                new SqlParameter ("@NgayNhap",date),
                new SqlParameter("@DatCoc", datCocCapNhat),
                new SqlParameter("@Thue", thueCapNhat),
                new SqlParameter("@TongTien", tongTien),
                new SqlParameter("@SoDDH", SoDDH)
            };

            return ExecuteNonQuery(sql, sqlParameters);
        }
        public bool CapNhatKhachHang(int MaKhach)
        {
            string sql = @"
                            UPDATE DonDatHang
                            SET MaKhach = @MaKhach
                            WHERE SoDDH = @SoDDH";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhach", MaKhach),
                new SqlParameter("@SoDDH", SoDDH)
            };

            return ExecuteNonQuery(sql, sqlParameters);
        }

        public int ThemDonDatHang(int maNV, DateTime ngayNhap)
        {
            string sql = @"
                            INSERT INTO DonDatHang (MaNV, NgayMua)
                            VALUES (@MaNV, @NgayMua) SELECT SCOPE_IDENTITY();"; 

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
        public bool XoaChiTietDonDatHang() 
        { 
            string sql = @"
                    DELETE FROM ChiTietDonDatHang
                    WHERE SoDDH = @SoDDH";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                  new SqlParameter("@SoDDH", SoDDH)
            };

            return ExecuteNonQuery(sql, sqlParameters);
        }

        public bool XoaDonHang()
        {
            string sql = @"
                    DELETE FROM DonDatHang
                    WHERE SoDDH = @SoDDH";
            SqlParameter[] sqlParameter = new SqlParameter[]
             {
                new SqlParameter("@SoDDH", SoDDH)
             };
            return ExecuteNonQuery(sql,sqlParameter);
        }
        public DataTable LayDonHangDaThanhToanTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            ngayBatDau = ngayBatDau.Date;
            ngayKetThuc = ngayKetThuc.Date;

            string sql = @"
                 SELECT * FROM LayDonDatHangTheoThoiGian(@NgayBatDau, @NgayKetThuc)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@NgayBatDau", ngayBatDau),
                new SqlParameter("@NgayKetThuc", ngayKetThuc)
            };

            // Use the inherited DocBang method to execute the command and get the results.
            DataTable dt = DocBang(sql, sqlParameters);
            return dt;
        }

        public bool KiemTraCoTonTaiHangNaoTrongDonHangKhong()
        {
            string sql = @"SELECT COUNT(*) FROM ChiTietDonDatHang WHERE SoDDH = @SoDDH)";

            SqlParameter[] sqlParameter = new SqlParameter[]{
                new SqlParameter("@SoDDH", SoDDH)
            };
            object result = ExecuteScalar(sql, sqlParameter);

            return result != null && (int)result > 0;
        }

        public KhachHangModel TimKiemKhachHang(string maKhachOrDienThoai)
        {
            KhachHangModel ketQua = new KhachHangModel();
            string sql = "SELECT * FROM KhachHang WHERE MaKhach = @MaKhach OR DienThoai = @DienThoai";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhach", maKhachOrDienThoai),
                new SqlParameter("@DienThoai", maKhachOrDienThoai)
            };
            DataTable dt = DocBang(sql, sqlParameters);
            foreach (DataRow row in dt.Rows)
            {
                ketQua.MaKhach = Convert.ToInt32(row["MaKhach"]);
                ketQua.TenKhach = row["TenKhach"].ToString();
                ketQua.DiaChi = row["DiaChi"].ToString();
                ketQua.DienThoai = row["DienThoai"].ToString();
            }

            return ketQua;
        }
    }

}
