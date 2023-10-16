﻿using QLCHBX.GDControl;
using QLCHBX.Model;
using QLCHBX.ThongBao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace QLCHBX.ALLControl
{
    public partial class Login : UserControl
    {
        public string manhanvien { get; set; }
        public Login()
        {
            InitializeComponent();
            txtpassword.UseSystemPasswordChar = true;
        }
      

        
     


        private void btlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Trim() == string.Empty || txtpassword.Text.Trim() == string.Empty)
            {
                ShowCustomMessageBox("Vui lòng nhập tên người dùng và mật khẩu.");
            }
            else
            {
                string username = txtuser.Text.Trim();
                string password = txtpassword.Text.Trim();

                LoginModel login = new LoginModel();

                if (login.LoginControl(username, password))
                {
                    // Đăng nhập thành công
                    string maNhanVien = login.LayMaNhanVien(username, password);
                    if (!string.IsNullOrEmpty(maNhanVien))
                    {
                        ShowCustomMessageBox("Đăng nhập thành công");

                        GDCuahang gDCuahang = new GDCuahang();
                        gDCuahang.idnhanvien = maNhanVien;
                        DashBoard dashBoard = new DashBoard();
                        dashBoard.ShowDialog();
                    }
                    else
                    {
                        ShowCustomMessageBox("Lỗi: Không thể tìm thấy thông tin nhân viên.");
                    }
                }
                else
                {
                    // Đăng nhập thất bại
                    ShowCustomMessageBox("Đăng nhập thất bại");

                    // Xóa dữ liệu đã nhập
                    txtuser.Text = "";
                    txtpassword.Text = "";
                }
            }
        }

        private void ShowCustomMessageBox(string message)
        {
            MessageBoxForm messageForm = new MessageBoxForm(message);
            messageForm.StartPosition = FormStartPosition.CenterParent;
            messageForm.ShowDialog();
        }


        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
