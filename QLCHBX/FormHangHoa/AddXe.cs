
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
        SqlConnection connection;
        string connectionString = @"Data Source=DuyLa;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private int h = 1;
        public AddXe()
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
      
        private bool kiemtradl()
        {
            if (txtTenH.Text.Trim() == string.Empty || cmbMaTL.SelectedIndex == -1
                || cmbMaHSX.SelectedIndex == -1 || cmbMaMau.Text.Trim() == string.Empty || txtNSX.Text.Trim() == string.Empty
                || cmbMaP.SelectedIndex == -1 || cmbMaDC.SelectedIndex == -1 
                || cmbMaNSX.SelectedIndex == -1 || cmbMaTT.SelectedIndex == -1 || txtSL.Text.Trim() == string.Empty
                || txtDGB.Text.Trim() == string.Empty)
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
                string matl = cmbMaTL.Text.Trim();
                string mahsx = cmbMaHSX.Text.Trim();
                string mamau = cmbMaMau.Text.Trim();
                string nsx = txtNSX.Text.Trim();
                string map = cmbMaP.Text.Trim();
                string madc = cmbMaDC.Text.Trim();
                
                string mansx = cmbMaNSX.Text.Trim();
                string matt = cmbMaTT.Text.Trim();
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
                  
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "INSERT INTO Dmh (TenHang, MaTheLoai, MaHangSX, MaMau, NamSX, MaPhanh, MaDongCo, MaNuocSX, MaTinhTrang, Anh, SoLuong, DonGiaBan) " +
                                "VALUES (@TenHang, @MaTheLoai, @MaHangSX, @MaMau, @NamSX, @MaPhanh, @MaDongCo, @MaNuocSX, @MaTinhTrang, @Anh, @SoLuong, @DonGiaBan)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {

                                command.Parameters.AddWithValue("@TenHang", tenh);
                                command.Parameters.AddWithValue("@MaTheLoai", matl);
                                command.Parameters.AddWithValue("@MaHangSX", mahsx);
                                command.Parameters.AddWithValue("@MaMau", mamau);
                                command.Parameters.AddWithValue("@NamSX", nsx);
                                command.Parameters.AddWithValue("@MaPhanh", map);
                                command.Parameters.AddWithValue("@MaDongCo", madc);
                                command.Parameters.AddWithValue("@MaNuocSX", mansx);
                                command.Parameters.AddWithValue("@MaTinhTrang", matt);
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
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            this.Close();
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
		}
	}
}
