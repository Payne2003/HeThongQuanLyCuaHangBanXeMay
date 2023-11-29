using QLCHBX.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.FormGiaoDich
{
    public partial class LichSuGia : Form
    {
        byte[] img = null;
        public LichSuGia()
        {
            this.InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }

        public void LoadData()
        {
            DmhModel dmhModel = new DmhModel(int.Parse(lbMaHang.Text));
            viewLichSuGia.DataSource = dmhModel.LayDuLieuLichSuGia();
            lbTenHang.Text = dmhModel.LayTenHang();
        }

        private void viewLichSuGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewLichSuGia.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    lbDonGiaNhap.Text = row.Cells[4].Value.ToString();
                    lbDonGiaBan.Text = row.Cells[5].Value.ToString();
                    dtNgayNhap.Text = row.Cells[3].Value.ToString();

                    object anhValue = row.Cells[2].Value;
                    if (anhValue != null && anhValue != DBNull.Value)
                    {
                        img = (byte[])anhValue;
                    }
                    if (img != null && img.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(img))
                        {
                            try
                            {
                                ptHang.Image = Image.FromStream(ms);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi chuyển đổi hình ảnh: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        return;
                        //MessageBox.Show("Mảng byte hình ảnh không hợp lệ.");
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }
        }

        private void LichSuGia_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
