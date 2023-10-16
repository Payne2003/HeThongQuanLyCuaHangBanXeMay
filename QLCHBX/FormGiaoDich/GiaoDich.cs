using QLCHBX.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.FormGiaoDich
{
    public partial class GiaoDich : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public string idban { get; set; }
        public GiaoDich()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);

        }
        private void GiaoDich_Load(object sender, EventArgs e)
        {
            soban.Text = idban;
            // TODO: This line of code loads data into the 'motorcycle_shop_managerDataSet5.Dmh' table. You can move, or remove it, as needed.
            time_1.Text = DateTime.Now.ToString("HH:mm");

        }

        private void btchietkhau_Click(object sender, EventArgs e)
        {

        }

        private void btthemdondathang_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void header_MouseHover(object sender, EventArgs e)
        {

        }

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void header_MouseUp(object sender, MouseEventArgs e)
        {
         
        }

        private void header_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void soban_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - lastLocation.X, currentScreenPos.Y - lastLocation.Y);
            }
        }

        private void soban_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void soban_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }
    }
}
