using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QLCHBX.HanghoaControl
{
    public partial class Phanh : UserControl
    {
        private Dictionary<int, string> originalMaPhanhValues = new Dictionary<int, string>();
        private Dictionary<int, string> originalTenPhanhValues = new Dictionary<int, string>();
        SqlConnection connection;       
        string connectionString = @"Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private void loaddata()
        {          
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter("Select * From Phanhxe",connection);       
            table = new DataTable();
            adapter.Fill(table);
            dgv1.DataSource = table;
            dgv1.ReadOnly = false;          
        }     
        public Phanh()
        {
            InitializeComponent();
            themphanhxe1.Visible = false;
            loaddata();
        }
      
        
        private void btnthem_Click(object sender, EventArgs e)
        {          
            //themphanhxe1.Visible = true;
                      
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
        private bool IsMaphanhDmhExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Dmh WHERE MaPhanh = @MaPhanh";
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
        private void btnload_Click(object sender, EventArgs e)
        {
           // loaddata();
            try
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Update(table);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteRowFromDatabase(string maPhanh)
        {
            try
            {             
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Phanhxe WHERE MaPhanh = @MaPhanh";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaPhanh", maPhanh);
                    int rowsAffected = command.ExecuteNonQuery();                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dòng từ cơ sở dữ liệu: " + ex.Message);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dgv1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    // Lấy dòng đã chọn
                    DataGridViewRow selectedRow = dgv1.SelectedRows[0];
                    string maPhanh = selectedRow.Cells["MaPhanh"].Value.ToString();
                    if (IsMaphanhDmhExists(maPhanh))
                    {
                        MessageBox.Show("Mã phanh này đang tồn tại trong Dmh. Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //DeleteRowFromDatabase (maPhanh);
                        dgv1.Rows.Remove(selectedRow);
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                  
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void dgv1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv1.Columns["MaPhanh"].Index)
            {
                string newMaPhanh = dgv1.Rows[e.RowIndex].Cells["MaPhanh"].Value?.ToString();
                // Kiểm tra mã mới có tồn tại trong bảng không
                if (IsMaphanhExists(newMaPhanh))
                {
                    MessageBox.Show("Mã Phanh đã tồn tại trong bảng.","Thông báo");
                    // Thực hiện xử lý khi mã mới đã tồn tại, ví dụ: xóa giá trị hoặc thực hiện hành động khác.
                    dgv1.Rows[e.RowIndex].Cells["MaPhanh"].Value = originalMaPhanhValues[e.RowIndex];
                }
                else
                {
                    // Cập nhật giá trị ban đầu nếu mã mới không trùng
                    originalMaPhanhValues[e.RowIndex] = newMaPhanh;
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv1.Columns["TenPhanh"].Index)
            {
                string newTenPhanh = dgv1.Rows[e.RowIndex].Cells["TenPhanh"].Value?.ToString();
                // Kiểm tra mã mới có tồn tại trong bảng không
                if (IsTenphanhExists(newTenPhanh))
                {
                    MessageBox.Show("Tên Phanh đã tồn tại trong bảng.","Thông báo");
                    // Thực hiện xử lý khi mã mới đã tồn tại, ví dụ: xóa giá trị hoặc thực hiện hành động khác.
                    dgv1.Rows[e.RowIndex].Cells["TenPhanh"].Value = originalTenPhanhValues[e.RowIndex];
                }
                else
                {
                    // Cập nhật giá trị ban đầu nếu mã mới không trùng
                    originalTenPhanhValues[e.RowIndex] = newTenPhanh;
                }
            }

        }

        private void Phanh_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                string maPhanh = dgv1.Rows[i].Cells["MaPhanh"].Value?.ToString();
                originalMaPhanhValues[i] = maPhanh;
                string tenPhanh = dgv1.Rows[i].Cells["TenPhanh"].Value?.ToString();
                originalTenPhanhValues[i] = tenPhanh;
            }
        }

        private void dgv1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }      
    }
}
