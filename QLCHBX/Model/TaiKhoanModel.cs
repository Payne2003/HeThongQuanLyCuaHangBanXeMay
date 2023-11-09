using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Model
{
    public class TaiKhoanModel : ProcessDatabase
    {

        private string Username;
        private string Password;
        private int MaNV;
        // Constructor for creating an instance with username and password
        public TaiKhoanModel(string username, string password)
        {
            Username = username;
            Password = password; // Note: Storing passwords in plain text is not secure.
        }

        // Constructor for creating an instance with all fields
        public TaiKhoanModel(string username, string password, int maNV)
            : this(username, password)
        {
            MaNV = maNV;
        }

        public TaiKhoanModel(int maNV)
        {
            MaNV = maNV;
        }

        // Method to check login credentials

        public bool KiemTraDangNhap()
        {
            string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE Username = @Username AND Password = @Password";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Username", Username),
                new SqlParameter("@Password", Password) // Passwords should be hashed and compared
            };
            int result = Convert.ToInt32(ExecuteScalar(sql, sqlParameters));
            return result > 0;
        }

        // Method to add a new account
        public bool ThemTaiKhoanMoi()
        {
            string sql = "INSERT INTO TaiKhoan (Username, Password, MaNV) VALUES (@Username, @Password, @MaNV)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Username", Username),
                new SqlParameter("@Password", Password), // Remember to hash passwords before storing
                new SqlParameter("@MaNV", MaNV)
            };
            return ExecuteNonQuery(sql, sqlParameters);
        }

        // Method to check if an account already exists
        public bool KiemTraTaiKhoanTonTai(string Username)
        {
            string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE Username = @Username";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Username", Username)
            };
            int result = Convert.ToInt32(ExecuteScalar(sql, sqlParameters));
            return result > 0;
        }
        public string LayMatKhau()
        {
            string sql = "SELECT Password FROM TaiKhoan WHERE Username = @Username AND MaNV = @MaNV";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Username", Username),
                new SqlParameter("@MaNV", MaNV)
            };
            object result = ExecuteScalar(sql, sqlParameters);
            return result != null ? result.ToString() : null;
        }
        public string LayMaNhanVien()
        {
            string sql = "SELECT MaNV FROM TaiKhoan WHERE Username = @Username AND Password= @Password";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Username", Username),
                new SqlParameter("@Password", Password)
            };
            object result = ExecuteScalar(sql, sqlParameters);
            return result != null ? result.ToString() : null;
        }

    }
}
