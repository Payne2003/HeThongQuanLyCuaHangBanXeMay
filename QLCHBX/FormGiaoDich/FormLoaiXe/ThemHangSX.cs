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
    public partial class ThemHangSX : Form
    {
        string fileAnh;
        public ThemHangSX()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }
        private void btChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPEG Image|*.jpg|PNG Image|*.png|All files|*.*";
            openFile.FilterIndex = 1;
            openFile.InitialDirectory = Application.StartupPath;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ptAnh.Image = Image.FromFile(openFile.FileName);
                fileAnh = openFile.FileName; // Lấy đường dẫn của tệp tin đã chọn
                MessageBox.Show(fileAnh);
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            txtTenHangSX.Text = "";
            ptAnh.Image = null;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả từ hộp thoại xác nhận
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn "Yes", thoát khỏi ứng dụng
                this.Close();
            }
            // Nếu người dùng chọn "No", không làm gì cả
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem txtTenHangSX và ptAnh có giá trị không
            if (string.IsNullOrEmpty(txtTenHangSX.Text) || ptAnh.Image == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Tên hãng sản xuất và Ảnh).");
                return; // Dừng việc thực hiện lưu dữ liệu nếu thiếu thông tin
            }

            // Hiển thị hộp thoại xác nhận trước khi lưu
            DialogResult result = MessageBox.Show("Bạn có muốn lưu thông tin Hãng " + txtTenHangSX.Text + " ?", "Xác nhận lưu",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả từ hộp thoại xác nhận
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn "Yes", tiến hành lưu dữ liệu
                HangSanXuatModel hangSanXuatModel = new HangSanXuatModel(txtTenHangSX.Text, fileAnh);
                // Thực hiện các thao tác lưu dữ liệu
                hangSanXuatModel.ThemHangMoi();
                this.Close();
                GiaoDich giaoDich = Application.OpenForms["GiaoDich"] as GiaoDich;
                if (giaoDich != null)
                {
                    giaoDich.xe1.LoadData();
                }
            }
            // Nếu người dùng chọn "No", không làm gì cả và tiếp tục thực hiện các thao tác khác
        }

    }
}
