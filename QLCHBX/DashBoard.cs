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
    public partial class DashBoard : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        public DashBoard()
        { 
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void btBaoCao_Click(object sender, EventArgs e)
        {

        }

 
        private void DashBoard_Resize(object sender, EventArgs e)
        {

            // Kiểm tra nếu form đang ở trạng thái cực tiểu nhỏ (minimized)
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Đặt BorderRadius thành 50
                guna2Elipse1.BorderRadius = 0;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                // Nếu không ở trạng thái cực tiểu nhỏ, đặt lại BorderRadius thành 0
                guna2Elipse1.BorderRadius = 5;
            }
        }

        private void btHangHoa_Click(object sender, EventArgs e)
        {
            //khachhang1.Visible = false;
        }

        private void btGiaoDich_Click(object sender, EventArgs e)
        {
            //khachhang1.Visible = false;
            giaoDichCT1.BringToFront();

        }

        private void btDoiTac_Click(object sender, EventArgs e)
        {
            //khachhang1.Visible = false;
        }

        private void btNhanVien_Click(object sender, EventArgs e)
        {
            //khachhang1.Visible = false;
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
           khachhang1.BringToFront();
        }

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }

        private void header_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void header_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - lastLocation.X, currentScreenPos.Y - lastLocation.Y);
            }
        }






    }
}
