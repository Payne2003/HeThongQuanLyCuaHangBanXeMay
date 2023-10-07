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

namespace QLCHBX.ALLControl
{
    public partial class Signup : UserControl

    {
        private  string connectionString = "Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        public Signup()
        {
            InitializeComponent();
        }

        private void btsignup_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Trim() == string.Empty || txtpassword.Text.Trim() == string.Empty || txtreconfirmpassword.Text.Trim() == string.Empty || txtmanhanvien.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Hãy nhập đủ dữ liệu ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtpassword.Text.Trim() != txtreconfirmpassword.Text.Trim())
            {
                MessageBox.Show("Xác nhận mật khẩu không trùng khớp với mật khẩu. Vui lòng nhập lại mật khẩu và xác nhận mật khẩu.", "Mật khẩu không trùng khớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpassword.Clear();
                txtreconfirmpassword.Clear();
            }
            else
            {
                string username = txtuser.Text.Trim();
                string password = txtpassword.Text.Trim();
                string Id = txtmanhanvien.Text.Trim();
                // Chuỗi kết nối
              

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Tạo câu truy vấn
                    string query = "INSERT INTO TaiKhoan (Username, Password, MaNV) VALUES (@Username, @Password, @ID);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@ID", Id);

                        int count = command.ExecuteNonQuery();

                        if (count > 0)
                        {
                           
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ hoặc mã nhân viên không có.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
     }
}
