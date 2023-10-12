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
        public int idhoadon { get; set; }
        public GiaoDich()
        {
            InitializeComponent();
           
        }

        private void ptThoat_Click(object sender, EventArgs e)
        {
            GiaoDichModel giaoDich = new GiaoDichModel();
            giaoDich.XoaDonDatHang(idhoadon);
            this.Close();
        }

        private void ptminimze_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;  
        }

        private void GiaoDich_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'motorcycle_shop_managerDataSet.dsmathang' table. You can move, or remove it, as needed.
            this.dsmathangTableAdapter.Fill(this.motorcycle_shop_managerDataSet.dsmathang);
            lbmahoadon.Text = idhoadon.ToString();
            lbmahoadon1.Text = idhoadon.ToString();
            // TODO: This line of code loads data into the 'motorcycle_shop_managerDataSet5.Dmh' table. You can move, or remove it, as needed.
            time.Text = DateTime.Now.ToString("HH:mm");

        }

        private void ptmenu_Click(object sender, EventArgs e)
        {

        }

        private void pnHonda_Click(object sender, EventArgs e)
        {

        }

        private void pnYamaha_Click(object sender, EventArgs e)
        {

        }

        private void pnSym_Click(object sender, EventArgs e)
        {

        }

        private void pnSuzuki_Click(object sender, EventArgs e)
        {

        }

        private void pnPiaggio_Click(object sender, EventArgs e)
        {

        }

        private void pnKTM_Click(object sender, EventArgs e)
        {

        }

        private void pnducati_Click(object sender, EventArgs e)
        {

        }

        private void pnKawasaki_Click(object sender, EventArgs e)
        {

        }
    }
}
