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
    public partial class ForgotPassword : UserControl
    {
        public ForgotPassword()
        {
            InitializeComponent();
            txtpassword.ReadOnly = true;
        }

        private void btForgot_Click(object sender, EventArgs e)
        {
            if (txtmanhanvien.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Hãy nhập mã nhân vien của bạn!!! ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string Id = txtmanhanvien.Text;
                LoginModel model = new LoginModel();
                string matkhau = model.LayMatKhau(Id);
                if (matkhau != string.Empty)
                {
                    MessageBox.Show("Đã lấy lại mật khẩu thành công", "Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtpassword.Text = matkhau;
                }
                else
                {
                    MessageBox.Show("Không lấy được mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
        }
    }
}
