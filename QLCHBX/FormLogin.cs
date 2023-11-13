using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void ShowHelpDialog()
        {
            MessageBox.Show("Chào mừng bạn đến với ứng dụng FUSHION!\n\n" +
                "1. Để đăng nhập, click vào \"Đã có tài khoản?\"\n" +
                "2. Nếu quên mật khẩu, click vào \"Quên mật khẩu\"\n" +
                "3. Để đăng ký tài khoản mới, click vào \"Tạo tài khoản mới\"\n" +
                "4. Liên hệ chúng tôi nếu bạn cần trợ giúp.", "Hướng dẫn sử dụng");
        }

        private void linkDangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup1.BringToFront();
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login1.BringToFront();
        }

        private void linkquenmk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgotPassword1.BringToFront();
        }

        private void ctThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ctminimize_Click(object sender, EventArgs e)
        {

        }

        private void linkHELP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowHelpDialog();
        }
        private void ChangeFontToEnglish()
        {
            // Thay đổi Font của các điều khiển trong form thành tiếng Anh
            // Ví dụ: this.Font = new Font("Arial", 12);
            // Thay đổi các chuỗi ngôn ngữ thành tiếng Anh
            // Ví dụ: label1.Text = "Welcome to FUSHION App!";
        }

        private void ChangeFontToVietnamese()
        {
            // Thay đổi Font của các điều khiển trong form thành tiếng Việt
            // Ví dụ: this.Font = new Font("Times New Roman", 14);
            // Thay đổi các chuỗi ngôn ngữ thành tiếng Việt
            // Ví dụ: label1.Text = "Chào mừng bạn đến với ứng dụng FUSHION!";
        }

        private void linkfontEnglish_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đổi sang ngôn ngữ tiếng Anh không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ChangeFontToEnglish();
            }
        }

        private void linkfonttiengViet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đổi sang ngôn ngữ tiếng Việt không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ChangeFontToVietnamese();
            }
        }

    }
}
