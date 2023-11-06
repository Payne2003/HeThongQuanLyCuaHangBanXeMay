using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.FormGiaoDich.FormLoaiXe
{
    public partial class ThemDMhang : Form
    {
        public ThemDMhang()
        {
            InitializeComponent();
        }
        private void UpdateColor()
        {
            int red = hsbRed.Value;
            int green = hsbGreen.Value;
            int blue = hsbBlue.Value;

            Color selectedColor = Color.FromArgb(red, green, blue);
            pnmamau.BackColor = selectedColor;
        }
        private void btthem_Click(object sender, EventArgs e)
        {

        }

        private void hsbRed_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateColor();

        }

        private void hsbGreen_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateColor();

        }

        private void hsbBlue_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateColor();

        }

        private void symToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
