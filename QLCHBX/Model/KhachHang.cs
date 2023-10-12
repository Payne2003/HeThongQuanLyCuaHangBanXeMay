using QLCHBX.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbConnection = QLCHBX.Db.DbConnection;

namespace QLCHBX.Model
{
    public class KhachHang : DbConnection
    {
        private string ID { get; set; }
        private string name { get; set; }
        private string diachi { get; set; }
        private string sodienthoai { get; set; }



        public KhachHang()
        {

        }

        public bool SuaKhachHang(string id, string ten, string diaChi, string soDienThoai)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                // Trước khi cập nhật, kiểm tra số điện thoại trùng lặp
                string checkQuery = "SELECT COUNT(*) FROM KhachHang WHERE MaKhach <> @ID AND DienThoai = @SoDienThoai";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@ID", id);
                checkCommand.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                int duplicateCount = (int)checkCommand.ExecuteScalar();

                if (duplicateCount > 0)
                {
                    // Số điện thoại trùng lặp, không thể cập nhật
                    return false;
                }

                // Số điện thoại không trùng lặp, tiến hành cập nhật
                string query = "UPDATE KhachHang SET TenKhach = @Ten, DiaChi = @DiaChi, DienThoai = @SoDienThoai WHERE MaKhach = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Ten", ten);
                command.Parameters.AddWithValue("@DiaChi", diaChi);
                command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                command.ExecuteNonQuery();

                return true;
            }
        }

        public void XoaKhachHang(string id)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM KhachHang WHERE MaKhach = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            }
        }
        public bool ThemKhachHang(string ten, string diaChi, string soDienThoai)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                // Kiểm tra xem số điện thoại đã tồn tại trong cơ sở dữ liệu chưa
                string checkQuery = "SELECT COUNT(*) FROM KhachHang WHERE DienThoai = @SoDienThoai";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                int duplicateCount = (int)checkCommand.ExecuteScalar();

                if (duplicateCount > 0)
                {
                    // Số điện thoại đã tồn tại, không thể thêm mới
                    return false;
                }

                // Số điện thoại không trùng lặp, tiến hành thêm mới
                string query = "INSERT INTO KhachHang (TenKhach, DiaChi, DienThoai) VALUES (@Ten, @DiaChi, @SoDienThoai)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Ten", ten);
                command.Parameters.AddWithValue("@DiaChi", diaChi);
                command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                command.ExecuteNonQuery();

                return true;
            }
        }



    }
}
