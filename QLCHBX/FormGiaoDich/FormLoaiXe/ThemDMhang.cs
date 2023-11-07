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

namespace QLCHBX.FormGiaoDich.FormLoaiXe
{
    public partial class ThemDMhang : Form
    {
        public ThemDMhang()
        { 
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }
        public void LoadDataGridView(string TenHangSX)
        {
            DmhModel dmhModel = new DmhModel(); 
            viewDmh.DataSource = dmhModel.LayDuLieuDmhTheoTenHangSX(TenHangSX);
        }
        private void btthem_Click(object sender, EventArgs e)
        {



        }
        private void ttHonDa_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttHonDa.Text);
        }

        private void ThemDMhang_Load(object sender, EventArgs e)
        {
            LoadDataGridView(lbTenHangSX.Text);
        }

        private void ttSYM_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttHonDa.Text);
        }

        private void ttSuzyki_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttSuzyki.Text);
        }

        private void ttYamaHa_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttYamaHa.Text);
        }

        private void ttPiagogio_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttPiagogio.Text);
        }

        private void ttDucaTi_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttDucaTi.Text);
        }

        private void ttKTM_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttKTM.Text);
        }

        private void ttKawasaki_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttKawasaki.Text);
        }

        private void btcong_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoLuongHangMua.Text, out int currentValue))
            {
                currentValue++;
                txtSoLuongHangMua.Text = currentValue.ToString();
            }
            else
            {
                txtSoLuongHangMua.Text = "1";
            }
        }

        private void bttru_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoLuongHangMua.Text, out int currentValue))
            {
                if (currentValue > 0)
                {
                    currentValue--;
                    txtSoLuongHangMua.Text = currentValue.ToString();
                }
                else
                {
                    txtSoLuongHangMua.Text = "0";
                }
            }
            else
            {
                txtSoLuongHangMua.Text = "0";
            }
        }
    }
}

