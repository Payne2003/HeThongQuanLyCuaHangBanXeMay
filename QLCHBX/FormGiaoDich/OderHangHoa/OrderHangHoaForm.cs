using QLCHBX.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
            lbMaNCC_New.Visible = true;
            //lbMaNCC_New.Text = ((DataRowView)cbbMaNCC.SelectedItem)["MaNCC"].ToString();

            LoadGiaoDien();
        }
        
        public void LoadGiaoDien()
        {
            btNhapHang.Visible = false;
            btSua.Visible = false;
            btCapNhat.Visible = false;
            grbThongTinHoaDonNhap.Visible = false;
            grbThongTinDonMoi.Visible = true;
            btTaoHoaDonNhap.Visible = true;
            txtTongTien.Text = "";
        }
        private void OrderHangHoaForm_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        public void LoadClickDataGridView()
        {
            grbThongTinHoaDonNhap.Visible = true;
            grbThongTinDonMoi.Visible = false;
            lbMaNCC_New.Visible = false;
            btTaoHoaDonNhap.Visible = false;
            btSua.Visible = true;
            btCapNhat.Visible=true;
            btNhapHang.Visible= true;
            grbChiTietHoaDonNhap.Visible = true;
        }
       
        public void SaveData()
        {
            int SoHDN = int.Parse(txtSoHDN.Text);
            int MaNV = int.Parse(txtMaNV.Text);
            DateTime dt = DateTime.Parse(dtNgayNhap.Text);
            int MaNCC = int.Parse(lbMaNCC_CapNhat.Text);
            decimal TongTien = decimal.Parse(txtTongTien.Text);
            lbMaNCC_New.Visible = true;
            lbMaNCC_New.Text = ((DataRowView)cbbMaNCC.SelectedItem)["MaNCC"].ToString();
            HoaDonNhapModel hoaDonNhap_CapNhat = new HoaDonNhapModel(SoHDN, MaNV, dt.Date, MaNCC, TongTien);
            hoaDonNhap_CapNhat.CapNhatHoaDonNhap();
            LoadDataGridView();
        }
        private void viewHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewHoaDonNhap.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    LoadClickDataGridView();
                    txtSoHDN.Text = row.Cells[0].Value.ToString();
                    txtMaNV.Text = row.Cells[1].Value.ToString();
                    txtTenNhanVien.Text = row.Cells[2].Value.ToString();
                    cbbMaNCC.Text = row.Cells[4].Value.ToString();
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
                        DialogResult result = MessageBox.Show("Xóa Khách hàng có mã: " + SoHDN + " ?", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            ChiTietHoaDonNhapModel chiTietHoaDon_Xoa = new ChiTietHoaDonNhapModel(int.Parse(SoHDN));
                            chiTietHoaDon_Xoa.XoaChiTietHoaDonNhap();
                            chiTietHoaDon_Xoa.XoaHoaDonNhap();
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

        private void btTaoHoaDonNhap_Click(object sender, EventArgs e)
        {
            FormNhapHang formNhapHang = new FormNhapHang(int.Parse(txtMaNV.Text),int.Parse(lbMaNCC_New.Text));
            formNhapHang.ShowDialog();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            FormNhapHang formNhapHang = new FormNhapHang(int.Parse(txtSoHDN.Text));
            formNhapHang.ShowDialog();
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btNhapHang_Click(object sender, EventArgs e)
        {

        }

        private void cbbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaNCC.SelectedItem != null)
            {
                if (cbbMaNCC.SelectedItem is DataRowView)
                {
                    string maNCC = ((DataRowView)cbbMaNCC.SelectedItem)["MaNCC"].ToString();
                    lbMaNCC_CapNhat.Text = maNCC;
                }
                else
                {
                    lbMaNCC_CapNhat.Text = "";
                }
            }
            else
            {
                lbMaNCC_CapNhat.Text = "";
            }
        }

        private void cbbbNCCNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbbNCCNew.SelectedItem != null)
            {
                if (cbbbNCCNew.SelectedItem is DataRowView)
                {
                    string maNCC = ((DataRowView)cbbbNCCNew.SelectedItem)["MaNCC"].ToString();
                    lbMaNCC_New.Text = maNCC;
                }
                else
                {
                    lbMaNCC_New.Text = "";
                }
            }
            else
            {
                lbMaNCC_New.Text = "";
            }
        }
    }
}

