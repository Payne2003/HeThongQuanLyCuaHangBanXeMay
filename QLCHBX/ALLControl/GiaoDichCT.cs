using QLCHBX.FormGiaoDich;
using QLCHBX.FormGiaoDich.OderHangHoa;
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
    public partial class GiaoDichCT : UserControl
    {
        DateTime dt = DateTime.Now;
        private decimal tongTienBanDau = 0;
        public GiaoDichCT()
        {
            InitializeComponent();
        }
        public void LoadDataGridView()
        {
            btThanhToan.Visible = false;
            btCapNhat.Visible = false;
            btTaoHoaDon.Visible = true;
            DonDatHangModel donDatHangModelLoad = new DonDatHangModel();
            viewDonDatHang.DataSource =  donDatHangModelLoad.LayDonDatHangChuaThanhToan();
            viewLichSuDonDatHang.DataSource = donDatHangModelLoad.LayDonDatHangDaThanhToan();
            txtSoDDH.Text = "";
            txtTenKhach.Text = "";
            txtThue.Text = "";
            txtDatCoc.Text = "";
            txtTongTien.Text = "";
            dtNgayNhap.Value = dt.Date;
        }
        public bool KiemTraTextsRong(params string[] texts)
        {
            return texts.Any(string.IsNullOrWhiteSpace);
        }
        public void SaveDataGridView()
        {
            int SoDDH = int.Parse(txtSoDDH.Text);
            DonDatHangModel donDatHangCapNhat = new DonDatHangModel(SoDDH);
            donDatHangCapNhat.CapNhatDonDatHang(DateTime.Parse(dtNgayNhap.Text), decimal.Parse(txtThue.Text), decimal.Parse(txtDatCoc.Text), decimal.Parse(txtTongTien.Text));
        }
        private void viewDonDatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rowDonDatHang = viewDonDatHang.Rows[e.RowIndex];
                if (rowDonDatHang.Cells[0].Value != null && rowDonDatHang.Cells[0].Value.ToString() != "")
                {
                    btCapNhat.Visible = true;
                    btThanhToan.Visible = true;
                    btTaoHoaDon.Visible = false;
                    int SoDDH = int.Parse(rowDonDatHang.Cells[0].Value.ToString());
                    ChiTietDonDatHangModel ch = new ChiTietDonDatHangModel(SoDDH);
                    tongTienBanDau = ch.LayTongTienChuaThue();
                    txtSoDDH.Text = rowDonDatHang.Cells[0].Value.ToString();
                    txtMaNV.Text = rowDonDatHang.Cells[1].Value.ToString();
                    txtTenNV.Text = rowDonDatHang.Cells[2].Value.ToString();
                    txtTenKhach.Text = rowDonDatHang.Cells[3].Value.ToString();
                    txtThue.Text = rowDonDatHang.Cells[4].Value.ToString();
                    txtDatCoc.Text = rowDonDatHang.Cells[5].Value.ToString();
                    dtNgayNhap.Text = rowDonDatHang.Cells[6].Value.ToString();
                    txtTongTien.Text = rowDonDatHang.Cells[7].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
           
        }

        private void btOderHangHoa_Click(object sender, EventArgs e)
        {
            OrderHangHoaForm orderHangHoaForm = new OrderHangHoaForm();
            orderHangHoaForm.txtMaNV.Text = txtMaNV.Text;
            orderHangHoaForm.ShowDialog();
        }

        private void viewDonDatHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rowDonDatHang = viewDonDatHang.Rows[e.RowIndex];
                if (rowDonDatHang.Cells[0].Value != null && rowDonDatHang.Cells[0].Value.ToString() != "")
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa đơn hàng " + rowDonDatHang.Cells[0].Value.ToString() + " ?", "Xác Nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DonDatHangModel donDatHang_Xoa = new DonDatHangModel(int.Parse(txtSoDDH.Text));
                        donDatHang_Xoa.XoaChiTietDonDatHang();
                        donDatHang_Xoa.XoaDonHang();
                        LoadDataGridView();
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

        private void GiaoDichCT_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            GiaoDich giaoDich = new GiaoDich(int.Parse(txtSoDDH.Text),int.Parse(txtMaNV.Text));
            giaoDich.txtThue.Text = txtThue.Text;
            giaoDich.txtDatCoc.Text = txtDatCoc.Text;
            giaoDich.ShowDialog();
        }

        private void btTaoHoaDon_Click(object sender, EventArgs e)
        {
            GiaoDich giaoDich = new GiaoDich(int.Parse(txtMaNV.Text));
            giaoDich.ShowDialog();
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            if (KiemTraTextsRong(txtThue.Text, txtDatCoc.Text))
            {
                LoadDataGridView();
                return;
            }
            else
            {
                SaveDataGridView();
                LoadDataGridView();
            }

        }

        private void txtThue_TextChanged(object sender, EventArgs e)
        {
            if (KiemTraTextsRong(txtDatCoc.Text,txtThue.Text))
            {
                return;
            }
            else 
            {
                if (decimal.Parse(txtThue.Text) > 100)
                {
                    MessageBox.Show("Thuế chỉ từ 0 - 100% thôi bạn ơi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                else
                {
                    txtTongTien.Text = (tongTienBanDau + tongTienBanDau * decimal.Parse(txtThue.Text) / 100).ToString();
                }
            }
        }

        private void txtDatCoc_TextChanged(object sender, EventArgs e)
        {
            if (KiemTraTextsRong(txtDatCoc.Text, txtThue.Text))
            {
                return;
            }
            else
            {
                if (decimal.Parse(txtDatCoc.Text) < 0)
                {
                    MessageBox.Show("Nhập chuẩn vào bạn ơi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }

                else
                {
                    txtTongTien.Text = (tongTienBanDau + tongTienBanDau * decimal.Parse(txtThue.Text) / 100).ToString();
                }
            }
        }

        private void txtDatCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void txtThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayBD = DateTime.Parse(dtNgayBD.Text);
                DateTime ngayKT = DateTime.Parse(dtNgayKT.Text);
                if (ngayBD <= ngayKT)
                {
                    DonDatHangModel donDatHangModel = new DonDatHangModel();
                    DataTable dataTable = donDatHangModel.LayDonHangDaThanhToanTheoNgay(ngayBD, ngayKT);
                    viewLichSuDonDatHang.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lỗi Khoảng Thời Gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ngày nhập không hợp lệ. Vui lòng nhập ngày theo định dạng MM/dd/yyyy.", "Lỗi Định Dạng Ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
