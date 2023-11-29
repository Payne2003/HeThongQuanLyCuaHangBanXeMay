using QLCHBX.ALLControl;

using QLCHBX.FormHangHoa;
using QLCHBX.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.HanghoaControl
{
    public partial class Dongco : UserControl
    {
        ProcessDatabase dtBase = new ProcessDatabase();
        private HangHoa hangHoaForm;
		string connectionString = "Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
		public HangHoa HangHoaForm
        {
            get { return hangHoaForm; }
            set { hangHoaForm = value; }
        }

        public void Load()
        {           
            btnLuu.Enabled = false;           
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;            
            pn1.Visible = false;            
        }
        public Dongco()
        {
            InitializeComponent();
            DataTable dt = dtBase.DocBang("Select * from DongCo");
            dgv.DataSource = dt;
            Load();
        }      
        public void SetDataGridViewDataSource(DataTable dt)
        {
            dgv.DataSource = dt;
        }       
        private void Dongco_Load(object sender, EventArgs e)
        {
            
        }
		public bool IsMaDongCoExists(string ma)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT COUNT(*) FROM dmh WHERE MaDongCo = @MaDongCo";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@MaDongCo", ma);
					return (int)command.ExecuteScalar() > 0;
				}
			}
		}
		public bool IsMaPhanhExists(string ma)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT COUNT(*) FROM dmh WHERE MaPhanh = @MaPhanh";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@MaPhanh", ma);
					return (int)command.ExecuteScalar() > 0;
				}
			}
		}
		public bool IsMaTheLoaiExists(string ma)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT COUNT(*) FROM dmh WHERE MaTheLoai = @MaTheLoai";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@MaTheLoai", ma);
					return (int)command.ExecuteScalar() > 0;
				}
			}
		}
		public bool IsMaMauExists(string ma)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT COUNT(*) FROM dmh WHERE MaMau = @MaMau";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@MaMau", ma);
					return (int)command.ExecuteScalar() > 0;
				}
			}
		}
		public bool IsMaTTExists(string ma)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT COUNT(*) FROM dmh WHERE MaTinhTrang = @MaTinhTrang";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@MaTinhTrang", ma);
					return (int)command.ExecuteScalar() > 0;
				}
			}
		}
		public bool IsMaHangSXExists(string ma)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT COUNT(*) FROM dmh WHERE MaHangSX = @MaHangSX";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@MaHangSX", ma);
					return (int)command.ExecuteScalar() > 0;
				}
			}
		}
		public bool IsMaNuocSXExists(string ma)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT COUNT(*) FROM dmh WHERE MaNuocSX = @MaNuocSX";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@MaNuocSX", ma);
					return (int)command.ExecuteScalar() > 0;
				}
			}
		}
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    pn1.Visible = true;
                    txtMa.Text = row.Cells[0].Value.ToString();
                    txtTen.Text = row.Cells[1].Value.ToString();
                    btnSua.Enabled = true;
                    btnLuu.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {           
            int d = hangHoaForm.d;
            string ten = txtTen.Text;
            string Ma = txtMa.Text;
            if (ten == "")
            {
                MessageBox.Show("Vui lòng nhập tên");
            }
            else
            {
                if (d == 1)
                {
                    dtBase.CapNhatDuLieu("insert into DongCo values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM DongCo");
                }
                if (d == 2)
                {
                    dtBase.CapNhatDuLieu("insert into PhanhXe values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM PhanhXe");
                }
                if (d == 3)
                {
                    dtBase.CapNhatDuLieu("insert into MauSac values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM MauSac");
                }
                if (d == 4)
                {
                    dtBase.CapNhatDuLieu("insert into TheLoai values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM TheLoai");
                }
                if (d == 5)
                {
                    dtBase.CapNhatDuLieu("insert into TinhTrang values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM TinhTrang");
                }
                if (d == 6)
                {
                    dtBase.CapNhatDuLieu("insert into Hangsanxuat values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                }
                if (d == 7)
                {
                    dtBase.CapNhatDuLieu("insert into Nuocsanxuat values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM Nuocsanxuat");
                }
            }
        }

        

        private void btnSua_Click(object sender, EventArgs e)
        {
            int d = hangHoaForm.d;
            string ten = txtTen.Text;
            string Ma = txtMa.Text;
            if (d == 1)
            {
                if (MessageBox.Show("Bạn có muốn xóa động cơ có mã là:" + Ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtBase.CapNhatDuLieu("update DongCo set TenDongCo = N'" + ten + "' where MaDongCo = '" + Ma + "'");
                    MessageBox.Show("Bạn đã sửa thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM DongCo");
                }
            }
            if (d == 2)
            {
                if (MessageBox.Show("Bạn có muốn xóa phanh có mã là:" + Ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtBase.CapNhatDuLieu("update  PhanhXe set TenPhanh = N'" + ten + "' where MaPhanh = '" + Ma + "'");
                    MessageBox.Show("Bạn đã sửa thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM DongCo");
                }
            }
            if (d == 3)
            {
                if (MessageBox.Show("Bạn có muốn xóa màu sắc có mã là:" + Ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtBase.CapNhatDuLieu("update  MauSac set TenMau = N'" + ten + "' where MaMau = '" + Ma + "'");
                    MessageBox.Show("Bạn đã sửa thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM MauSac");
                }
            }
            if (d == 4)
            {
                if (MessageBox.Show("Bạn có muốn xóa thể loại có mã là:" + Ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtBase.CapNhatDuLieu("update  TheLoai set TenTheLoai = N'" + ten + "' where MaTheLoai = '" + Ma + "'");
                    MessageBox.Show("Bạn đã sửa thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM TheLoai");
                }
            }
            if (d == 5)
            {
                if (MessageBox.Show("Bạn có muốn xóa tình trạng có mã là:" + Ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtBase.CapNhatDuLieu("update  TinhTrang set TenTinhTrang = N'" + ten + "' where MaTinhTrang = '" + Ma + "'");
                    MessageBox.Show("Bạn đã sửa thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM TinhTrang");
                }
            }
            if (d == 6)
            {
                if (MessageBox.Show("Bạn có muốn xóa hãng sẳn xuất có mã là:" + Ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtBase.CapNhatDuLieu("update  Hangsanxuat set TenHangSX = N'" + ten + "' where MaHangSX = '" + Ma + "'");
                    MessageBox.Show("Bạn đã sửa thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM Hangsanxuat");
                }
            }
            if (d == 7)
            {
                if (MessageBox.Show("Bạn có muốn xóa nước sản xuất có mã là:" + Ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtBase.CapNhatDuLieu("update  Nuocsanxuat set TenNuocSX = N'" + ten + "' where MaNuocSX = '" + Ma + "'");
                    MessageBox.Show("Bạn đã sửa thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM Nuocsanxuat");
                }
            }
            txtTen.Text = "";
        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow selectedRow = dgv.SelectedRows[0];
            string ma = selectedRow.Cells[0].Value.ToString();
            int d = hangHoaForm.d;
            if (d == 1)
            {
                if (MessageBox.Show("Bạn có muốn xóa động cơ có mã là:" + ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (IsMaDongCoExists(ma))
                    {
                        MessageBox.Show("Động cơ đang tồi tại trong dmh");
                    }
                    else
                    {
                        dtBase.CapNhatDuLieu("delete DongCo where MaDongCo='" + ma + "'");
                        dgv.DataSource = dtBase.DocBang("SELECT * FROM DongCo");
                        MessageBox.Show("Bạn đã xóa thành công");
                        Load();
                    }
                }
            }
            if (d == 2)
            {
                if (MessageBox.Show("Bạn có muốn xóa phanh có mã là:" + ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (IsMaPhanhExists(ma))
                    {
                        MessageBox.Show("Phanh đang tồi tại trong dmh");
                    }
                    else
                    {
                        dtBase.CapNhatDuLieu("delete PhanhXe where MaPhanh='" + ma + "'");
                        dgv.DataSource = dtBase.DocBang("SELECT * FROM PhanhXe");
                        MessageBox.Show("Bạn đã xóa thành công");
                        Load();
                    }
                }
            }
            if (d == 3)
            {
                if (MessageBox.Show("Bạn có muốn xóa màu có mã là:" + ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (IsMaMauExists(ma))
                    {
                        MessageBox.Show("Màu sắc đang tồi tại trong dmh");
                    }
                    else
                    {
                        dtBase.CapNhatDuLieu("delete MauSac where MaMau='" + ma + "'");
                        dgv.DataSource = dtBase.DocBang("SELECT * FROM MauSac");
                        MessageBox.Show("Bạn đã xóa thành công");
                        Load();
                    }
                }
            }
            if (d == 4)
            {
                if (MessageBox.Show("Bạn có muốn xóa thể loại có mã là:" + ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (IsMaTheLoaiExists(ma))
                    {
                        MessageBox.Show("Thể loại đang tồi tại trong dmh");
                    }
                    else
                    {
                        dtBase.CapNhatDuLieu("delete TheLoai where MaTheLoai='" + ma + "'");
                        dgv.DataSource = dtBase.DocBang("SELECT * FROM TheLoai");
                        MessageBox.Show("Bạn đã xóa thành công");
                        Load();
                    }
                }
            }
            if (d == 5)
            {
                if (MessageBox.Show("Bạn có muốn xóa tình trạng có mã là:" + ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (IsMaTTExists(ma))
                    {
                        MessageBox.Show("Tình trạng đang tồi tại trong dmh");
                    }
                    else
                    {
                        dtBase.CapNhatDuLieu("delete TinhTrang where MaTinhTrang='" + ma + "'");
                        dgv.DataSource = dtBase.DocBang("SELECT * FROM TinhTrang");
                        MessageBox.Show("Bạn đã xóa thành công");
                        Load();
                    }
                }
            }
            if (d == 6)
            {
                if (MessageBox.Show("Bạn có muốn xóa hãng sản xuất có mã là:" + ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (IsMaHangSXExists(ma))
                    {
                        MessageBox.Show("Hãng sản xuất đang tồi tại trong dmh");
                    }
                    else
                    {
                        dtBase.CapNhatDuLieu("delete Hangsanxuat where MaHangSX='" + ma + "'");
                        dgv.DataSource = dtBase.DocBang("SELECT * FROM Hangsanxuat");
                        MessageBox.Show("Bạn đã xóa thành công");
                        Load();
                    }
                }
            }
            if (d == 7)
            {
                if (MessageBox.Show("Bạn có muốn xóa nước sản xuất có mã là:" + ma + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (IsMaNuocSXExists(ma))
                    {
                        MessageBox.Show("Nước sản xuất đang tồi tại trong dmh");
                    }
                    else
                    {
                        dtBase.CapNhatDuLieu("delete Nuocsanxuat where MaNuocSX='" + ma + "'");
                        dgv.DataSource = dtBase.DocBang("SELECT * FROM Nuocsanxuat");
                        MessageBox.Show("Bạn đã xóa thành công");
                        Load();
                    }
                }
            }
        }

        private void btTimKiem_Click_1(object sender, EventArgs e)
        {
            int d = hangHoaForm.d;
            string ten = txtSearch.Text;
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");               
            }
            else
            {
                if (d == 1)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From DongCo where TenDongCo like N'%" + ten + "%'");
                }
                if (d == 2)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From Phanhxe where TenPhanh like N'%" + ten + "%'");
                }
                if (d == 3)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From Mausac where TenMau like N'%" + ten + "%'");
                }
                if (d == 4)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From TheLoai where TenTheLoai like N'%" + ten + "%'");
                }
                if (d == 5)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From TinhTrang where TenTinhTrang like N'%" + ten + "%'");
                }
                if (d == 6)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From Hangsanxxuat where TenHangSX like N'%" + ten + "%'");
                }
                if (d == 7)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From Nuocsanxuat where TenNuocSX like N'%" + ten + "%'");
                }            
            }
        }

        private void txtSsearch_TextChanged(object sender, EventArgs e)
        {
            int d = hangHoaForm.d;
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                if (d == 1)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From DongCo");
                }
                if (d == 2)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From Phanhxe ");
                }
                if (d == 3)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From Mausac ");
                }
                if (d == 4)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From TheLoai ");
                }
                if (d == 5)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From TinhTrang");
                }
                if (d == 6)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From Hangsanxxuat ");
                }
                if (d == 7)
                {
                    dgv.DataSource = dtBase.DocBang("Select * From Nuocsanxuat ");
                }
            }         
        }

       
        private void ptThem_Click(object sender, EventArgs e)
        {
            pn1.Visible = true;
            txtMa.Text = "";
            txtTen.Text = "";
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void ptLoad_Click(object sender, EventArgs e)
        {
            Load();
        }
    }
}
