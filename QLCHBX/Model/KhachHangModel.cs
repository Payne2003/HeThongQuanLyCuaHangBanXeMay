using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

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
            // Kiểm tra xem số điện thoại có tồn tại trong cơ sở dữ liệu hay không
            string checkPhoneQuery = "SELECT COUNT(*) FROM KhachHang WHERE DienThoai = @DienThoai";
            SqlParameter[] checkPhoneParameters = new SqlParameter[]
            {
        new SqlParameter("@DienThoai", DienThoai)
            };

            // Lấy số lượng số điện thoại trùng lặp từ cơ sở dữ liệu
            object existingPhoneCountObj = ExecuteScalar(checkPhoneQuery, checkPhoneParameters);

            // Kiểm tra nếu số lượng số điện thoại trùng lặp lớn hơn 0, tức là số điện thoại đã tồn tại
            if (existingPhoneCountObj != null && Convert.ToInt32(existingPhoneCountObj) > 0)
            {
                Console.WriteLine("Số điện thoại đã tồn tại trong cơ sở dữ liệu.");
                return false;
            }

            // Nếu số điện thoại không trùng lặp, thực hiện thêm khách hàng mới vào cơ sở dữ liệu
            string insertQuery = "INSERT INTO KhachHang (TenKhach, DiaChi, DienThoai) VALUES (@TenKhach, @DiaChi, @DienThoai)";
            SqlParameter[] insertParameters = new SqlParameter[]
            {
        new SqlParameter("@TenKhach", TenKhach),
        new SqlParameter("@DiaChi", DiaChi),
        new SqlParameter("@DienThoai", DienThoai)
            };

            // Thực hiện truy vấn thêm khách hàng
            return ExecuteNonQuery(insertQuery, insertParameters);
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
            // Kiểm tra xem số điện thoại có tồn tại trong cơ sở dữ liệu cho khách hàng khác hay không
            string checkPhoneQuery = "SELECT COUNT(*) FROM KhachHang WHERE DienThoai = @DienThoai AND MaKhach != @MaKhach";
            SqlParameter[] checkPhoneParameters = new SqlParameter[]
            {
        new SqlParameter("@DienThoai", DienThoai),
        new SqlParameter("@MaKhach", MaKhach)
            };

            // Lấy số lượng số điện thoại trùng lặp từ cơ sở dữ liệu
            object existingPhoneCountObj = ExecuteScalar(checkPhoneQuery, checkPhoneParameters);

            // Kiểm tra nếu số lượng số điện thoại trùng lặp lớn hơn 0, tức là số điện thoại đã tồn tại cho khách hàng khác
            if (existingPhoneCountObj != null && Convert.ToInt32(existingPhoneCountObj) > 0)
            {
                Console.WriteLine("Số điện thoại đã tồn tại cho khách hàng khác trong cơ sở dữ liệu.");
                return false;
            }

            // Nếu số điện thoại không trùng lặp cho khách hàng khác, thực hiện cập nhật thông tin khách hàng
            string updateQuery = "UPDATE KhachHang SET TenKhach = @TenKhach, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaKhach = @MaKhach";
            SqlParameter[] updateParameters = new SqlParameter[]
            {
        new SqlParameter("@MaKhach", MaKhach),
        new SqlParameter("@TenKhach", TenKhach),
        new SqlParameter("@DiaChi", DiaChi),
        new SqlParameter("@DienThoai", DienThoai)
            };

            // Thực hiện truy vấn cập nhật thông tin khách hàng
            return ExecuteNonQuery(updateQuery, updateParameters);
        }

        public DataTable TimKiemKhachHang(string key)
        {
            DataTable dataTable = new DataTable();

            string sql = "SELECT * FROM KhachHang WHERE MaKhach = @Key OR DienThoai = @Key";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
        new SqlParameter("@Key", key)
            };

            dataTable = DocBang(sql, sqlParameters);

            return dataTable;
        }

    }
}
