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
    public partial class Hangsanxuat : UserControl
    {
        private Dictionary<int, string> originalMaHangSXValues = new Dictionary<int, string>();
        private Dictionary<int, string> originalTenHangSXValues = new Dictionary<int, string>();
        SqlConnection connection;
        string connectionString = @"Data Source=DuyLa;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private void loaddata()
        {
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter("Select * From HangSanXuat", connection);
            table = new DataTable();
            adapter.Fill(table);
            dgv1.DataSource = table;
            dgv1.ReadOnly = false;
        }
        public Hangsanxuat()
        {
            InitializeComponent();
            loaddata();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

        }
        private bool IsMaHangSXExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM HangSanXuat WHERE MaHangSX = @MaHangSX";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaHangSX", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool IsMaHangSXDmhExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Dmh WHERE MaHangSX = @MaHangSX";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaHangSX", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool IsTenHangSXExists(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM HangSanXuat WHERE TenHangSX = @TenHangSX";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TenHangSX", name);
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
        private void DeleteRowFromDatabase(string maHSX)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Phanhxe WHERE MaHangSX = @MaHangSX";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHangSX", maHSX);
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
                    string maHSX = selectedRow.Cells["MaHangSX"].Value.ToString();
                    if (IsMaHangSXDmhExists(maHSX))
                    {
                        MessageBox.Show("Mã hãng sản xuất này đang tồn tại trong Dmh. Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //DeleteRowFromDatabase (maHSX);
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
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv1.Columns["MaHangSX"].Index)
            {
                string newMaHSX = dgv1.Rows[e.RowIndex].Cells["MaHangSX"].Value?.ToString();
                // Kiểm tra mã mới có tồn tại trong bảng không
                if (IsMaHangSXExists(newMaHSX))
                {
                    MessageBox.Show("Mã hãng sản xuất đã tồn tại trong bảng.", "Thông báo");
                    // Thực hiện xử lý khi mã mới đã tồn tại, ví dụ: xóa giá trị hoặc thực hiện hành động khác.
                    dgv1.Rows[e.RowIndex].Cells["MaHangSX"].Value = originalMaHangSXValues[e.RowIndex];
                }
                else
                {
                    // Cập nhật giá trị ban đầu nếu mã mới không trùng
                    originalMaHangSXValues[e.RowIndex] = newMaHSX;
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv1.Columns["TenHangSX"].Index)
            {
                string newTenHSX = dgv1.Rows[e.RowIndex].Cells["TenHangSX"].Value?.ToString();
                // Kiểm tra mã mới có tồn tại trong bảng không
                if (IsTenHangSXExists(newTenHSX))
                {
                    MessageBox.Show("Tên hãng sản xuất đã tồn tại trong bảng.", "Thông báo");
                    // Thực hiện xử lý khi mã mới đã tồn tại, ví dụ: xóa giá trị hoặc thực hiện hành động khác.
                    dgv1.Rows[e.RowIndex].Cells["TenHangSX"].Value = originalTenHangSXValues[e.RowIndex];
                }
                else
                {
                    // Cập nhật giá trị ban đầu nếu mã mới không trùng
                    originalTenHangSXValues[e.RowIndex] = newTenHSX;
                }
            }
        }

        private void Hangsanxuat_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                string maHSX = dgv1.Rows[i].Cells["MaHangSX"].Value?.ToString();
                originalMaHangSXValues[i] = maHSX;
                string tenHSX = dgv1.Rows[i].Cells["tenhangSX"].Value?.ToString();
                originalTenHangSXValues[i] = tenHSX;
            }
        }
    }
}
