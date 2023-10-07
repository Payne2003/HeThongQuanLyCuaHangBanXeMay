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
    public partial class Tinhtrang : UserControl
    {
        private Dictionary<int, string> originalMaTTValues = new Dictionary<int, string>();
        private Dictionary<int, string> originalTenTTValues = new Dictionary<int, string>();
        SqlConnection connection;
        string connectionString = @"Data Source=DuyLa;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private void loaddata()
        {
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter("Select * From Tinhtrang", connection);
            table = new DataTable();
            adapter.Fill(table);
            dgv1.DataSource = table;
            dgv1.ReadOnly = false;
        }
        public Tinhtrang()
        {
            InitializeComponent();
            loaddata();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {

        }
        private bool IsMaTTExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM TinhTrang WHERE MaTinhTrang = @MaTinhTrang";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaTinhTrang", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool IsMaTTDmhExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Dmh WHERE MaTinhTrang = @MaTinhTrang";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaTinhTrang", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool IsTenTTExists(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM TinhTrang WHERE TenTinhTrang = @TenTinhTrang";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TenTinhTrang", name);
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
        private void DeleteRowFromDatabase(string maTT)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM TinhTrang WHERE MaTinhTrang = @MaTinhTrang";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTinhTrang", maTT);
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
                    string maTT = selectedRow.Cells["MaTinhTrang"].Value.ToString();
                    if (IsMaTTDmhExists(maTT))
                    {
                        MessageBox.Show("Mã tình trạng này đang tồn tại trong Dmh. Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //DeleteRowFromDatabase (maTT);
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
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv1.Columns["MaTinhTrang"].Index)
            {
                string newMaTT = dgv1.Rows[e.RowIndex].Cells["MaTinhTrang"].Value?.ToString();
                // Kiểm tra mã mới có tồn tại trong bảng không
                if (IsMaTTExists(newMaTT))
                {
                    MessageBox.Show("Mã tình trạng đã tồn tại trong bảng.", "Thông báo");
                    // Thực hiện xử lý khi mã mới đã tồn tại, ví dụ: xóa giá trị hoặc thực hiện hành động khác.
                    dgv1.Rows[e.RowIndex].Cells["MaTinhTrang"].Value = originalMaTTValues[e.RowIndex];
                }
                else
                {
                    // Cập nhật giá trị ban đầu nếu mã mới không trùng
                    originalMaTTValues[e.RowIndex] = newMaTT;
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv1.Columns["TenTinhTrang"].Index)
            {
                string newTenPhanh = dgv1.Rows[e.RowIndex].Cells["TenTinhTrang"].Value?.ToString();
                // Kiểm tra mã mới có tồn tại trong bảng không
                if (IsTenTTExists(newTenPhanh))
                {
                    MessageBox.Show("Tên tình trạng đã tồn tại trong bảng.", "Thông báo");
                    // Thực hiện xử lý khi mã mới đã tồn tại, ví dụ: xóa giá trị hoặc thực hiện hành động khác.
                    dgv1.Rows[e.RowIndex].Cells["TenTinhTrang"].Value = originalTenTTValues[e.RowIndex];
                }
                else
                {
                    // Cập nhật giá trị ban đầu nếu mã mới không trùng
                    originalTenTTValues[e.RowIndex] = newTenPhanh;
                }
            }
        }

        private void Tinhtrang_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                string maTT = dgv1.Rows[i].Cells["MaTinhtrang"].Value?.ToString();
                originalMaTTValues[i] = maTT;
                string tenTT = dgv1.Rows[i].Cells["TenTinhTrang"].Value?.ToString();
                originalTenTTValues[i] = tenTT;
            }
        }
    }
}
