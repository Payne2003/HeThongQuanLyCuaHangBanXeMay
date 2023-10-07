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
            guna2ShadowForm1.ShadowColor = Color.Gray; // Màu của đổ bóng
            signup.Visible = false;
            login.Visible = true;
            forgotPassword1.Visible = false;

        }

        private void ptThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?","Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes) 
            {
                Application.Exit();
            }
        }

        private void ptMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkDangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup.Visible = true;
            login.Visible = false;
            forgotPassword1.Visible=false;
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup.Visible = false;
            login.Visible = true;
            forgotPassword1.Visible = false;
        }

        private void linkquenmk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup.Visible = false;
            login.Visible = false;
            forgotPassword1.Visible = true;
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
