using QLCHBX.FormNhanVien;
using QLCHBX.FormKhachHang;
using QLCHBX.Model;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data;

namespace QLCHBX.NhanVienConTrol
{
	public partial class NhanVien : UserControl
	{

		public NhanVien()
		{
			InitializeComponent();
		}
		public void LoadDataGridView()
		{
			NhanVienModel nhanVienModel = new NhanVienModel();
			btThemNhanVien.Visible = true;
			btnSua.Visible = true;
			viewNhanVien.DataSource = nhanVienModel.LayDuLieuNhanVien();
			viewNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			viewNhanVien.Columns[0].Width = 40;
			grThongtinNhanVien.Visible = false;
		}


		private void viewNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = viewNhanVien.Rows[e.RowIndex];
				if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
				{
					grThongtinNhanVien.Visible = true;
					txtMaNV.Text = row.Cells[1].Value.ToString();
					txtTenNV.Text = row.Cells[2].Value.ToString();
					if (row.Cells[3].Value.ToString() == "Nam") rbNam.Checked = true;
					else rbNu.Checked = true;
					dtpNS.Text = row.Cells[4].Value.ToString();
					if (row.Cells[5].Value.ToString() == "Giám đốc") cbbCV.SelectedIndex = 0;
					if (row.Cells[5].Value.ToString() == "Nhân viên") cbbCV.SelectedIndex = 1;
					if (row.Cells[5].Value.ToString() == "Quản lý") cbbCV.SelectedIndex = 2;
					txtDiaChi.Text = row.Cells[6].Value.ToString();
					txtDienThoai.Text = row.Cells[7].Value.ToString();
					btThemNhanVien.Visible = false;
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
					editNV.txtTenNV.Text = row.Cells[2].Value.ToString();
					if (row.Cells[3].Value.ToString() == "Nam") editNV.rbNam.Checked = true;
					else editNV.rbNu.Checked = true;

					if (row.Cells[5].Value.ToString() == "Giám đốc") editNV.cbbCV.SelectedIndex = 0;
					if (row.Cells[5].Value.ToString() == "Nhân viên") editNV.cbbCV.SelectedIndex = 1;
					if (row.Cells[5].Value.ToString() == "Quản lý") editNV.cbbCV.SelectedIndex = 2;

					editNV.txtDiaChi.Text = row.Cells[6].Value.ToString();
					editNV.txtDienThoai.Text = row.Cells[7].Value.ToString();
					editNV.ShowDialog();
				}
				else
				{
					MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;

				}
			}
		}

		private void viewNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = viewNhanVien.Rows[e.RowIndex]; // Thay thế dataGridView1 bằng tên của DataGridView thực tế của bạn
				if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
				{
					string maNV = row.Cells[1].Value.ToString();
					if (!string.IsNullOrEmpty(maNV))
					{
						DialogResult result = MessageBox.Show("Xóa Nhân viên có mã: " + maNV + " ?", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

						if (result == DialogResult.Yes)
						{
							NhanVienModel nhanvien = new NhanVienModel(int.Parse(maNV));
							nhanvien.XoaNV();
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
				else
				{
					MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
		}

		private void NhanVien_Load(object sender, EventArgs e)
		{
			LoadDataGridView();
		}

		private void btTimKiem_Click(object sender, EventArgs e)
		{

			string key = txtSsearch.Text;

			NhanVienModel nhanVien = new NhanVienModel();
			nhanVien.LayDuLieuNhanVien();

			if (string.IsNullOrEmpty(key))
			{
				MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
				return;
			}

			DataTable result = nhanVien.TimKiemNV(key);

			if (result.Rows.Count > 0)
			{
				viewNhanVien.DataSource = result;
				viewNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			}
			else
			{
				MessageBox.Show("Không tìm thấy nhân viên nào.");
			}
		}

		private void btThemNhanVien_Click(object sender, EventArgs e)
		{
			AddNV addNV = new AddNV();
			addNV.ShowDialog();
		}

		private void txtSsearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void txtSsearch_TextChanged(object sender, EventArgs e)
		{
			if (txtSsearch.Text == "")
			{
				LoadDataGridView();
			}
		}

		private void ptLoad_Click(object sender, EventArgs e)
		{
			LoadDataGridView();
		}
		private void btnSua_Click(object sender, EventArgs e)
		{
			EditNV editNV = new EditNV();
			editNV.ShowDialog();
		}
	}
}
