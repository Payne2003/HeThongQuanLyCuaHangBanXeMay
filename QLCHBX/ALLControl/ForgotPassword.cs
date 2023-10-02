using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.ALLControl
{
    public partial class ForgotPassword : UserControl
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btForgot_Click(object sender, EventArgs e)
        {
            if (txtmanhanvien.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please fill out all fields.", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string Id = txtmanhanvien.Text.Trim();

                // Chuỗi kết nối
                string connectionString = "Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Tạo câu truy vấn để lấy mật khẩu của tài khoản tương ứng với mã nhân viên
                    string query = "SELECT Password FROM TaiKhoan WHERE MaNV = @MaNV";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaNV", Id);

                        // Thực hiện truy vấn và lấy mật khẩu
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            string password = reader["Password"].ToString();

                            txtpassword.Text = password;
                            // Hiển thị mật khẩu hoặc thực hiện các tác vụ khác như gửi mật khẩu đến email của người dùng.
                            MessageBox.Show($"Mật khẩu của bạn là: {password}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nhân viên không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        reader.Close();
                    }
                }
            }
        }

        private void linkdangnhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Visible = true;
           
        }
    }
}
