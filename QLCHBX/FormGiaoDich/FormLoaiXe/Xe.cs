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
    public partial class Xe : UserControl
    {
        public Xe()
        {
            InitializeComponent();
        }

        private void pthonda_Click(object sender, EventArgs e)
        {
            ThemDMhang themDMhang = new ThemDMhang();
            themDMhang.ShowDialog();
        }
    }
}
