using QLCHBX.FormKhachHang;
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
    public partial class KhachHang : UserControl
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        public void LoadDataGridView()
        {
            KhachHangModel khachhangLoad = new KhachHangModel();
            btThemKhachHang.Visible = true;
            viewKhachhang.DataSource =  khachhangLoad.LayDuLieuKhachHang();
            viewKhachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            viewKhachhang.Columns[0].Width = 40;
            grThongtinKhachHang.Visible = false;
        }


        private void viewKhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewKhachhang.Rows[e.RowIndex];
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                {
                    grThongtinKhachHang.Visible = true;
                    txtMaKhach.Text = row.Cells[1].Value.ToString();
                    txtTenKhach.Text = row.Cells[2].Value.ToString();
                    txtDiaChi.Text = row.Cells[3].Value.ToString();
                    txtDienThoai.Text = row.Cells[4].Value.ToString();
                    btThemKhachHang.Visible = false;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }


            }

            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewRow row = viewKhachhang.Rows[e.RowIndex];
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                {

                    EditKH editKH = new EditKH();
                    editKH.txtMaKhach.Text = row.Cells[1].Value.ToString();
                    editKH.txtTenKhach.Text = row.Cells[2].Value.ToString();
                    editKH.txtDiaChi.Text = row.Cells[3].Value.ToString();
                    editKH.txtDienThoai.Text = row.Cells[4].Value.ToString();
                    editKH.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }
        }

        private void viewKhachhang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewKhachhang.Rows[e.RowIndex]; // Thay thế dataGridView1 bằng tên của DataGridView thực tế của bạn
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                {
                    string makhachhang = row.Cells[1].Value.ToString();
                    if (!string.IsNullOrEmpty(makhachhang))
                    {
                        DialogResult result = MessageBox.Show("Xóa Khách hàng có mã: " + makhachhang + " ?", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            KhachHangModel khachHang = new KhachHangModel(int.Parse(makhachhang));
                            khachHang.XoaKhachHang();
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

        private void KhachHang_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {

            string key = txtSsearch.Text;

            KhachHangModel khachHang = new KhachHangModel();

            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                return;
            }

            DataTable result = khachHang.TimKiemKhachHang(key);

            if (result.Rows.Count > 0)
            {
                viewKhachhang.DataSource = result;
                viewKhachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng nào.");
            }
        }

        private void btThemKhachHang_Click(object sender, EventArgs e)
        {
            AddKH addKH = new AddKH();
            addKH.ShowDialog();
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
    }
}
