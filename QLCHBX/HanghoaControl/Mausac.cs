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
    public partial class Mausac : UserControl
    {
        private Dictionary<int, string> originalMaMauValues = new Dictionary<int, string>();
        private Dictionary<int, string> originalTenMauValues = new Dictionary<int, string>();
        SqlConnection connection;
        string connectionString = @"Data Source=DuyLa;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private void loaddata()
        {
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter("Select * From Mausac", connection);
            table = new DataTable();
            adapter.Fill(table);
            dgv1.DataSource = table;
            dgv1.ReadOnly = false;
        }
        public Mausac()
        {
            InitializeComponent();
            loaddata();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            
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
        private bool IsMaMauDmhExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Dmh WHERE MaMau = @MaMau";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaMau", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool IsTenMauExists(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Mausac WHERE TenMau = @TenMau";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TenMau", name);
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
        private void DeleteRowFromDatabase(string maMau)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Mausac WHERE MaMau = @MaMau";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaMau", maMau);
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
                    DataGridViewRow selectedRow = dgv1.SelectedRows[0];
                    string maMau = selectedRow.Cells["MaMau"].Value.ToString();
                    if (IsMaMauDmhExists(maMau))
                    {
                        MessageBox.Show("Mã màu này đang tồn tại trong Dmh. Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //DeleteRowFromDatabase (maMau);
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
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv1.Columns["MaMau"].Index)
            {
                string newMaMau = dgv1.Rows[e.RowIndex].Cells["MaMau"].Value?.ToString();
                // Kiểm tra mã mới có tồn tại trong bảng không
                if (IsMaMauExists(newMaMau))
                {
                    MessageBox.Show("Mã màu đã tồn tại trong bảng.", "Thông báo");
                    // Thực hiện xử lý khi mã mới đã tồn tại, ví dụ: xóa giá trị hoặc thực hiện hành động khác.
                    dgv1.Rows[e.RowIndex].Cells["MaMau"].Value = originalMaMauValues[e.RowIndex];
                }
                else
                {
                    // Cập nhật giá trị ban đầu nếu mã mới không trùng
                    originalMaMauValues[e.RowIndex] = newMaMau;
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv1.Columns["TenMau"].Index)
            {
                string newTenMau = dgv1.Rows[e.RowIndex].Cells["TenMau"].Value?.ToString();
                // Kiểm tra mã mới có tồn tại trong bảng không
                if (IsTenMauExists(newTenMau))
                {
                    MessageBox.Show("Tên màu đã tồn tại trong bảng.", "Thông báo");
                    // Thực hiện xử lý khi mã mới đã tồn tại, ví dụ: xóa giá trị hoặc thực hiện hành động khác.
                    dgv1.Rows[e.RowIndex].Cells["TenMau"].Value = originalTenMauValues[e.RowIndex];
                }
                else
                {
                    // Cập nhật giá trị ban đầu nếu mã mới không trùng
                    originalTenMauValues[e.RowIndex] = newTenMau;
                }
            }
        }
        private void Mausac_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                string maMau = dgv1.Rows[i].Cells["MaMau"].Value?.ToString();
                originalMaMauValues[i] = maMau;
                string tenMau = dgv1.Rows[i].Cells["TenMau"].Value?.ToString();
                originalTenMauValues[i] = tenMau;
            }
        }
    }
}
