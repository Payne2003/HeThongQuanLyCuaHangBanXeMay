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
        SqlConnection connection;
        string connectionString = @"Data Source=DuyLa;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

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
            LoadCmbMaDC();
            LoadCmbMaTL();
            LoadCmbMaHSX();
            LoadCmbMaMau();
            LoadCmbMaPhanh();
            LoadCmbMaNSX();
            LoadCmbMaTT();
          
        }
        private void LoadCmbMaTL()
        {
            string query = "SELECT MaTheLoai FROM TheLoai";
            table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                adapter.Fill(table);
            }
            cmbMaTL.DisplayMember = "MaTheLoai";
            cmbMaTL.DataSource = table;
        }

        private void LoadCmbMaHSX()
        {
            string query = "SELECT MaHangSX FROM Hangsanxuat";
            table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                adapter.Fill(table);
            }
            cmbMaHSX.DisplayMember = "MaHangSX";
            cmbMaHSX.DataSource = table;
        }
        private void LoadCmbMaMau()
        {
            string query = "SELECT MaMau FROM Mausac";
            table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                adapter.Fill(table);
            }
            cmbMaMau.DisplayMember = "MaMau";
            cmbMaMau.DataSource = table;
        }
        private void LoadCmbMaPhanh()
        {
            string query = "SELECT MaPhanh FROM Phanhxe";
            table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                adapter.Fill(table);
            }
            cmbMaP.DisplayMember = "MaPhanh";
            cmbMaP.DataSource = table;
        }
        private void LoadCmbMaDC()
        {
            string query = "SELECT MaDongCo FROM DongCo";
            table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                adapter.Fill(table);
            }
            cmbMaDC.DisplayMember = "MaDongCo";
            cmbMaDC.DataSource = table;
        }
        private void LoadCmbMaNSX()
        {
            string query = "SELECT MaNuocSX FROM Nuocsanxuat";
            table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                adapter.Fill(table);
            }
            cmbMaNSX.DisplayMember = "MaNuocSX";
            cmbMaNSX.DataSource = table;

        }
        private void LoadCmbMaTT()
        {
            string query = "SELECT MaTinhTrang FROM TinhTrang";
            table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                adapter.Fill(table);
            }
            cmbMaTT.DisplayMember = "MaTinhTrang";
            cmbMaTT.DataSource = table;
        }
        private void EditXe_Load(object sender, EventArgs e)
        {
            txtMaH.Text = MaHang;
            txtTenH.Text = TenHang;
            cmbMaTL.Text = MaTheLoai;
            cmbMaTT.Text = MaTinhTrang;
            cmbMaDC.Text = MaDongCo;
            cmbMaHSX.Text = MaHangSX;
            cmbMaP.Text = MaPhanh;
            cmbMaMau.Text = MaMau;
            cmbMaNSX.Text = MaNuocSX;
            txtNSX.Text = NamSanXuat;
            txtSL.Text = SoLuong;
            txtTime.Text = ThoiGian;
            txtDGN.Text = DonGiaNhap;
            txtDGB.Text = DonGiaBan;
            txtDTBX.Text = DungTichBX;
            
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
                MessageBox.Show("Mảng byte hình ảnh không hợp lệ.");
            }
            // LoadAnh();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            string mah = txtMaH.Text.Trim();
            string tenh = txtTenH.Text.Trim();
           
            string nsx = txtNSX.Text.Trim();
            
           
           
            string dgb = txtDGB.Text.Trim();
           

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
            using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Tạo câu truy vấn
                        string query = "UPDATE Dmh SET TenHang=@TenHang, NamSX=@NamSX, Anh=@Anh,  DonGiaBan=@DonGiaBan WHERE MaHang=@MaHang";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaHang", mah);
                            command.Parameters.AddWithValue("@TenHang", tenh);
                           
                            command.Parameters.AddWithValue("@NamSX", nsx);
                          
                           
                          
                            command.Parameters.AddWithValue("@Anh", imageBytes);
                           
                            command.Parameters.AddWithValue("@DonGiaBan", dgb);
                            


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
    }
}
