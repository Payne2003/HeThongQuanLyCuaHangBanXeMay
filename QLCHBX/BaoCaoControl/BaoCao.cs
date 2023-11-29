using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.BaoCaoControl
{
	public partial class BaoCao : UserControl
	{
		ProcessDatabase con = new ProcessDatabase();
		public BaoCao()
		{
			InitializeComponent();
		}

		private void cbbHienThi_SelectedIndexChanged(object sender, EventArgs e)
		{
			string sql = "";
			if (cbbHienThi.SelectedIndex == 0)
			{
				sql = "select * from ViewNgay";
				dgvBaoCao.DataSource = con.DocBang(sql);
			}
			if (cbbHienThi.SelectedIndex == 1)
			{
				sql = "select * from ViewTuan";
				dgvBaoCao.DataSource = con.DocBang(sql);
			}
			if (cbbHienThi.SelectedIndex == 2)
			{
				sql = "select * from ViewThang"; ;
				dgvBaoCao.DataSource = con.DocBang(sql);
			}
			if (cbbHienThi.SelectedIndex == 3)
			{
				sql = "select * from ViewNam";
				dgvBaoCao.DataSource = con.DocBang(sql);
			}
		}
	}
}