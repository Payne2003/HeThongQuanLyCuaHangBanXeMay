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
using System.Windows.Forms;

namespace QLCHBX.ALLControl
{
    public partial class Signup : UserControl

    {
        public Signup()
        {
            InitializeComponent();
        }

        private void btsignup_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Trim() == string.Empty || txtpassword.Text.Trim() == string.Empty || txtreconfirmpassword.Text.Trim() == string.Empty || txtmanhanvien.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Hãy nhập đủ dữ liệu ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtpassword.Text.Trim() != txtreconfirmpassword.Text.Trim())
            {
                MessageBox.Show("Xác nhận mật khẩu không trùng khớp với mật khẩu. Vui lòng nhập lại mật khẩu và xác nhận mật khẩu.", "Mật khẩu không trùng khớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpassword.Clear();
                txtreconfirmpassword.Clear();
            }
            else
            {
                string username = txtuser.Text.Trim();
                string password = txtpassword.Text.Trim();
                string Id = txtmanhanvien.Text.Trim();
                LoginModel login = new LoginModel();
                // Chuỗi kết nối
            if (login.ThemTaiKhoanNhanVien(Id,username,password))
            {
                MessageBox.Show("Đăng ký thành công.", "Access", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {     
                MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ hoặc mã nhân viên không có.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
            }
        }
     }
}
