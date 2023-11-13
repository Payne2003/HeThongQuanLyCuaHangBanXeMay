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
using System.Text.RegularExpressions;
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
        private bool IsPasswordValid(string password)
        {
            const string pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";

            Regex regex = new Regex(pattern);
            return regex.IsMatch(password);
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
                return;
            }
            else if (!IsPasswordValid(txtpassword.Text.Trim()))
            {
                ShowCustomMessageBox("Mật khẩu không hợp lệ. Mật khẩu cần chứa ít nhất 8 ký tự bao gồm chữ cái, số và ký tự đặc biệt.");
                txtpassword.Clear();
                txtreconfirmpassword.Clear();
                return;
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
