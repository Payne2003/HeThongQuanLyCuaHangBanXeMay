using QLCHBX.GDControl;
using QLCHBX.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QLCHBX.ALLControl
{
    public partial class Login : UserControl
    {
        private string connectionString = "Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlConnection SqlConnection;
        public string manhanvien { get; set; }
        public Login()
        {
            InitializeComponent();
            txtpassword.UseSystemPasswordChar = true;
            
        }

        public void Connect()
        {
            SqlConnection = new SqlConnection();

            SqlConnection.ConnectionString = connectionString;

            SqlConnection.Open();
        }

        public void Disconnect()
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                SqlConnection.Close();
                SqlConnection.Dispose();
            }
        }

        public bool RunSQL(string sql)
        {
            Connect(); // Mở kết nối đến cơ sở dữ liệu

            using (SqlCommand cmd = new SqlCommand(sql, SqlConnection))
            {
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có hàng bị ảnh hưởng
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false; // Trả về false nếu có lỗi
                }
            }

            Disconnect(); // Đóng kết nối đến cơ sở dữ liệu
        }


        private void btlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Trim() == string.Empty || txtpassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Hãy nhập đủ dữ liệu ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string username = txtuser.Text.Trim();
                string password = txtpassword.Text.Trim();
               
                LoginModel login = new LoginModel();
               
                if (login.LoginControl(username,password))
                {
                    MessageBox.Show("Đăng nhập thành công!!!", "Thông báo", MessageBoxButtons.OK);
                    GDCuahang gDCuahang = new GDCuahang();
                    gDCuahang.idnhanvien = this.LayMaNhanVien(username,password);
                    DashBoard dashBoard = new DashBoard();
                    dashBoard.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác. Nhập lại!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtuser.Text = "";
                    txtpassword.Text = "";
                }


            }
        }

        public string LayMaNhanVien(string username, string password)
        {
            string maNhanVien = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT MaNV FROM TaiKhoan WHERE Username = @Username AND Password = @Password;";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            maNhanVien = reader["MaNV"].ToString();
                        }
                    }
                }
            }

            return maNhanVien;
        }


        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
