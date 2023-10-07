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
        private Dictionary<int, string> originalMaDongCoValues = new Dictionary<int, string>();
        private Dictionary<int, string> originalTenDongCoValues = new Dictionary<int, string>();
        SqlConnection connection;
        string connectionString = @"Data Source=DuyLa;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddata()
        {
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter("Select * From Dongco", connection);
            table = new DataTable();
            adapter.Fill(table);
            dgv1.DataSource = table;
            dgv1.ReadOnly = false;

        }
        public Dongco()
        {
            InitializeComponent();
            themdongco1.Visible = false;
            loaddata();
        }
        private bool IsMaDongCoExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM DongCo WHERE MaDongCo = @MaDongCo";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaDongCo", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool IsMaDongCoDmhExists(string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Dmh WHERE MaDongCo = @MaDongCo";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaDongCo", Id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool IsTenDongCoExists(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM DongCo WHERE TenDongCo = @TenDongCo";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TenDongCo", name);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void Dongco_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                string maDongCo = dgv1.Rows[i].Cells["MaDongCo"].Value?.ToString();
                originalMaDongCoValues[i] = maDongCo;
                string tenDongCo = dgv1.Rows[i].Cells["TenDongCO"].Value?.ToString();
                originalTenDongCoValues[i] = tenDongCo;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            themdongco1.Visible=true;
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
        private void DeleteRowFromDatabase(string maDongCoToDelete)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM DOngco WHERE MaDongCo = @MaDongCo";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaDongCo", maDongCoToDelete);
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
                // Lấy dòng đã chọn
                DataGridViewRow selectedRow = dgv1.SelectedRows[0];
                // Xóa dòng đã chọn khỏi DataGridView               
                string madc = selectedRow.Cells["MaDongCo"].Value?.ToString();
                if(IsMaDongCoDmhExists(madc)){
                    MessageBox.Show("Mã động cơ này đang tồn tại trong Dmh. Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                   // DeleteRowFromDatabase(madc);
                    dgv1.Rows.Remove(selectedRow);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }
        private void dgv1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv1.Columns["MaDongCo"].Index)
            {
                string newMaDongCo = dgv1.Rows[e.RowIndex].Cells["MaDongCo"].Value?.ToString();
                // Kiểm tra mã mới có tồn tại trong bảng không
                if (IsMaDongCoExists(newMaDongCo))
                {
                    MessageBox.Show("Mã Động cơ đã tồn tại trong bảng.", "Thông báo");
                    // Thực hiện xử lý khi mã mới đã tồn tại, ví dụ: xóa giá trị hoặc thực hiện hành động khác.
                    dgv1.Rows[e.RowIndex].Cells["MaDongCo"].Value = originalMaDongCoValues[e.RowIndex];
                }
                else
                {
                    // Cập nhật giá trị ban đầu nếu mã mới không trùng
                    originalMaDongCoValues[e.RowIndex] = newMaDongCo;
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv1.Columns["TenDongCo"].Index)
            {
                string newTenDongCo = dgv1.Rows[e.RowIndex].Cells["TenDongCo"].Value?.ToString();
                // Kiểm tra mã mới có tồn tại trong bảng không
                if (IsTenDongCoExists(newTenDongCo))
                {
                    MessageBox.Show("Tên Động cơ đã tồn tại trong bảng.", "Thông báo");
                    // Thực hiện xử lý khi mã mới đã tồn tại, ví dụ: xóa giá trị hoặc thực hiện hành động khác.
                    dgv1.Rows[e.RowIndex].Cells["TenDongCo"].Value = originalTenDongCoValues[e.RowIndex];
                }
                else
                {
                    // Cập nhật giá trị ban đầu nếu mã mới không trùng
                    originalTenDongCoValues[e.RowIndex] = newTenDongCo;
                }
            }
        }

       
    }
}
