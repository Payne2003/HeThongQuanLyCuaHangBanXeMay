using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.HanghoaControl
{
    public partial class Themxe : UserControl
    {
        string connectionString = @"Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        public Themxe()
        {
            InitializeComponent();
        }
        private bool IsMaHangExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Dmh WHERE Mahang = @MaHang";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaHang", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool IsMaPhanhExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Phanhxe WHERE MaPhanh = @MaPhanh";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaPhanh", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
       
        private bool IsMaDongCoExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM DongCo WHERE MaDongCo = @MaDongCo";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaDongCo", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
       
        private bool IsMaMauExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Mausac WHERE MaMau = @MaMau";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaMau", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
       
        private bool IsMaLoaiExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Theloai WHERE MaTheLoai = @MaTheLoai";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaTheLoai", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
      
        private bool IsMaTTExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM TinhTrang WHERE MaTinhTrang = @MaTinhTrang";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaTinhTrang", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
      
        private bool IsMaHangSXExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM HangSanXuat WHERE MaHangSX = @MaHangSX";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaHangSX", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
       
        private bool IsMaNSXExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Nuocsanxuat WHERE MaNuocsx = @MaNuocsx";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Manuocsx", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
       

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void btnopen_Click(object sender, EventArgs e)
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
            ptb1.Image = myImage;
        }
        private bool kiemtradl()
        {
            if (txtmah.Text.Trim() == string.Empty || txttenh.Text.Trim() == string.Empty || txtmatl.Text.Trim() == string.Empty
                || txtmahsx.Text.Trim() == string.Empty || txtmamau.Text.Trim() == string.Empty || txtnsx.Text.Trim() == string.Empty
                || txtmap.Text.Trim() == string.Empty || txtmadc.Text.Trim() == string.Empty || txtdtbx.Text.Trim() == string.Empty
                || txtmansx.Text.Trim() == string.Empty || txtmatt.Text.Trim() == string.Empty || txtsl.Text.Trim() == string.Empty
                || txtdgn.Text.Trim() == string.Empty || txtdgb.Text.Trim() == string.Empty || txttg.Text.Trim() == string.Empty)
                return false;
            return true;

        }
        private void btthem_Click(object sender, EventArgs e)
        {
            if (kiemtradl() == false)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin vào chỗ trống.", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string mah = txtmah.Text.Trim();
                string tenh = txttenh.Text.Trim();
                string matl = txtmatl.Text.Trim();
                string mahsx = txtmahsx.Text.Trim();
                string mamau = txtmamau.Text.Trim();
                string nsx = txtnsx.Text.Trim();
                string map = txtmap.Text.Trim();
                string madc = txtmadc.Text.Trim();
                string dtbx = txtdtbx.Text.Trim();
                string mansx = txtmansx.Text.Trim();
                string matt = txtmatt.Text.Trim();
                int sl = int.Parse(txtsl.Text.Trim());
                string dgn = txtdgn.Text.Trim();
                string dgb = txtdgb.Text.Trim();
                int time = int.Parse(txttg.Text.Trim());


                if (IsMaHangExists(mah) == true)
                {
                    MessageBox.Show("Mã hàng này đã có. Vui lòng Nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmah.Clear();
                    return;
                }
                else if (IsMaLoaiExists(matl) == false)
                {
                    MessageBox.Show("Mã thể loại này chưa có. Vui lòng Nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmatl.Clear();
                    return;
                }
                else if (IsMaHangSXExists(mahsx) == false)
                {
                    MessageBox.Show("Mã hãng sản xuất này chưa có. Vui lòng Nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmahsx.Clear();
                    return;
                }
                else if (IsMaMauExists(mamau) == false)
                {
                    MessageBox.Show("Mã màu này chưa có. Vui lòng Nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmamau.Clear();
                    return;
                }
                else if (IsMaPhanhExists(map) == false)
                {
                    MessageBox.Show("Mã phanh này chưa có. Vui lòng Nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmadc.Clear();
                    return;
                }
                else if (IsMaDongCoExists(madc) == false)
                {
                    MessageBox.Show("Mã động cơ này chưa có. Vui lòng Nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmadc.Clear();
                    return;
                }
                else if (IsMaNSXExists(mansx) == false)
                {
                    MessageBox.Show("Mã nước sản xuát này chưa có. Vui lòng Nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmansx.Clear();
                    return;
                }
                else if (IsMaTTExists(matt) == false)
                {
                    MessageBox.Show("Mã tình trạng này chưa có. Vui lòng Nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmatt.Clear();
                    return;
                }
               
                else
                {
                    if (ptb1.Image != null)
                    {
                        // Chuyển đổi hình ảnh thành mảng byte
                        byte[] imageBytes;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            ptb1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Thay đổi định dạng hình ảnh nếu cần
                            imageBytes = ms.ToArray();
                        }
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Tạo câu truy vấn
                            string query = "INSERT INTO Dmh (MaHang, TenHang, MaTheLoai, MaHangSX, MaMau, NamSX, MaPhanh, MaDongCo, DungTichBinhXang, MaNuocSX, MaTinhTrang, Anh, SoLuong, DonGiaNhap, DonGiaBan, ThoiGianBaoHanh) " +
                                "VALUES (@MaHang, @TenHang, @MaTheLoai, @MaHangSX, @MaMau, @NamSX, @MaPhanh, @MaDongCo, @DungTichBinhXang, @MaNuocSX, @MaTinhTrang, @Anh, @SoLuong, @DonGiaNhap, @DonGiaBan, @ThoiGianBaoHanh);";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MaHang", mah);
                                command.Parameters.AddWithValue("@TenHang", tenh);
                                command.Parameters.AddWithValue("@MaTheLoai", matl);
                                command.Parameters.AddWithValue("@MaHangSX", mahsx);
                                command.Parameters.AddWithValue("@MaMau", mamau);
                                command.Parameters.AddWithValue("@NamSX", nsx);
                                command.Parameters.AddWithValue("@MaPhanh", map);
                                command.Parameters.AddWithValue("@MaDongCo", madc);
                                command.Parameters.AddWithValue("@DungTichBinhXang", dtbx);
                                command.Parameters.AddWithValue("@MaNuocSX", mansx);
                                command.Parameters.AddWithValue("@MaTinhTrang", matt);
                                command.Parameters.AddWithValue("@Anh", imageBytes);
                                command.Parameters.AddWithValue("@SoLuong", sl);
                                command.Parameters.AddWithValue("@DonGiaNhap", dgn);
                                command.Parameters.AddWithValue("@DonGiaBan", dgb);
                                command.Parameters.AddWithValue("@ThoiGianBaoHanh", time);


                                int count = command.ExecuteNonQuery();

                                if (count > 0)
                                {
                                    MessageBox.Show("Thêm Xe thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Visible = false;
                                }
                                else
                                {
                                    MessageBox.Show("Thêm thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                        }
                    }
                }
            }
        }

        private void txtsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txttg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
