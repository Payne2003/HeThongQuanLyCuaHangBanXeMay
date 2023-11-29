using QLCHBX.FormGiaoDich.ThanhToan;
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

namespace QLCHBX.FormGiaoDich
{
    public partial class GiaoDich : Form
    {
        private decimal tongtien_ChuaThue = 0;
        private int soluongHangMua = 0;
        public GiaoDich(int MaNV)
        {
            InitializeComponent();
            txtMaNV.Text = MaNV.ToString();
            guna2ShadowForm1.SetShadowForm(this);
        }
        public GiaoDich(int SoDDH,int MaNV)
        {
            InitializeComponent();
            this.txtSoDDH.Text = SoDDH.ToString();
            this.txtMaNV.Text= MaNV.ToString(); 
            guna2ShadowForm1.SetShadowForm(this);
        }
        public void LoadDataGridView()
        {
            ChiTietDonDatHangModel chiTietDonDatHangLoad = new ChiTietDonDatHangModel(int.Parse(txtSoDDH.Text));
            viewChiTietDonHang.DataSource = chiTietDonDatHangLoad.LayDuLieuCuaHoaDon();
            tongtien_ChuaThue = chiTietDonDatHangLoad.LayTongTienChuaThue();
            if (KiemTraTextsRong(txtThue.Text))
            {
                lbTongtien.Text = tongtien_ChuaThue.ToString();
                return;
            }
            else
            {
                decimal TongTien = tongtien_ChuaThue + (decimal.Parse(txtThue.Text) / 100) * tongtien_ChuaThue;
                lbTongtien.Text = TongTien.ToString();
            }
            soluongHangMua = viewChiTietDonHang.RowCount - 1;
            lbGioHang.Text = "Giỏ hàng (" + soluongHangMua + ")";
            grbThongTinDonHangTrongChiTiet.Visible = false;
            CapNhatMau();
        }
        public bool KiemTraTextsRong(params string[] texts)
        {
            return texts.Any(string.IsNullOrWhiteSpace);
        }

        public void CapNhatMau()
        {
            if(decimal.Parse(lbTongtien.Text) > 0 )
            {
                btThanhToan.FillColor = Color.Aquamarine;
            }
            else
            {
                btThanhToan.FillColor = Color.Silver;
            }
            if (KiemTraThemKhachHang())
            {
                btThemKhachHangVaoHoaDon.FillColor = Color.Aquamarine;
                btThemKhachHangVaoHoaDon.ForeColor = Color.Black;
            }
        }

        private void GiaoDich_Load(object sender, EventArgs e)
        {
            
            time_1.Text = DateTime.Now.ToString("HH:mm");
            if (!KiemTraTextsRong(txtSoDDH.Text,txtMaNV.Text))
            {
                LoadDataGridView();
            }
            else
            {
                DonDatHangModel donDatHang_new = new DonDatHangModel();
                DateTime NgayMua = DateTime.Now;
                NgayMua = NgayMua.Date;
                int SoDDH = donDatHang_new.ThemDonDatHang(int.Parse(txtMaNV.Text),NgayMua);
                txtSoDDH.Text = SoDDH.ToString();
            }
            xe2.txtSoDDH.Text = txtSoDDH.Text;
            themKhachHangVaoDonDatHang1.txtSoDDH.Text = txtSoDDH.Text;
        }

        private void btThoatRa_Click(object sender, EventArgs e)
        {
            DonDatHangModel donDatHangModel = new DonDatHangModel(int.Parse(txtSoDDH.Text));
            if (donDatHangModel.KiemTraCoTonTaiHangNaoTrongDonHangKhong())
            {
                this.Close();
                return;
            }
            else
            {
                donDatHangModel.XoaDonHang();
                this.Close();
            }
        }
        public void SaveDataDonDatHang()
        {
            int SoDDH = int.Parse(txtSoDDH.Text);
            DateTime NgayNhap = DateTime.Parse(dtNgayNhap.Text);
            DonDatHangModel donDatHang_CapNhat = new DonDatHangModel(SoDDH);
            ChiTietDonDatHangModel chiTietDon = new ChiTietDonDatHangModel(int.Parse(txtSoDDH.Text));
            if (KiemTraTextsRong(txtThue.Text) || KiemTraTextsRong(txtDatCoc.Text))
            {
               
                if (KiemTraTextsRong(txtThue.Text))
                {
                    txtThue.Text = "0";
                }
                if(KiemTraTextsRong(txtDatCoc.Text))
                {
                    txtDatCoc.Text = "0";
                }
                tongtien_ChuaThue = chiTietDon.LayTongTienChuaThue();
                donDatHang_CapNhat.CapNhatDonDatHang(NgayNhap.Date, decimal.Parse(txtThue.Text), decimal.Parse(txtDatCoc.Text), tongtien_ChuaThue);
            }
            else
            {
                decimal TongTien = tongtien_ChuaThue + (decimal.Parse(txtThue.Text) / 100) * tongtien_ChuaThue;
                donDatHang_CapNhat.CapNhatDonDatHang(NgayNhap.Date, decimal.Parse(txtThue.Text), decimal.Parse(txtDatCoc.Text), TongTien);

            }
        }

        private void viewChiTietDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewChiTietDonHang.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    DmhModel dmhModel = new DmhModel(int.Parse(row.Cells[0].Value.ToString()));
                    txtSoLuongHangTrongKho.Text = (dmhModel.LaySoLuongKho()).ToString();
                    grbThongTinDonHangTrongChiTiet.Visible = true;
                    txtMaHang.Text = row.Cells[0].Value.ToString();
                    txtTenHang.Text = row.Cells[1].Value.ToString();
                    txtSoLuongMua.Text = row.Cells[2].Value.ToString();
                    txtDonGia.Text = row.Cells[3].Value.ToString();
                    txtGiamGia.Text = row.Cells[4].Value.ToString();
                    txtThanhTien.Text = row.Cells[5].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }

        }

        private void txtThue_TextChanged(object sender, EventArgs e)
        {
            if(KiemTraTextsRong(txtThue.Text))
            {
                LoadDataGridView();
                return;
            }
            else
            {
                if (decimal.Parse(txtThue.Text) > 100 && decimal.Parse(txtThue.Text) < 0)
                {
                    MessageBox.Show("0-100%  thôi nhé bạn ơi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    LoadDataGridView();
                    decimal TongTien = tongtien_ChuaThue + (decimal.Parse(txtThue.Text) / 100) * tongtien_ChuaThue;
                    lbTongtien.Text = TongTien.ToString();
                    SaveDataDonDatHang();
                }
            }
        }

        private void txtDatCoc_TextChanged(object sender, EventArgs e)
        {
            if (KiemTraTextsRong(txtDatCoc.Text))
            {
                LoadDataGridView();
                return;
            }
            else
            {
                if (decimal.Parse(txtDatCoc.Text) < 0)
                {
                    MessageBox.Show("Không được nhỏ hơn 0 nhé bạn ơi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    SaveDataDonDatHang();   
                }
            }
        }
        private void txtThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDatCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
        public bool KiemTraThemKhachHang()
        {
            DonDatHangModel donDatHang = new DonDatHangModel(int.Parse(txtSoDDH.Text));
            return donDatHang.IsMaKhachNull();
        }

        private void btThemKhachHangVaoHoaDon_Click(object sender, EventArgs e)
        {
            themKhachHangVaoDonDatHang1.BringToFront();
        }

        private void btXe_Click(object sender, EventArgs e)
        {
            xe2.BringToFront();
        }

        private void GiaoDich_FormClosed(object sender, FormClosedEventArgs e)
        {
            DashBoard dashBoard = Application.OpenForms["DashBoard"] as DashBoard;
            if (dashBoard != null)
            {
                dashBoard.giaoDichCT1.LoadDataGridView();
            }
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (KiemTraTextsRong(txtGiamGia.Text,txtSoLuongMua.Text))
            {
                return;
            }
            else
            {
                if (decimal.Parse(txtGiamGia.Text) > 100 || decimal.Parse(txtGiamGia.Text) < 0 )
                {
                    MessageBox.Show("Giảm giá chỉ từ 0 - 100% thôi bạn ơi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGiamGia.Text = "";
                    return;
                }
                else
                {
                    int soluongMua = int.Parse(txtSoLuongMua.Text);
                    decimal donGiaBan = decimal.Parse(txtDonGia.Text);
                    decimal GiamGia = decimal.Parse(txtGiamGia.Text) / 100;
                    if (soluongMua > int.Parse(txtSoLuongHangTrongKho.Text))
                    {
                        MessageBox.Show("Hàng trong kho không đủ!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoLuongMua.Text = "0";
                    }
                    else
                    {
                        txtThanhTien.Text = (donGiaBan * soluongMua * (1 - GiamGia)).ToString();
                    }

                }
            }
        }
        private void txtSoLuongMua_TextChanged(object sender, EventArgs e)
        {

            if (KiemTraTextsRong(txtGiamGia.Text, txtSoLuongMua.Text))
            {
                return;
            }
            else
            {
                if (!int.TryParse(txtSoLuongMua.Text, out int soluongMua) || soluongMua < 0)
                {
                    MessageBox.Show("Số lượng mua không hợp lệ! Vui lòng nhập số lượng dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuongMua.Text = "";
                    return;
                }
                if (!decimal.TryParse(txtGiamGia.Text, out decimal giamGia) || giamGia > 100 || giamGia < 0)
                {
                    MessageBox.Show("Giảm giá chỉ từ 0 - 100% thôi bạn ơi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGiamGia.Text = "0";
                    return;
                }
                decimal donGiaBan = decimal.Parse(txtDonGia.Text);
                decimal GiamGia = giamGia / 100;

                if (soluongMua > int.Parse(txtSoLuongHangTrongKho.Text))
                {
                    MessageBox.Show("Hàng trong kho không đủ!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuongMua.Text = "0";
                }
                else
                {
                    txtThanhTien.Text = (donGiaBan * soluongMua * (1 - GiamGia)).ToString();
                }
            }

        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            SaveHang();
        }
        public void SaveHang()
        {
            if (string.IsNullOrEmpty(txtSoLuongMua.Text) || string.IsNullOrEmpty(txtGiamGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Số lượng mua và Giảm giá).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                // Tiếp tục xử lý khi đã nhập đủ thông tin
                int SoDDH = int.Parse(txtSoDDH.Text);
                int MaHang = int.Parse(txtMaHang.Text);
                int SoLuongMua = int.Parse(txtSoLuongMua.Text);
                decimal GiamGia = decimal.Parse(txtGiamGia.Text);

                ChiTietDonDatHangModel chiTietDonDatHang_CapNhat = new ChiTietDonDatHangModel(SoDDH, MaHang, SoLuongMua, GiamGia);
                chiTietDonDatHang_CapNhat.CapNhatChiTietDonDatHang();
                LoadDataGridView();
                MessageBox.Show("Cập nhật thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            XacNhanThanhToan xacNhanThanhToan = new XacNhanThanhToan();
            xacNhanThanhToan.lbSoDDH.Text = txtSoDDH.Text;
            xacNhanThanhToan.lbTongTien.Text = lbTongtien.Text;
            xacNhanThanhToan.ShowDialog();
        }

        private void viewChiTietDonHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewChiTietDonHang.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    int SoDDH = int.Parse(txtSoDDH.Text);
                    int MaHang = int.Parse(txtMaHang.Text);
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa hàng " + row.Cells[0].Value.ToString() + " ?", "Xác Nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ChiTietDonDatHangModel chiTietDonDatHang_Xoa = new ChiTietDonDatHangModel(SoDDH,MaHang);
                        chiTietDonDatHang_Xoa.XoaHang();
                        MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                    }
                    else
                    {
                        LoadDataGridView();
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

        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDanhMuc.Text ==  "Động cơ")
            {
                dongCoCT1.txtSoDDH.Text = txtSoDDH.Text;
                dongCoCT1.BringToFront();
            }

            if(cbDanhMuc.Text == "Phanh")
            {
                phanhCT1.txtSoDDH.Text = txtSoDDH.Text;
                phanhCT1.BringToFront();
            }
        }
    }
}
