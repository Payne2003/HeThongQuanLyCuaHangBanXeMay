
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLCHBX.FormHangHoa
{
    public partial class AddXe : Form
    {
        ProcessDatabase dtBase = new ProcessDatabase();
        ChucNang function = new ChucNang();
        SqlConnection connection;
        string connectionString = @"Data Source=DuyLa;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private int h = 1;
        public AddXe()
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
        
        private bool kiemtradl()
        {
            if (txtTenH.Text.Trim() == string.Empty || txtNSX.Text.Trim() == string.Empty || txtSL.Text.Trim() == string.Empty || txtDGB.Text.Trim() == string.Empty)
                return false;
            return true;
        }
       

        private void thoat_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void btnmo_Click_1(object sender, EventArgs e)
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

        private void btThem_Click_1(object sender, EventArgs e)
        {
            if (kiemtradl() == false)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin vào chỗ trống.", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {               
                string tenh = txtTenH.Text.Trim();               
                string nsx = txtNSX.Text.Trim();             
                string dtbx = txtdtbx.Text.Trim();             
                int sl = int.Parse(txtSL.Text.Trim());              
                string dgb = txtDGB.Text.Trim();                            
                if (ptb1.Image != null)
                {
                        // Chuyển đổi hình ảnh thành mảng byte
                    byte[] imageBytes;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ptb1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Thay đổi định dạng hình ảnh nếu cần
                        imageBytes = ms.ToArray();
                    }
                    if (h == 1) {
                         using (SqlConnection connection = new SqlConnection(connectionString))
                         {
                             connection.Open();
                             string query = "INSERT INTO Dmh (TenHang, MaTheLoai, MaHangSX, MaMau, NamSX, MaPhanh, MaDongCo, MaNuocSX, MaTinhTrang, Anh, SoLuong, DonGiaBan, DungTichBinhXang) " +
                                 "VALUES (@TenHang, @MaTheLoai, @MaHangSX, @MaMau, @NamSX, @MaPhanh, @MaDongCo, @MaNuocSX, @MaTinhTrang, @Anh, @SoLuong, @DonGiaBan, @DungTichBinhXang)";

                             using (SqlCommand command = new SqlCommand(query, connection))
                             {
                                 command.Parameters.AddWithValue("@TenHang", tenh);
                                 command.Parameters.AddWithValue("@MaTheLoai", cmbMaTL.SelectedValue);
                                 command.Parameters.AddWithValue("@MaHangSX", cmbMaHSX.SelectedValue);
                                 command.Parameters.AddWithValue("@MaMau", cmbMaMau.SelectedValue);
                                 command.Parameters.AddWithValue("@NamSX", nsx);
                                 command.Parameters.AddWithValue("@MaPhanh", cmbMaP.SelectedValue);
                                 command.Parameters.AddWithValue("@MaDongCo", cmbMaDC.SelectedValue);
                                 command.Parameters.AddWithValue("@MaNuocSX", cmbMaNSX.SelectedValue);
                                 command.Parameters.AddWithValue("@MaTinhTrang", cmbMaTT.SelectedValue);
                                 command.Parameters.AddWithValue("@Anh", imageBytes);
                                 command.Parameters.AddWithValue("@SoLuong", sl);
                                 command.Parameters.AddWithValue("@DungTichBinhXang", dtbx);
                                 command.Parameters.AddWithValue("@DonGiaBan", dgb);

                                 int count = command.ExecuteNonQuery();

                                 if (count > 0)
                                 {
                                     MessageBox.Show("Thêm hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                     this.Hide();
                                 }
                                 else
                                 {
                                     MessageBox.Show("Thêm thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 }

                             }
                         }
                        

                    }

                    if (h == 2)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "INSERT INTO Dmh (TenHang, MaTheLoai, MaHangSX,  NamSX, MaNuocSX, MaTinhTrang, Anh, SoLuong, DonGiaBan) " +
                                "VALUES (@TenHang, @MaTheLoai, @MaHangSX, @NamSX, @MaNuocSX, @MaTinhTrang, @Anh, @SoLuong, @DonGiaBan)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@TenHang", tenh);
                                command.Parameters.AddWithValue("@MaTheLoai", cmbMaTL.SelectedValue);
                                command.Parameters.AddWithValue("@MaHangSX", cmbMaHSX.SelectedValue);                              
                                command.Parameters.AddWithValue("@NamSX", nsx);                               
                                command.Parameters.AddWithValue("@MaNuocSX", cmbMaNSX.SelectedValue);
                                command.Parameters.AddWithValue("@MaTinhTrang", cmbMaTT.SelectedValue);
                                command.Parameters.AddWithValue("@Anh", imageBytes);
                                command.Parameters.AddWithValue("@SoLuong", sl);                               
                                command.Parameters.AddWithValue("@DonGiaBan", dgb);

                                int count = command.ExecuteNonQuery();

                                if (count > 0)
                                {
                                    MessageBox.Show("Thêm hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Thêm thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ảnh.","Thông báo");
                }
            }
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void AddXe_Load(object sender, EventArgs e)
        {

        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

		private void xeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
            h = 1;
			HienChiTiet(true);
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
	}
}
