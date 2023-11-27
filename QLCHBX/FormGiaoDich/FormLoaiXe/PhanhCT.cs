﻿using QLCHBX.Model;
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

namespace QLCHBX.FormGiaoDich.FormLoaiXe
{
    public partial class PhanhCT : UserControl
    {
        int MaHang;
        byte[] img = null;
        public PhanhCT()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            PhanhModel phanhModel = new PhanhModel();
            DmhModel dmhModel = new DmhModel();
            txtBanChay.Text = phanhModel.PhanhBanChay();
            viewDmhHang.DataSource = dmhModel.LayDuLieuPhanh();
            DataTable dtPhanh = phanhModel.LayDuLieuPhanhTrongDmh();
            cbPhanh.DataSource = dtPhanh;
            cbPhanh.DisplayMember = "TenPhanh";
            cbPhanh.ValueMember = "MaPhanh";
            btCapnhat.Visible = false;
            ptHang.Image = null;
        }

        private void btChonanh_Click(object sender, EventArgs e)
        {
            string Fname = "";
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Chọn file để mở tệp";
            file.Filter = "All file|*.*";
            file.FilterIndex = 1;
            file.ShowDialog();
            Fname = file.FileName;
            if (string.IsNullOrEmpty(Fname)) { return; }
            Image myImage = Image.FromFile(Fname);
            ptHang.Image = myImage;
        }

        private void btCapnhat_Click(object sender, EventArgs e)
        {
            if (ptHang.Image == null)
            {
                return;
            }
            else
            {
                bool isNewImageSelected = false;
                byte[] imageBytes;
                Image previousImage = null; // Đối tượng Image của ảnh cũ

                // Chuyển đổi mảng byte thành đối tượng Image (ảnh cũ)
                if (img != null && img.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(img))
                    {
                        previousImage = Image.FromStream(ms);
                    }
                }
                if (ptHang.Image != null && (previousImage == null || !ImageEquals(ptHang.Image, previousImage)))
                {
                    isNewImageSelected = true;
                    // Chuyển đổi hình ảnh thành mảng byte

                    using (MemoryStream ms = new MemoryStream())
                    {
                        ptHang.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Thay đổi định dạng hình ảnh nếu cần
                        imageBytes = ms.ToArray();
                    }
                }
                else
                {
                    // Sử dụng mảng byte của ảnh cũ
                    imageBytes = img;
                }
                DialogResult result = MessageBox.Show("Bạn có muốn sửa ảnh của Mã Hàng " + MaHang + " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DmhModel dmhModel = new DmhModel(MaHang);
                    dmhModel.CapNhatAnh(imageBytes);
                    MessageBox.Show("Dữ liệu đã được cập nhật thành công.");
                    LoadData();
                }

            }
        }

        private void viewDmhHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rowDonDatHang = viewDmhHang.Rows[e.RowIndex];
                if (rowDonDatHang.Cells[0].Value != null && rowDonDatHang.Cells[0].Value.ToString() != "")
                {
                    MaHang = int.Parse(rowDonDatHang.Cells[0].Value.ToString());
                    btCapnhat.Visible = true;
                    object anhValue = rowDonDatHang.Cells[7].Value;
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

        private void cbDongCo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPhanh.SelectedItem != null)
            {
                if (cbPhanh.SelectedItem is DataRowView)
                {
                    string ID = ((DataRowView)cbPhanh.SelectedItem)["MaPhanh"].ToString();
                    string tenHang = cbPhanh.Text;
                    lbHang.Text = tenHang;
                    DmhModel dmhModel = new DmhModel();
                    viewDmhHang.DataSource = dmhModel.LayDuLieuPhanhTheoMaPhanh(ID);
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

        private void btHuy_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private bool ImageEquals(Image image1, Image image2)
        {
            if (image1 == null && image2 == null)
            {
                return true;
            }
            else if (image1 == null || image2 == null)
            {
                return false;
            }

            // So sánh kích thước
            if (image1.Width != image2.Width || image1.Height != image2.Height)
            {
                return false;
            }

            return true;
        }

        private void PhanhCT_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
