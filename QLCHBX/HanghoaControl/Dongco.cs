using QLCHBX.ALLControl;

using QLCHBX.FormHangHoa;
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
		string connectionString = "Data Source=DuyLa;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
		public HangHoa HangHoaForm
        {
            get { return hangHoaForm; }
            set { hangHoaForm = value; }
        }
        

        public Dongco()
        {
            InitializeComponent();
            DataTable dt = dtBase.DocBang("Select * from DongCo");
            dgv.DataSource = dt;

        }      
        public void SetDataGridViewDataSource(DataTable dt)
        {
            dgv.DataSource = dt;
        }

        public void btnThem_Click(object sender, EventArgs e)
        { 
            int d = hangHoaForm.d;
            if (d == 1)
            {
                AddPhutung p1 = new AddPhutung(d);
                p1.ShowDialog();
                p1.Text = "AddDongCo";
                dgv.DataSource = dtBase.DocBang("SELECT * FROM DongCo");               
            }
            if (d == 2)
            {
                AddPhutung p1 = new AddPhutung(d);
                p1.ShowDialog();
                p1.Text = "AddPhanh";
                dgv.DataSource = dtBase.DocBang("SELECT * FROM PhanhXe");                
            }
            if (d == 3)
            {
                AddPhutung p1 = new AddPhutung(d);
                p1.ShowDialog();
                p1.Text = "AddMauSac";
                dgv.DataSource = dtBase.DocBang("SELECT * FROM MauSac");                
            }
            if (d == 4)
            {
                AddPhutung p1 = new AddPhutung(d);
                p1.ShowDialog();
                p1.Text = "AddTheLoai";
                dgv.DataSource = dtBase.DocBang("SELECT * FROM TheLoai");               
            }
            if (d == 5)
            {
                AddPhutung p1 = new AddPhutung(d);
                p1.ShowDialog();
                p1.Text = "AddTinhTrang";
                dgv.DataSource = dtBase.DocBang("SELECT * FROM TinhTrang");               
            }
            if (d == 6)
            {
                AddPhutung p1 = new AddPhutung(d);
                p1.ShowDialog();
                p1.Text = "AddHangSanXuat";
                dgv.DataSource = dtBase.DocBang("SELECT * FROM Hangsanxuat");               
            }
            if (d == 7)
            {
                AddPhutung p1 = new AddPhutung(d);
                p1.ShowDialog();
                p1.Text = "AddDongCo";
                dgv.DataSource = dtBase.DocBang("SELECT * FROM Nuocsanxuat");               
            }          
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
		private void btnXoa_Click(object sender, EventArgs e)
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
                    }
                }
            }
            
        }
    }
}
