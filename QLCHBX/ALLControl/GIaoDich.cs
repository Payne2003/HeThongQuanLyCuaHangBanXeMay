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
    public partial class GIaoDich : UserControl
    {
        public GIaoDich()
        {
            InitializeComponent();
        }

        private void btHoadon_Click(object sender, EventArgs e)
        {
            hoaDon1.Visible = true;
            gdCuahang1.Visible = false;
            shopee1.Visible = false;
            goJek1.Visible = false;
        }

        private void btGDch_Click(object sender, EventArgs e)
        {
            hoaDon1.Visible = false;
            gdCuahang1.Visible = true;
            shopee1.Visible = false;
            goJek1.Visible = false;
        }

        private void btGDgj_Click(object sender, EventArgs e)
        {
            hoaDon1.Visible = false;
            gdCuahang1.Visible = false;
            shopee1.Visible = false;
            goJek1.Visible = true;
        }

        private void btGDSp_Click(object sender, EventArgs e)
        {
            hoaDon1.Visible = false;
            gdCuahang1.Visible = false;
            shopee1.Visible = true;
            goJek1.Visible = false;
        }
    }
}
