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
    public partial class OrderHangHoaForm : Form
    {
        public OrderHangHoaForm()
        {
            InitializeComponent();
        }
        public void LoadDataGridView()
        {
            HoaDonNhapModel hoaDonNhapLoad = new HoaDonNhapModel();
            viewHoaDonNhap.DataSource = hoaDonNhapLoad.LayDuLieuHoaDonNhapChuaNhap();
            grbChiTietHoaDonNhap.Visible = false;
            NhaCungCapModel nhaCungCapLoad = new NhaCungCapModel(); 
            DataTable dtNhaCungCap = nhaCungCapLoad.LayDanhSachNhaCungCap();
            cbbMaNCC.DataSource = dtNhaCungCap;
            cbbMaNCC.DisplayMember = "TenNCC";
            cbbMaNCC.ValueMember = "MaNCC";

            cbbbNCCNew.DataSource = dtNhaCungCap;
            cbbbNCCNew.DisplayMember = "TenNCC";
            cbbbNCCNew.ValueMember = "MaNCC";

            btNhapHang.Visible = false;
            btSua.Visible = false;
            btCapNhat.Visible = false;
            grbThongTinHoaDonNhap.Visible = false;
        }

        private void OrderHangHoaForm_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        public void LoadClickDataGridView()
        {
            grbThongTinHoaDonNhap.Visible = true;
            lbNCCNew.Visible = false;
            btTaoHoaDonNhap.Visible = false;
            btSua.Visible = true;
            btCapNhat.Visible=true;
            btNhapHang.Visible= true;
        }
        private void viewHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewHoaDonNhap.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    grbThongTinHoaDonNhap.Visible = true;
                    txtSoHDN.Text = row.Cells[0].Value.ToString();
                    txtMaNV.Text = row.Cells[1].Value.ToString();
                    txtTenNhanVien.Text = row.Cells[2].Value.ToString();
                    cbbMaNCC.Text = row.Cells[4].Value.ToString();
                    dtNgayNhap.Text = row.Cells[5].Value.ToString();
                    txtTongTien.Text = row.Cells[6].Value.ToString();
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

        }

        private void btTaoHoaDonNhap_Click(object sender, EventArgs e)
        {

        }

        private void btSua_Click(object sender, EventArgs e)
        {

        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {

        }

        private void btNhapHang_Click(object sender, EventArgs e)
        {

        }
    }
}
