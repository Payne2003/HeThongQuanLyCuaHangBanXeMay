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

		private void NhanVien_Load(object sender, EventArgs e)
		{
			LoadDataGridView();
		}
		

		private void viewNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex == 4)
			{
				DataGridViewRow row = viewNhanVien.Rows[e.RowIndex]; // Thay thế dataGridView1 bằng tên của DataGridView thực tế của bạn
				if (row.Cells[1].Value != null || row.Cells[1].Value.ToString() != "")
				{
					string maNV = row.Cells[0].Value.ToString();
					if (!string.IsNullOrEmpty(maNV))
					{
						DialogResult result = MessageBox.Show("Xóa Nhân viên có mã: " + maNV + " ?", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

						if (result == DialogResult.Yes)
						{
							NhanVienModel nhanVien = new NhanVienModel(int.Parse(maNV));
							nhanVien.XoaNV();
							LoadDataGridView();
						}
						else
						{
							return;
						}
					}
					else
					{
						return;
					}
				}


			}
		}

		private void viewNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = viewNhanVien.Rows[e.RowIndex];
				if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
				{
					dgvNhanVien.Visible = true;

				}
				else
				{
					MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

					return;

				}


			}

			if (e.RowIndex >= 0 && e.ColumnIndex == 0)
			{
				DataGridViewRow row = viewNhanVien.Rows[e.RowIndex];
				if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
				{

					EditNV editNV = new EditNV();		
					editNV.txtMaNV.Text = row.Cells[1].Value.ToString();
					editNV.txtTenNV.Text = row.Cells[1].Value.ToString();
					editNV.txtDiaChi.Text = row.Cells[1].Value.ToString();
					editNV.txtDienThoai.Text = row.Cells[1].Value.ToString();
					editNV.ShowDialog();
				}
				else
				{
					return;

				}
			}
		}

		private void btThemNhanVien_Click(object sender, EventArgs e)
		{

		}
	}
}

