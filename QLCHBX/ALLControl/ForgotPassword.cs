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
                ShowCustomMessageBox("Hãy nhập mã nhân vien của bạn!!! ");
            }
            else
            {
                string Id = txtmanhanvien.Text;
                string username = txtusername.Text;
                TaiKhoanModel model = new TaiKhoanModel(int.Parse(Id));

                bool success = model.KiemTraTaiKhoanTonTai(username);
                if (success)
                {
                    string matkhau = model.LayMatKhau();
                    if (matkhau != string.Empty)
                    {
                        ShowCustomMessageBox("Đã lấy lại mật khẩu thành công");
                        txtpassword.Text = matkhau;
                    }
                    else
                    {
                        ShowCustomMessageBox("Không lấy được mật khẩu");
                    }
                }
                else
                {

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
