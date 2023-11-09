using QLCHBX.Model;
using QLCHBX.ThongBao;
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
                ShowCustomMessageBox("Hãy nhập đủ dữ liệu ");
            }
            else if (txtpassword.Text.Trim() != txtreconfirmpassword.Text.Trim())
            {
                ShowCustomMessageBox("Xác nhận mật khẩu không trùng khớp với mật khẩu. Vui lòng nhập lại mật khẩu và xác nhận mật khẩu.");
                txtpassword.Clear();
                txtreconfirmpassword.Clear();
            }
            else
            {
                string username = txtuser.Text.Trim();
                string password = txtpassword.Text.Trim();
                string Id = txtmanhanvien.Text.Trim();
                TaiKhoanModel taiKhoanModel = new TaiKhoanModel(username,password, int.Parse(Id));
            if (taiKhoanModel.KiemTraTaiKhoanTonTai(username))
            {
                ShowCustomMessageBox("Tài khoản đã có!!!.");

            }
            else
            {
                    taiKhoanModel.ThemTaiKhoanMoi();
            }
                
            }
        }
        private void ShowCustomMessageBox(string message)
        {
            MessageBoxForm messageForm = new MessageBoxForm(message);
            messageForm.StartPosition = FormStartPosition.CenterParent;
            messageForm.ShowDialog();
        }
    }
}
