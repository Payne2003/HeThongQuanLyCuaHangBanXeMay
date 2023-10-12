using QLCHBX.ALLControl;
using QLCHBX.Db;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.Model
{
    public class LoginModel : DbConnection
    {
        private string manhanvien { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        public LoginModel()
        {

        }

        public bool LoginControl(string username_x, string password_x)
        {
            using (SqlConnection connection = GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE Username = @Username AND Password = @Password;";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Username", username_x);
                command.Parameters.AddWithValue("@Password", password_x);
                
                connection.Open();

                int count = (int)command.ExecuteScalar(); // Lấy số lượng bản ghi thỏa mãn điều kiện

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
        }
        public string LayMaNhanVien(string username_x, string password_x)
        {
            
           
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string sql = "SELECT MaNV FROM TaiKhoan WHERE Username = @Username AND Password = @Password;";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Username", username_x);
                command.Parameters.AddWithValue("@Password", password_x);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    manhanvien = reader["MaNV"].ToString();
                }

                return manhanvien;
            }
        }





        public string LayMatKhau(string id)
        {
            using (SqlConnection connection = GetConnection())
            {
                string sql = "SELECT Password FROM TaiKhoan WHERE MaNV = @MaNV";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNV", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    password = reader["Password"].ToString();
                }

                return password;
               
            }
           
        }
        public bool ThemTaiKhoanNhanVien(string id, string taikhoan, string matkhau)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "INSERT INTO TaiKhoan (Username, Password, MaNV) VALUES (@Username, @Password, @ID);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", taikhoan);
                    command.Parameters.AddWithValue("@Password", matkhau);
                    command.Parameters.AddWithValue("@ID", id);

                    int count = command.ExecuteNonQuery();

                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static implicit operator LoginModel(Login v)
        {
            throw new NotImplementedException();
        }
    }
}