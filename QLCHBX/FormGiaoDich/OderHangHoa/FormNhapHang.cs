using QLCHBX.FormGiaoDich.FormLoaiXe;
using QLCHBX.FormGiaoDich.ThemKhachHang;
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

namespace QLCHBX.FormGiaoDich.OderHangHoa
{
    public partial class FormNhapHang : Form
    {
        decimal tongTien = 0;
        public FormNhapHang(int MaNV,int MaNCC)
        {
            InitializeComponent();
            txtMaNV.Text = MaNV.ToString();
            txtMaNCC.Text = MaNCC.ToString();   
            guna2ShadowForm1.SetShadowForm(this);
        }
        public FormNhapHang(int SoHDN)
        {
            InitializeComponent();
            txtSoHDN.Text = SoHDN.ToString();
            guna2ShadowForm1.SetShadowForm(this);
        }
        public decimal LayTongTien() 
        {
            decimal tongTien = 0;
            for (int i = 0; i < viewChiTietHoaDonNhap.RowCount - 1; i++)
            {
                DataGridViewRow row = viewChiTietHoaDonNhap.Rows[i];
                tongTien += decimal.Parse(row.Cells[5].Value.ToString());
            }
            return tongTien;
        }
        public void CapNhatTongTienHoaDonNhap()
        {
            for (int i = 0; i < viewChiTietHoaDonNhap.RowCount - 1; i++)
            {
                DataGridViewRow row = viewChiTietHoaDonNhap.Rows[i];
                tongTien += decimal.Parse(row.Cells[5].Value.ToString());
            }
            HoaDonNhapModel hoaDonNhap = new HoaDonNhapModel(int.Parse(txtSoHDN.Text),tongTien);
            hoaDonNhap.CapNhatTongTien();
        }
        public void LoadDataGirdView()
        {
            ChiTietHoaDonNhapModel chiTietHoaDonNhapLoad = new ChiTietHoaDonNhapModel(int.Parse(txtSoHDN.Text));
            viewChiTietHoaDonNhap.DataSource = chiTietHoaDonNhapLoad.LayChiTietHoaDonNhap();
            DmhModel dmhLoad = new DmhModel();
            viewDmh.DataSource = dmhLoad.LayDuLieuDmh();
            btThemHangNhap.Visible = false;
            btCapNhat.Visible = false;
            lbTongTien.Text = LayTongTien().ToString();
            LoadText();
        }

        public void LoadText()
        {
            txtGiamGia.Text = "";
            txtDonGia.Text = "";
            txtThanhTien.Text = "";
            txtMaHang.Text = "";
        }
        public bool KiemTraTextsRong(params string[] texts)
        {
            return texts.Any(string.IsNullOrWhiteSpace);
        }

        
        private void FormNhapHang_Load(object sender, EventArgs e)
        {
            
            if (!KiemTraTextsRong(txtSoHDN.Text))
            {
               txtMaNV.Visible = false;
               txtMaNCC.Visible = false;
               lbMaNCC.Visible = false;
               lbMaNV.Visible = false;
               lbSoHDN.Text = txtSoHDN.Text;
               LoadDataGirdView();
            }
            else
            {
                DateTime NgayMua = DateTime.Now;
                HoaDonNhapModel hoaDonNhap_New= new HoaDonNhapModel(int.Parse(txtMaNV.Text),NgayMua,int.Parse(txtMaNCC.Text));
                int SoHDN = hoaDonNhap_New.ThemHoaDonNhap();
                txtSoHDN.Text = SoHDN.ToString();
                lbSoHDN.Text = txtSoHDN.Text;
                LoadDataGirdView();
            }
        }

        private void viewChiTietHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewChiTietHoaDonNhap.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                       btCapNhat.Visible = true;
                       btThemHangNhap.Visible = false;
                       txtMaHang.Text = row.Cells[0].Value.ToString();
                       txtSoLuongNhap.Text = row.Cells[2].Value.ToString();
                       txtGiamGia.Text = row.Cells[3].Value.ToString();
                       txtDonGia.Text = row.Cells[4].Value.ToString();
                       txtThanhTien.Text = row.Cells[5].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }
        }

        private void viewChiTietHoaDonNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewChiTietHoaDonNhap.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    int SoDDH = int.Parse(txtSoHDN.Text);
                    int MaHang = int.Parse(row.Cells[0].Value.ToString());

                    DialogResult result = MessageBox.Show("Bạn có muốn xóa hàng " + MaHang + " ?", "Xác Nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    { 
                        ChiTietHoaDonNhapModel chiTietHoaDonNhap_Xoa = new ChiTietHoaDonNhapModel(SoDDH, MaHang);
                        chiTietHoaDonNhap_Xoa.XoaHang();
                        MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGirdView();
                    }
                    else
                    {
                        LoadDataGirdView();
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

        private void viewDmh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewDmh.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    int MaHang_New = int.Parse(row.Cells[0].Value.ToString());
                    ChiTietHoaDonNhapModel chiTietHoaDonNhap = new ChiTietHoaDonNhapModel(int.Parse(txtSoHDN.Text), int.Parse(row.Cells[0].Value.ToString()));
                    if (chiTietHoaDonNhap.KiemTraHangDaDuocNhapHayChua()) 
                    {
                        MessageBox.Show("Đã có Hàng :" + row.Cells[2].Value.ToString() + " !!!", "Xác Nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        txtGiamGia.ReadOnly = false;
                        txtDonGia.ReadOnly = false;
                        txtMaHang.Text = row.Cells[0].Value.ToString();
                        btThemHangNhap.Visible = true;
                        btCapNhat.Visible = false;
                    }

                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }
        }

        private void btCong_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoLuongNhap.Text, out int currentValue))
            {
                currentValue++;
                txtSoLuongNhap.Text = currentValue.ToString();
            }
            else
            {
                txtSoLuongNhap.Text = "1";
            }
        }

        private void btTru_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoLuongNhap.Text, out int currentValue))
            {
                if (currentValue > 0)
                {
                    currentValue--;
                    txtSoLuongNhap.Text = currentValue.ToString();
                }
                else
                {
                    txtSoLuongNhap.Text = "0";
                }
            }
            else
            {
                txtSoLuongNhap.Text = "0";
            }
        }

        private void ttHonDa_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttHonDa.Text);
        }

        private void ttSYM_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttSYM.Text);
        }

        private void ttSuzuki_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttSuzuki.Text);
        }

        private void ttYamaha_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttYamaha.Text);
        }

        private void ttPiaggio_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttPiaggio.Text);
        }

        private void ttDucati_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttDucati.Text);
        }

        private void ttKTM_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttKTM.Text);
        }

        private void ttKawasaki_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttKawasaki.Text);
        }
        public void LoadDataGridView(string TenHangSX)
        {
            DmhModel dmhModel = new DmhModel();
            viewDmh.DataSource = dmhModel.LayDuLieuDmhTheoTenHangSX(TenHangSX);
        }
        public void SaveHangDaNhap()
        {
            if (KiemTraTextsRong(txtDonGia.Text))
            {
                MessageBox.Show("Vui Lòng nhập đơn giá !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraTextsRong(txtGiamGia.Text))
            {
                txtGiamGia.Text = "0";
            }
            int SoHDN = int.Parse(txtSoHDN.Text);
            int MaHang = int.Parse(txtMaHang.Text);
            int SoLuong = int.Parse(txtSoLuongNhap.Text);
            decimal DonGia = decimal.Parse(txtDonGia.Text);
            decimal GiamGia = decimal.Parse(txtGiamGia.Text);
            ChiTietHoaDonNhapModel chiTietHoaDonNhap_Uppdate = new ChiTietHoaDonNhapModel(SoHDN, MaHang, SoLuong,DonGia, GiamGia);
            chiTietHoaDonNhap_Uppdate.CapNhatChiTietHoaDonNhap();
            LoadDataGirdView();
        }
        public void ThemHang()
        {

            if (KiemTraTextsRong(txtDonGia.Text))
            {
                MessageBox.Show("Vui Lòng nhập đơn giá !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraTextsRong(txtGiamGia.Text))
            {
                txtGiamGia.Text = "0";
            }
            int SoHDN = int.Parse(txtSoHDN.Text);
            int MaHang = int.Parse(txtMaHang.Text);
            int SoLuong = int.Parse(txtSoLuongNhap.Text);
            decimal DonGia = decimal.Parse(txtDonGia.Text);
            decimal GiamGia = decimal.Parse(txtGiamGia.Text);
            ChiTietHoaDonNhapModel chiTietHoaDonNhap_new = new ChiTietHoaDonNhapModel(SoHDN, MaHang, SoLuong, DonGia, GiamGia);
            chiTietHoaDonNhap_new.ThemHang();
            LoadDataGirdView();
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (KiemTraTextsRong(txtGiamGia.Text, txtSoLuongNhap.Text))
            {
                return;
            }
            else
            {
                if (decimal.Parse(txtGiamGia.Text) < 0 || decimal.Parse(txtGiamGia.Text) > 100)
                {
                    errThongTin.SetError(txtGiamGia, "0 - 100% thôi nhé bạn ơi!!!");
                    txtGiamGia.Text = "0";
                    return;
                }
                else
                {
                    decimal thanhTien = decimal.Parse(txtSoLuongNhap.Text) * int.Parse(txtSoLuongNhap.Text) * (1 - decimal.Parse(txtGiamGia.Text) / 100);
                    txtThanhTien.Text = thanhTien.ToString();
                }
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (KiemTraTextsRong(txtGiamGia.Text, txtSoLuongNhap.Text, txtDonGia.Text))
            {
                return;
            }
            else
            {
                if (decimal.Parse(txtDonGia.Text) < 0)
                {
                    MessageBox.Show("Nhập chuẩn vào bạn ơi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDonGia.Text = "0";
                    return;
                }
                else
                {
                    decimal thanhTien = decimal.Parse(txtDonGia.Text) * int.Parse(txtSoLuongNhap.Text) * (1 - decimal.Parse(txtGiamGia.Text) / 100);
                    txtThanhTien.Text = thanhTien.ToString();
                }
            }
        }

        private void txtSoLuongNhap_TextChanged(object sender, EventArgs e)
        {
            if (KiemTraTextsRong(txtGiamGia.Text, txtSoLuongNhap.Text,txtDonGia.Text))
            {
                return;
            }
            else
            {
                if (decimal.Parse(txtGiamGia.Text) < 0 || decimal.Parse(txtGiamGia.Text) > 100)
                {
                    errThongTin.SetError(txtGiamGia, "0 - 100% thôi nhé bạn ơi!!!");
                    return;
                }
                else
                {
                    decimal thanhTien = decimal.Parse(txtDonGia.Text) * int.Parse(txtSoLuongNhap.Text) * (1 - decimal.Parse(txtGiamGia.Text) / 100);
                    txtThanhTien.Text = thanhTien.ToString();
                }
            }
        }

        private void ptbThoatRa_Click(object sender, EventArgs e)
        {
            CapNhatTongTienHoaDonNhap();
            this.Close();
            OrderHangHoaForm orderHangHoa = Application.OpenForms["OrderHangHoaForm"] as OrderHangHoaForm;
            if (orderHangHoa != null)
            {
                orderHangHoa.LoadDataGridView();
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            SaveHangDaNhap();
        }

        private void btThemHangNhap_Click(object sender, EventArgs e)
        {
            ThemHang();
        }
    }
}
