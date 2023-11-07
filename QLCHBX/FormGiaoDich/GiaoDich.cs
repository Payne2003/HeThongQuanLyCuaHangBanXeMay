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
            ChiTietDonDatHangModel chiTietDonDatHangLoad = new ChiTietDonDatHangModel();
            viewChiTietDonHang.DataSource = chiTietDonDatHangLoad.LayDuLieuCuaHoaDon();
            int k = viewChiTietDonHang.RowCount - 1;
            if (k == 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < viewChiTietDonHang.RowCount - 1; i++)
                {
                    DataGridViewRow row = viewChiTietDonHang.Rows[i];
                    tongtien_ChuaThue += decimal.Parse(row.Cells[5].Value.ToString());
                }
            }

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
            }
        }

        private void GiaoDich_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            time_1.Text = DateTime.Now.ToString("HH:mm");
            if (!KiemTraTextsRong(txtSoDDH.Text,txtMaNV.Text))
            {
                return;
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
            DonDatHangModel donDatHang_CapNhat = new DonDatHangModel();
            donDatHang_CapNhat.CapNhatDonDatHang(int.Parse(txtSoDDH.Text), DateTime.Parse(dtNgayNhap.Text), decimal.Parse(txtThue.Text), decimal.Parse(txtDatCoc.Text),decimal.Parse(lbTongtien.Text));
        }

        private void viewChiTietDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewChiTietDonHang.Rows[e.RowIndex];
                if (row.Cells[0].Value != null || row.Cells[0].Value.ToString() != "")
                {
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
                    return;

                }


            }

        }

        private void txtThue_TextChanged(object sender, EventArgs e)
        {
            if(KiemTraTextsRong(txtThue.Text,txtDatCoc.Text))
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
            if (KiemTraTextsRong(txtThue.Text, txtDatCoc.Text))
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
                    LoadDataGridView();
                    decimal TongTien = tongtien_ChuaThue + (decimal.Parse(txtThue.Text) / 100) * tongtien_ChuaThue;
                    lbTongtien.Text = TongTien.ToString();
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
    }
}
