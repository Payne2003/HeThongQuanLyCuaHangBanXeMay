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
        private string connectionString = "Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btForgot_Click(object sender, EventArgs e)
        {
            if (txtmanhanvien.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Hãy nhập đủ dữ liệu ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string Id = txtmanhanvien.Text.Trim();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Password FROM TaiKhoan WHERE MaNV = @MaNV";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaNV", Id);

                        
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            string password = reader["Password"].ToString();

                            txtpassword.Text = password;
                           
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
