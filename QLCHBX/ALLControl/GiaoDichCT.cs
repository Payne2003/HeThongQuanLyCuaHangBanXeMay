using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.ALLControl
{
    public partial class GiaoDichCT : UserControl
    {
        public GiaoDichCT()
        {
            InitializeComponent();

        }
    
        private void btHoadon_Click(object sender, EventArgs e)
        {
          hoaDon1.BringToFront();
        }

        private void btGDch_Click(object sender, EventArgs e)
        {
            gdCuahang1.BringToFront();
        }   
         

        private void btGDgj_Click(object sender, EventArgs e)
        {
          gojek1.BringToFront();
        }

        private void btGDSp_Click(object sender, EventArgs e)
        {
            shopee1.BringToFront();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
