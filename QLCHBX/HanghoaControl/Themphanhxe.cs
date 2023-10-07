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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLCHBX.HanghoaControl
{
    public partial class Themphanhxe : UserControl
    {      
        string connectionString = @"Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        public Themphanhxe()
        {
            InitializeComponent();
        }

        private void Thêmphanhxe_Load(object sender, EventArgs e)
        {
        }
        private bool IsMaphanhExists(string Id)
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
        private bool IsTenphanhExists(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Phanhxe WHERE TenPhanh = @TenPhanh";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TenPhanh", name);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {       
            string maphanh = txtma.Text.Trim();
            string tenphanh = txtten.Text.Trim();
            if (txtma.Text.Trim() == string.Empty || txtten.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin vào chỗ trống.", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtma.Text.Trim() == txtten.Text.Trim())
            {
                MessageBox.Show("Tên phanh và mã phanh trùng nhau. Vui lòng nhập lại tên và mã phanh.", "Tên và mã trùng khớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtma.Clear();
                txtten.Clear();
            }
            else if (IsMaphanhExists(maphanh))
            {
                MessageBox.Show("Mã phanh đã tồn tại. Vui lòng Nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtma.Clear();
                return;
            }
            else if (IsTenphanhExists(tenphanh))
            {
                MessageBox.Show("Tên phanh đã tồn tại. Vui lòng Nhập tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtten.Clear();
                return;
            }
            else {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Tạo câu truy vấn
                    string query = "INSERT INTO Phanhxe (MaPhanh, TenPhanh) VALUES (@MaPhanh, @TenPhanh);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaPhanh", maphanh);
                        command.Parameters.AddWithValue("@TenPhanh", tenphanh);

                        int count = command.ExecuteNonQuery();

                        if (count > 0)
                        {
                            MessageBox.Show("Thêm Phanh thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.Visible = false;
        }
    }
}
        
