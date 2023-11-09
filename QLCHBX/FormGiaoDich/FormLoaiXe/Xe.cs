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
        ThemDMhang themDMhang = new ThemDMhang();
        public Xe()
        {
            InitializeComponent();
        }

        private void pthonda_Click(object sender, EventArgs e)
        {
            string tenHangsx = "HonDa";
            themDMhang.lbTenHangSX.Text = tenHangsx;
            themDMhang.txtSoDDH.Text = txtSoDDH.Text;
            themDMhang.ShowDialog();
        }

        private void ptSuzuki_Click(object sender, EventArgs e)
        {
            string tenHangsx = "Suzuki";
            themDMhang.lbTenHangSX.Text = tenHangsx;
            themDMhang.txtSoDDH.Text = txtSoDDH.Text;
            themDMhang.ShowDialog();
        }

        private void ptYamaha_Click(object sender, EventArgs e)
        {
            string tenHangsx = "Yamaha";
            themDMhang.lbTenHangSX.Text = tenHangsx;
            themDMhang.txtSoDDH.Text = txtSoDDH.Text;
            themDMhang.ShowDialog();
        }

        private void ptSYM_Click(object sender, EventArgs e)
        {
            string tenHangsx = "SYM";
            themDMhang.lbTenHangSX.Text = tenHangsx;
            themDMhang.txtSoDDH.Text = txtSoDDH.Text;
            themDMhang.ShowDialog();
        }

        private void ptPiaggio_Click(object sender, EventArgs e)
        {
            string tenHangsx = "Piaggio";
            themDMhang.lbTenHangSX.Text = tenHangsx;
            themDMhang.txtSoDDH.Text = txtSoDDH.Text;
            themDMhang.ShowDialog();
        }

        private void ptktm_Click(object sender, EventArgs e)
        {
            string tenHangsx = "KTM";
            themDMhang.lbTenHangSX.Text = tenHangsx;
            themDMhang.txtSoDDH.Text = txtSoDDH.Text;
            themDMhang.ShowDialog();
        }

        private void ptducati_Click(object sender, EventArgs e)
        {
            string tenHangsx = "Ducati";
            themDMhang.lbTenHangSX.Text = tenHangsx;
            themDMhang.txtSoDDH.Text = txtSoDDH.Text;
            themDMhang.ShowDialog();
        }

        private void ptKawasaki_Click(object sender, EventArgs e)
        {
            string tenHangsx = "Kawasaki";
            themDMhang.lbTenHangSX.Text = tenHangsx; 
            themDMhang.txtSoDDH.Text = txtSoDDH.Text;
            themDMhang.ShowDialog();
        }
    }
}
