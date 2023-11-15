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
    public partial class LichSuNhapHangForm : Form
    {
        public LichSuNhapHangForm()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }
        public void LoadDataGirdView()
        {
            HoaDonNhapModel hoaDonNhapModel_Load= new HoaDonNhapModel();
            viewHoaDonNhap.DataSource = hoaDonNhapModel_Load.LayDuLieuHoaDonNhapDaNhap();
            btHuyNhapHang.Visible = false;
            grThongtin.Visible = false;
            LoadText();
        }
        public void LoadText()
        {
            txtSoHDN.Text = "";
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtTongTien.Text = "";
        }

        private void viewHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewHoaDonNhap.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    btHuyNhapHang.Visible = true;
                    grThongtin.Visible = true;
                    txtSoHDN.Text = row.Cells[0].Value.ToString();
                    txtMaNV.Text = row.Cells[1].Value.ToString();
                    txtTenNV.Text = row.Cells[2].Value.ToString();
                    txtNhaCungCap.Text = row.Cells[4].Value.ToString();
                    dtNgayNhap.Text = row.Cells[5].Value.ToString();
                    txtTongTien.Text = row.Cells[6].Value.ToString();
                    ChiTietHoaDonNhapModel chiTietHoaDonNhapLoad = new ChiTietHoaDonNhapModel(int.Parse(row.Cells[0].Value.ToString()));
                    viewChiTietHoaDonNhap.DataSource = chiTietHoaDonNhapLoad.LayChiTietHoaDonNhap();
                    viewChiTietHoaDonNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void viewHoaDonNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewHoaDonNhap.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    string SoHDN = row.Cells[0].Value.ToString();
                    if (!string.IsNullOrEmpty(SoHDN))
                    {
                        DialogResult result = MessageBox.Show("Xóa mã nhập hàng: " + SoHDN + " ?", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            ChiTietHoaDonNhapModel chiTietHoaDon_Xoa = new ChiTietHoaDonNhapModel(int.Parse(SoHDN));
                            chiTietHoaDon_Xoa.XoaChiTietHoaDonNhap();
                            chiTietHoaDon_Xoa.XoaHoaDonNhap();
                            LoadDataGirdView();
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
        public void CapNhatSauKhiHuy()
        {

            int soLuongBanDau = 0;
            int soLuongSauKhiHuyNhap = 0;
            int soLuongHuyNhap = 0;
            int MahangNhap;
            DmhModel dmhModel;

            for (int i = 0; i < viewChiTietHoaDonNhap.RowCount - 1; i++)
            {
                DataGridViewRow row = viewChiTietHoaDonNhap.Rows[i];
                MahangNhap = int.Parse(row.Cells[0].Value.ToString());
                dmhModel = new DmhModel(MahangNhap);
                soLuongBanDau = dmhModel.LaySoLuongKho();
                soLuongHuyNhap = int.Parse(row.Cells[2].Value.ToString());
                soLuongSauKhiHuyNhap = soLuongBanDau - soLuongHuyNhap;
                dmhModel.CapNhatSoLuong(soLuongSauKhiHuyNhap);
            }
        }
        public void HuyNhapHang()
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hủy nhập hàng " + txtSoHDN.Text + " không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                HoaDonNhapModel hoaDonNhapModel = new HoaDonNhapModel(int.Parse(txtSoHDN.Text));
                CapNhatSauKhiHuy();
                hoaDonNhapModel.HuyNhapHang();
                LoadDataGirdView();
            }
        }
        private void btHuyNhapHang_Click(object sender, EventArgs e)
        {
            HuyNhapHang();
            
        }

        private void LichSuNhapHangForm_Load(object sender, EventArgs e)
        {
            LoadDataGirdView();
        }

        private void ctHuy_Click(object sender, EventArgs e)
        {
            OrderHangHoaForm orderHangHoa = Application.OpenForms["OrderHangHoaForm"] as OrderHangHoaForm;
            if (orderHangHoa != null)
            {
                orderHangHoa.LoadDataGridView();
            }
        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
