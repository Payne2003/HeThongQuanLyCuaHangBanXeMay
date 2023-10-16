using QLCHBX.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.FormKhachHang
{
    public partial class AddKH : Form
    {
        public AddKH()
        {
            InitializeComponent();
           
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            string tenkhachhang = txtten.Text;
            string diachi = txtdiachi.Text;
            string sodienthoai = txtsodienthoai.Text;

            if (string.IsNullOrWhiteSpace(tenkhachhang))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(diachi))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPhoneNumber(sodienthoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            KhachHangModel khachHang = new KhachHangModel();
            bool success = khachHang.ThemKhachHang(tenkhachhang, diachi, sodienthoai);

            if (success)
            {
                MessageBox.Show("Thêm khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại. Số điện thoại đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }

        private void ptminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ptthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void txtten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AddKH_Load(object sender, EventArgs e)
        {

        }
    }
}
