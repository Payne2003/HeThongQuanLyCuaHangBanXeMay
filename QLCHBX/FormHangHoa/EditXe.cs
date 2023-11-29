using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.FormHangHoa
{
    public partial class EditXe : Form
    {
        ProcessDatabase dtBase = new ProcessDatabase();
        ChucNang function = new ChucNang();
        SqlConnection connection;
        string connectionString = @"Data Source=DESKTOP-L935296;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private int h = 1;

        public string MaHang { get; set; }
        public string TenHang {  get; set; }
        public string MaTheLoai { get; set; }
        public string MaHangSX { get; set; }
        public string MaMau { get; set; }
        public string NamSanXuat { get; set; }
        public string MaDongCo { get; set; }
        public string MaPhanh { get; set; }
        public string MaNuocSX { get; set; }
        public string MaTinhTrang { get; set; }
        public string SoLuong { get; set; }
        public string ThoiGian { get; set; }
        public string DungTichBX { get; set; }
        public string DonGiaNhap { get; set; }
        public string DonGiaBan { get; set; }
        public byte[] img { get; set; }
        public EditXe()
        {
            InitializeComponent();
            DataTable dtDC = dtBase.DocBang("select * from DongCo");
            function.FillComboBox(cmbMaDC, dtDC, "TenDongCo", "MaDongCo");

            DataTable dtP = dtBase.DocBang("select * from Phanhxe");
            function.FillComboBox(cmbMaP, dtP, "TenPhanh", "MaPhanh");

            DataTable dtHSX = dtBase.DocBang("select * from HangSanXuat");
            function.FillComboBox(cmbMaHSX, dtHSX, "TenHangSX", "MaHangSX");

            DataTable dtTL = dtBase.DocBang("select * from TheLoai");
            function.FillComboBox(cmbMaTL, dtTL, "TenTheLoai", "MaTheLoai");

            DataTable dtNSX = dtBase.DocBang("select * from NuocSanXuat");
            function.FillComboBox(cmbMaNSX, dtNSX, "TenNuocSX", "MaNuocSX");

            DataTable dtTT = dtBase.DocBang("select * from TinhTrang");
            function.FillComboBox(cmbMaTT, dtTT, "TenTinhTrang", "MaTinhTrang");

            DataTable dtMau = dtBase.DocBang("select * from Mausac");
            function.FillComboBox(cmbMaMau, dtMau, "TenMau", "MaMau");

        }       
        private void EditXe_Load(object sender, EventArgs e)
        {
            txtMaH.Text = MaHang;
            txtTenH.Text = TenHang;
            txtNSX.Text = NamSanXuat;
            txtSL.Text = SoLuong;
            txtTime.Text = ThoiGian;
            txtDGN.Text = DonGiaNhap;
            txtDGB.Text = DonGiaBan;           
            
            if (img != null && img.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(img))
                {
                    try
                    {
                        ptb1.Image = Image.FromStream(ms);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi chuyển đổi hình ảnh: " + ex.Message);
                    }
                }
            }
            else
            {

            }
        }
        private bool kiemtradl1()
        {
            if (txtTenH.Text.Trim() == string.Empty || txtNSX.Text.Trim() == string.Empty || txtSL.Text.Trim() == string.Empty || txtDGN.Text.Trim() == string.Empty || txtdtbx.Text.Trim() == string.Empty || txtDGB.Text.Trim() == string.Empty)
                return false;
            return true;
        }
        private bool kiemtradl2()
        {
            if (txtTenH.Text.Trim() == string.Empty || txtNSX.Text.Trim() == string.Empty || txtSL.Text.Trim() == string.Empty || txtDGN.Text.Trim() == string.Empty || txtDGB.Text.Trim() == string.Empty)
                return false;
            return true;
        }

        private void btLuu_Click(object sender, EventArgs e)
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
            if (ptb1.Image != null && (previousImage == null || !ImageEquals(ptb1.Image, previousImage)))
            {
                isNewImageSelected = true;
                // Chuyển đổi hình ảnh thành mảng byte

                using (MemoryStream ms = new MemoryStream())
                {
                    ptb1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Thay đổi định dạng hình ảnh nếu cần
                    imageBytes = ms.ToArray();
                }
            }
            else
            {
                // Sử dụng mảng byte của ảnh cũ
                imageBytes = img;
            }
            if (h == 1)
                {
                    if (kiemtradl1() == false)
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin vào chỗ trống.", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                int mah = int.Parse(txtMaH.Text);
                string tenh = txtTenH.Text.Trim();
                string nsx = txtNSX.Text.Trim();
                int sl = int.Parse(txtSL.Text);
                decimal dgb = decimal.Parse(txtDGB.Text);
                decimal dgn = decimal.Parse(txtDGN.Text);
                decimal dtbx = decimal.Parse(txtdtbx.Text);
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Tạo câu truy vấn
                        string query = "UPDATE Dmh SET TenHang=@TenHang, MaTheLoai=@MaTheLoai, MaHangSX=@MaHangSX, MaMau=@MaMau, MaPhanh=@MaPhanh, MaDongCo=@MaDongCo, MaNuocSX=@MaNuocSX, MaTinhTrang=@MaTinhTrang, NamSX=@NamSX, Anh=CONVERT(varbinary(max), @Anh), DonGiaNhap=@DonGiaNhap,  DonGiaBan=@DonGiaBan, SoLuong=@SoLuong, ThoiGianBaoHanh=@ThoiGianBaoHanh, DungTichBinhXang=@DungTichBinhXang WHERE MaHang=@MaHang";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaHang", mah);
                            command.Parameters.AddWithValue("@TenHang", tenh);
                            command.Parameters.AddWithValue("@MaTheLoai", cmbMaTL.SelectedValue);
                            command.Parameters.AddWithValue("@MaHangSX", cmbMaHSX.SelectedValue);
                            command.Parameters.AddWithValue("@MaMau", cmbMaMau.SelectedValue);
                            command.Parameters.AddWithValue("@NamSX", nsx);
                            command.Parameters.AddWithValue("@MaPhanh", cmbMaP.SelectedValue);
                            command.Parameters.AddWithValue("@MaDongCo", cmbMaDC.SelectedValue);
                            command.Parameters.AddWithValue("@MaNuocSX", cmbMaNSX.SelectedValue);
                            command.Parameters.AddWithValue("@MaTinhTrang", cmbMaTT.SelectedValue);
                            if (imageBytes != null)
                            {
                                command.Parameters.AddWithValue("@Anh", imageBytes);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@Anh", DBNull.Value);
                            }
                            command.Parameters.AddWithValue("@SoLuong", sl);
                            command.Parameters.AddWithValue("@DonGiaBan", dgb);
                            command.Parameters.AddWithValue("@DonGiaNhap", dgn);
                            command.Parameters.AddWithValue("@DungTichBinhXang", dtbx);
                            command.Parameters.AddWithValue("@ThoiGianBaoHanh", txtTime.Text);

                            int count = command.ExecuteNonQuery();

                            if (count > 0)
                            {
                                MessageBox.Show("Dữ liệu đã được cập nhật thành công.");
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Lỗi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                }
                if (h == 2)
                {
                    if (kiemtradl2() == false)
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin vào chỗ trống.", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                int mah = int.Parse(txtMaH.Text);
                string tenh = txtTenH.Text.Trim();
                string nsx = txtNSX.Text.Trim();
                int sl = int.Parse(txtSL.Text);
                decimal dgb = decimal.Parse(txtDGB.Text);
                decimal dgn = decimal.Parse(txtDGN.Text);
                using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Tạo câu truy vấn
                        string query = "UPDATE Dmh SET TenHang=@TenHang, MaTheLoai=@MaTheLoai, MaHangSX=@MaHangSX, MaNuocSX=@MaNuocSX, MaTinhTrang=@MaTinhTrang, NamSX=@NamSX, Anh=@Anh, DonGiaNhap=@DonGiaNhap,  DonGiaBan=@DonGiaBan, SoLuong=@SoLuong, ThoiGianBaoHanh=@ThoiGianBaoHanh WHERE MaHang=@MaHang";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaHang", mah);
                            command.Parameters.AddWithValue("@TenHang", tenh);
                            command.Parameters.AddWithValue("@MaTheLoai", cmbMaTL.SelectedValue);
                            command.Parameters.AddWithValue("@MaHangSX", cmbMaHSX.SelectedValue);
                            command.Parameters.AddWithValue("@NamSX", nsx);
                            command.Parameters.AddWithValue("@MaNuocSX", cmbMaNSX.SelectedValue);
                            command.Parameters.AddWithValue("@MaTinhTrang", cmbMaTT.SelectedValue);
                            command.Parameters.AddWithValue("@Anh", imageBytes);
                            command.Parameters.AddWithValue("@SoLuong", sl);
                            command.Parameters.AddWithValue("@DonGiaBan", dgb);
                            command.Parameters.AddWithValue("@DonGiaNhap", txtDGN.Text);
                            command.Parameters.AddWithValue("@ThoiGianBaoHanh", txtTime.Text);

                            int count = command.ExecuteNonQuery();

                            if (count > 0)
                            {
                                MessageBox.Show("Dữ liệu đã được cập nhật thành công.");
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Lỗi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    }
                }
            }
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

        private void btnmo_Click(object sender, EventArgs e)
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

        private void ptb1_Click(object sender, EventArgs e)
        {

        }

        private void xeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            h = 1;
            HienChiTiet(true);
        }
        private void HienChiTiet(Boolean hien)
        {
            cmbMaP.Visible = hien;
            lbp.Visible = hien;
            cmbMaDC.Visible = hien;
            lbdc.Visible = hien;
            cmbMaMau.Visible = hien;
            lbmau.Visible = hien;
            txtdtbx.Visible = hien;
            lbdtbx.Visible = hien;
        }

        private void độngCơToolStripMenuItem_Click(object sender, EventArgs e)
        {
            h = 2;
            HienChiTiet(false);
        }

        private void phanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            h = 2;
            HienChiTiet(false);
        }
    }
}
