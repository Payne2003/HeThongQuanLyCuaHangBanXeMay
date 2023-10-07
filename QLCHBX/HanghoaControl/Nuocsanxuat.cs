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
    public partial class Nuocsanxuat : UserControl
    {
        private Dictionary<int, string> originalMaNSXValues = new Dictionary<int, string>();
        private Dictionary<int, string> originalTenNSXValues = new Dictionary<int, string>();
        SqlConnection connection;
        string connectionString = @"Data Source=DuyLa;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private void loaddata()
        {
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter("Select * From Nuocsanxuat", connection);
            table = new DataTable();
            adapter.Fill(table);
            dgv1.DataSource = table;
            dgv1.ReadOnly = false;
        }
        public Nuocsanxuat()
        {
            InitializeComponent();
            loaddata();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

        }
        private bool IsMaNSXExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Nuocsanxuat WHERE MaNuocsx = @MaNuocsx";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Manuocsx", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool IsMaNSXDmhExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Dmh WHERE MaNuocsx = @MaNuocsx";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Manuocsx", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool IsTenNSXExists(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Nuocsanxuat WHERE Tennuocsx = @Tennuocsx";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Tennuocsx", name);
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
        private void DeleteRowFromDatabase(string maNSX)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Nuocsanxuat WHERE MaNuocSX = @MaNuocSX";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaNuocSX", maNSX);
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
                    string maNSX = selectedRow.Cells["MaNuocSX"].Value.ToString();
                    if (IsMaNSXDmhExists(maNSX))
                    {
                        MessageBox.Show("Mã nước sản xuất này đang tồn tại trong Dmh. Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //DeleteRowFromDatabase (maNSX);
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
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv1.Columns["Manuocsx"].Index)
            {
                string newMaNSX = dgv1.Rows[e.RowIndex].Cells["Manuocsx"].Value?.ToString();
                // Kiểm tra mã mới có tồn tại trong bảng không
                if (IsMaNSXExists(newMaNSX))
                {
                    MessageBox.Show("Mã nước sản xuất đã tồn tại trong bảng.", "Thông báo");
                    // Thực hiện xử lý khi mã mới đã tồn tại, ví dụ: xóa giá trị hoặc thực hiện hành động khác.
                    dgv1.Rows[e.RowIndex].Cells["Manuocsx"].Value = originalMaNSXValues[e.RowIndex];
                }
                else
                {
                    // Cập nhật giá trị ban đầu nếu mã mới không trùng
                    originalMaNSXValues[e.RowIndex] = newMaNSX;
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv1.Columns["Tennuocsx"].Index)
            {
                string newTenNSX = dgv1.Rows[e.RowIndex].Cells["Tennuocsx"].Value?.ToString();
                // Kiểm tra mã mới có tồn tại trong bảng không
                if (IsTenNSXExists(newTenNSX))
                {
                    MessageBox.Show("Tên nước sản xuất đã tồn tại trong bảng.", "Thông báo");
                    // Thực hiện xử lý khi mã mới đã tồn tại, ví dụ: xóa giá trị hoặc thực hiện hành động khác.
                    dgv1.Rows[e.RowIndex].Cells["Tennuocsx"].Value = originalTenNSXValues[e.RowIndex];
                }
                else
                {
                    // Cập nhật giá trị ban đầu nếu mã mới không trùng
                    originalTenNSXValues[e.RowIndex] = newTenNSX;
                }
            }
        }

        private void Nuocsanxuat_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                string maNSX = dgv1.Rows[i].Cells["Manuocsx"].Value?.ToString();
                originalMaNSXValues[i] = maNSX;
                string tenNSX = dgv1.Rows[i].Cells["Tennuocsx"].Value?.ToString();
                originalTenNSXValues[i] = tenNSX;
            }
        }
    }
}
