using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX
{
    public partial class LoadForm : Form
    {
        private decimal progress;

        public LoadForm()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            timer1.Start();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            const int increment = 5;

            pnLoad.Width += increment;
            progress = (pnLoad.Width / (decimal)pnfull.Width) * 100;

            // Lấy 2 số sau dấu phẩy
            string progressString = progress.ToString("0.00");
            lbtienTrinh.Text = $"{progressString}%";

            if (pnLoad.Width >= 800)
            {
                timer1.Stop();
                await Task.Delay(1000); // Delay 1 giây (1000 milliseconds)
                OpenLoginForm();
                this.Close();
            }
        }

        private void OpenLoginForm()
        {
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
        }
    }
}
