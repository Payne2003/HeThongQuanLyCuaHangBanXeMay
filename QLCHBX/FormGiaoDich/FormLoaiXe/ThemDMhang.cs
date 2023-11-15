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

namespace QLCHBX.FormGiaoDich.FormLoaiXe
{
    public partial class ThemDMhang : Form
    {
        public ThemDMhang()
        { 
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }
        public void LoadDataGridView(string TenHangSX)
        {
            btThemHangMua.Visible = false;
            DmhModel dmhModel = new DmhModel(); 
            viewDmh.DataSource = dmhModel.LayDuLieuDmhTheoTenHangSX(TenHangSX);
        }
        public void LoadDataGridView()
        {
            btThemHangMua.Visible = false;
            txtGiamGia.Text = "";
            txtMaHang.Text = "";
            txtDonGiaBan.Text = "";
            txtSoLuongHangMua.Text = "1";
            DmhModel dmhModel = new DmhModel();
            viewDmh.DataSource = dmhModel.LayDuLieuDmh();
        }
        private void btthem_Click(object sender, EventArgs e)
        {
            if (KiemTraTextsRong(txtGiamGia.Text))
            {
                txtGiamGia.Text = "0";
            }
            ChiTietDonDatHangModel chiTietDonDatHang_new = new ChiTietDonDatHangModel(int.Parse(txtSoDDH.Text),int.Parse(txtMaHang.Text),int.Parse(txtSoLuongHangMua.Text),decimal.Parse(txtGiamGia.Text));
            if (chiTietDonDatHang_new.KiemTraHangDaNhap())
            {
                MessageBox.Show("Hàng "+txtMaHang.Text+" bạn đã chọn bạn ơi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadDataGridView();
                return;
            }
            else
            {
                if (chiTietDonDatHang_new.ThemMatHangVaoHoaDonMua())
                {
                    MessageBox.Show("Thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thành công");
                }
            }
        }
        private void ttHonDa_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttHonDa.Text);
        }

        private void ThemDMhang_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void ttSYM_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttHonDa.Text);
        }

        private void ttSuzyki_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttSuzyki.Text);
        }

        private void ttYamaHa_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttYamaHa.Text);
        }

        private void ttPiagogio_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttPiagogio.Text);
        }

        private void ttDucaTi_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttDucaTi.Text);
        }

        private void ttKTM_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttKTM.Text);
        }

        private void ttKawasaki_Click(object sender, EventArgs e)
        {
            LoadDataGridView(ttKawasaki.Text);
        }

        private void btcong_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoLuongHangMua.Text, out int currentValue))
            {
                currentValue++;
                txtSoLuongHangMua.Text = currentValue.ToString();
            }
            else
            {
                txtSoLuongHangMua.Text = "1";
            }
        }

        private void bttru_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoLuongHangMua.Text, out int currentValue))
            {
                if (currentValue > 0)
                {
                    currentValue--;
                    txtSoLuongHangMua.Text = currentValue.ToString();
                }
                else
                {
                    txtSoLuongHangMua.Text = "0";
                }
            }
            else
            {
                txtSoLuongHangMua.Text = "0";
            }
        }

        private void viewDmh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 )
            {
                DataGridViewRow row = viewDmh.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    ChiTietDonDatHangModel chiTietDonDatHang = new ChiTietDonDatHangModel(int.Parse(txtSoDDH.Text), int.Parse(row.Cells[0].Value.ToString()));
                    if (chiTietDonDatHang.KiemTraHangDaDuocNhapHayChua())
                    {
                        MessageBox.Show("Đã có Hàng :" + row.Cells[2].Value.ToString() + " !!!", "Xác Nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        btThemHangMua.Visible = true;
                        txtMaHang.Text = row.Cells[0].Value.ToString();
                        txtDonGiaBan.Text = row.Cells[6].Value.ToString();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }


            }

        }
        public bool KiemTraTextsRong(params string[] texts)
        {
            return texts.Any(string.IsNullOrWhiteSpace);
        }
        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (KiemTraTextsRong(txtGiamGia.Text, txtSoLuongHangMua.Text))
            {
                return;
            }
            else
            {
                if (decimal.Parse(txtGiamGia.Text) < 0 || decimal.Parse(txtGiamGia.Text) > 100)
                {
                    MessageBox.Show("0 - 100% thôi nhé bạn ơi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiamGia.Text = "0";
                    return;
                }
                else
                {
                    DmhModel model = new DmhModel(int.Parse(txtMaHang.Text));
                    int soLuongKho = model.LaySoLuongKho();
                    if (int.Parse(txtSoLuongHangMua.Text) > soLuongKho)
                    {
                        MessageBox.Show("Hàng này chỉ còn " + soLuongKho + " thôi bạn ơi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoLuongHangMua.Text = "0";
                        return;
                    }
                    else
                    {
                        decimal thanhTien = decimal.Parse(txtDonGiaBan.Text) * int.Parse(txtSoLuongHangMua.Text) * (1 - decimal.Parse(txtGiamGia.Text) / 100);
                        txtThanhTien.Text = thanhTien.ToString();
                    }
                }
            }
        }
        private void txtSoLuongHangMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtSoLuongHangMua_TextChanged(object sender, EventArgs e)
        {
            if (KiemTraTextsRong(txtGiamGia.Text, txtSoLuongHangMua.Text))
            {
                return;
            }
            else
            {
                if (decimal.Parse(txtGiamGia.Text) < 0 || decimal.Parse(txtGiamGia.Text) > 100)
                {
                    MessageBox.Show("0 - 100% thôi nhé bạn ơi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiamGia.Text = "0";
                    return;
                }
                else
                {
                    DmhModel model = new DmhModel(int.Parse(txtMaHang.Text));
                    int soLuongKho = model.LaySoLuongKho();
                    if (int.Parse(txtSoLuongHangMua.Text) > soLuongKho)
                    {
                        MessageBox.Show("Hàng này chỉ còn " + soLuongKho + " thôi bạn ơi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoLuongHangMua.Text = "0";
                        return;
                    }
                    else
                    {
                        decimal thanhTien = decimal.Parse(txtDonGiaBan.Text) * int.Parse(txtSoLuongHangMua.Text) * (1 - decimal.Parse(txtGiamGia.Text) / 100);
                        txtThanhTien.Text = thanhTien.ToString();
                    }
                }
            }
        }
        private void ThemDMhang_FormClosed(object sender, FormClosedEventArgs e)
        {

            GiaoDich giaoDich = Application.OpenForms["GiaoDich"] as GiaoDich;
            if (giaoDich != null)
            {
                giaoDich.LoadDataGridView();
            }
        }
    }
}

