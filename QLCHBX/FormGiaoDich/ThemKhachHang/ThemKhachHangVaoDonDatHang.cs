using iTextSharp.text.xml;
using QLCHBX.ALLControl;
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

namespace QLCHBX.FormGiaoDich.ThemKhachHang
{
    public partial class ThemKhachHangVaoDonDatHang : UserControl
    {
        KhachHangModel khachHang;
        DonDatHangModel donDatHang;
        public ThemKhachHangVaoDonDatHang()
        {
            InitializeComponent();
        }
        public bool KiemTraTextsRong(params string[] texts)
        {
            return texts.Any(string.IsNullOrWhiteSpace);
        }
        public void TimKiem()
        {
            
            if (KiemTraTextsRong(txtSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            {
                donDatHang = new DonDatHangModel(int.Parse(txtSoDDH.Text));
                khachHang = donDatHang.TimKiemKhachHang(txtSearch.Text);
                txtMaKhach.Text = khachHang.MaKhach.ToString();
                txtHoTen.Text = khachHang.TenKhach.ToString();
                txtDiaChi.Text = khachHang.DiaChi.ToString();
                txtSoDienThoai.Text = khachHang.DienThoai.ToString();
            }
        }
        private void btTimKiem_Click(object sender, EventArgs e)
        {
           TimKiem();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            TimKiem();
            if (khachHang == null)
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;     
            }
            else
            {
                donDatHang.CapNhatKhachHang(khachHang.MaKhach);
                GiaoDich giaoDich = Application.OpenForms["GiaoDich"] as GiaoDich;
                if (giaoDich != null)
                {
                    giaoDich.LoadDataGridView();
                }
                MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
