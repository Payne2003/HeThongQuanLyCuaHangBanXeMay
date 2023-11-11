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
        public void LoadDataGirdView()
        {
            ChiTietHoaDonNhapModel chiTietHoaDonNhapLoad = new ChiTietHoaDonNhapModel(int.Parse(txtSoHDN.Text));
            viewChiTietHoaDonNhap.DataSource = chiTietHoaDonNhapLoad.LayChiTietHoaDonNhap();
            DmhModel dmhLoad = new DmhModel();
            viewDmh.DataSource = dmhLoad.LayDuLieuDmh();
            btThemHangNhap.Visible = false;
            btCapNhat.Visible = false;
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
            LoadDataGirdView();
            if (!KiemTraTextsRong(txtSoHDN.Text))
            {
               txtMaNV.Visible = false;
               txtMaNCC.Visible = false;
               lbMaNCC.Visible = false;
               lbMaNV.Visible = false;
            }
            else
            {
                DateTime NgayMua = DateTime.Now;
                HoaDonNhapModel hoaDonNhap_New= new HoaDonNhapModel(int.Parse(txtMaNV.Text),NgayMua,int.Parse(txtMaNCC.Text));
                int SoHDN = hoaDonNhap_New.ThemHoaDonNhap();
                txtSoHDN.Text = SoHDN.ToString();
            }
        }

        private void viewChiTietHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewChiTietHoaDonNhap.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
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
                    ChiTietHoaDonNhapModel chiTietHoaDonNhap = new ChiTietHoaDonNhapModel(int.Parse(txtSoHDN.Text), int.Parse(txtMaHang.Text));
                    if (chiTietHoaDonNhap.KiemTraHangDaDuocNhapHayChua()) 
                    {
                        DialogResult result = MessageBox.Show("Bạn muốn thêm hàng này không ?", "Xác Nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            txtMaHang.Text = row.Cells[0].Value.ToString();
                        }
                        else
                        {
                            LoadDataGirdView();
                            return;
                        }
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
    }
}
