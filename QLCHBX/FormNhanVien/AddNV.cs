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

namespace QLCHBX.FormNhanVien
{
	public partial class AddNV : Form
	{
		public AddNV()
		{
			InitializeComponent();
		}

		private void btThem_Click(object sender, EventArgs e)
		{
			string tenkhachhang = txtTenNV.Text;
			string diachi = txtDiaChi.Text;
			string sodienthoai = txtDienThoai.Text;
			string gioitinh = "";
			if (rbNam.Checked)
			{
				gioitinh = "Nam";
			}
			if (rbNu.Checked) gioitinh = "Nữ";
			string ngaysinh = dtpNS.Value.ToString();
			int MaCV = cbbCV.SelectedIndex;

			if (string.IsNullOrWhiteSpace(tenkhachhang))
			{
				MessageBox.Show("Vui lòng nhập tên nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (string.IsNullOrWhiteSpace(diachi))
			{
				MessageBox.Show("Vui lòng nhập địa chỉ nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!IsValidPhoneNumber(sodienthoai))
			{
				MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			NhanVienModel nhanVien = new NhanVienModel(txtTenNV.Text, gioitinh, ngaysinh, MaCV, txtDiaChi.Text, txtDienThoai.Text);
			bool success = nhanVien.ThemNV();

			if (success)
			{
				MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Thêm nhân viên thất bại. Số điện thoại đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private bool IsValidPhoneNumber(string phoneNumber)
		{
			return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
		}

		private void btHuys_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				this.Hide();
			}
		}

		private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}


	}
}

