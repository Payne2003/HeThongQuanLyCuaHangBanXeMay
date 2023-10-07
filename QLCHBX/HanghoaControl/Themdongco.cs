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
using System.Data.SqlClient;

namespace QLCHBX.ALLControl
{
    public partial class Themdongco : UserControl
    {
        string connectionString = @"Data Source=DuyLa;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
       
        public Themdongco()
        {
            InitializeComponent();
        }
        private bool IsMadcExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Dongco WHERE MaDongCo = @MaDongCo";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaDongCo", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool IsTendcExists(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Dongco WHERE TenDongCo = @TenDongCo";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TenDongCo", name);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        
        private void Themdongco_Load(object sender, EventArgs e)
        {
           
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            string madc = txtma.Text.Trim();
            string tendc = txtten.Text.Trim();
            if (txtma.Text.Trim() == string.Empty || txtten.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin vào chỗ trống.", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtma.Text.Trim() == txtten.Text.Trim())
            {
                MessageBox.Show("Tên động cơ và mã động cơ trùng nhau. Vui lòng nhập lại tên và mã động cơ.", "Tên và mã trùng khớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtma.Clear();
                txtten.Clear();
            }          
            else if (IsMadcExists(madc))
            {
                MessageBox.Show("Mã động cơ đã tồn tại. Vui lòng Nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtma.Clear();
                return;
            }
            else if (IsTendcExists(tendc))
            {
                MessageBox.Show("Tên động cơ đã tồn tại. Vui lòng Nhập tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtten.Clear();
                return;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Tạo câu truy vấn
                    string query = "INSERT INTO Dongco (MaDongCo, TenDongCo) VALUES (@MaDongCo, @TenDongCo);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDongCo", madc);
                        command.Parameters.AddWithValue("@TenDongCo", tendc);

                        int count = command.ExecuteNonQuery();

                        if (count > 0)
                        {
                            MessageBox.Show("Thêm Động cơ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        txtma.Text = "";
                        txtten.Text = "";
                    }
                }
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible=false;
        }
    }
}
