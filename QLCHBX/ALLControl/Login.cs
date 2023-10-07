﻿using System;
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
    public partial class Login : UserControl
    {
        string connectionString = "Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        public Login()
        {
            InitializeComponent();
            txtpassword.UseSystemPasswordChar = true;

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

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Tạo câu truy vấn
                    string query = "SELECT COUNT(*) FROM TaiKhoan WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!!!", "Thông báo", MessageBoxButtons.OK);
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
            }
        }

        private void linkdangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Visible = true;
            this.Visible = false;
        }

        private void lkquenmk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Visible = true;
            this.Visible = false;
        }

    }
}