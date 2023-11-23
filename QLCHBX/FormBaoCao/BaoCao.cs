using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.FormBaoCao
{
	public partial class BaoCao : Form
	{
		public BaoCao()
		{
			InitializeComponent();
		}

		private void BaoCao_Load(object sender, EventArgs e)
		{
			string dt = @"SELECT SUM() FROM  ";
			string luong = " ";
			string tienhang = " ";
			

			string loinhuan = (float.Parse(dt)-float.Parse(luong)-float.Parse(tienhang)).ToString();

			txtDoanhThu.Text = dt;
			txtLuong.Text = luong;
			txtTienNhap.Text = tienhang;
			txtLoiNhuan.Text = loinhuan;
		}
    }
}
