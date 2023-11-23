using QLCHBX.FormNV;
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

namespace QLCHBX.ALLControl
{
	public partial class NhanVien : UserControl
	{

		public void LoadDataGridView()
		{
			NhanVienModel nhanVien = new NhanVienModel();
			nhanVien.LayDuLieuNhanVien();
		}

		private void ptLoad_Click(object sender, EventArgs e)
		{
			LoadDataGridView();
		}
	}
}
