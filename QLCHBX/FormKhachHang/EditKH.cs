using QLCHBX.ALLControl;
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

namespace QLCHBX.FormKhachHang
{
    public partial class EditKH : Form
    {
        private string connectionString = "Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlConnection SqlConnection;
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public EditKH()
        {
            InitializeComponent();
            txtma.ReadOnly = true;
        }
        public void Connect()
        {
            SqlConnection = new SqlConnection();

            SqlConnection.ConnectionString = connectionString;

            SqlConnection.Open();
        }

        public void Disconnect()
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                SqlConnection.Close();
                SqlConnection.Dispose();
            }
        }
        public bool RunSQL(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Trả về true nếu có hàng bị ảnh hưởng
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return false; // Trả về false nếu có lỗi
                    }
                }
            }
        }


        private void ptminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ptthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void ptmenu_Click(object sender, EventArgs e)
        {

        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string makhach = txtma.Text;
            string tenkhachhang = txtten.Text;
            string diachi = txtdiachi.Text;
            string sodienthoai = txtsodienthoai.Text;
            if (string.IsNullOrWhiteSpace(tenkhachhang))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(diachi))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPhoneNumber(sodienthoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SuaKhachHang(makhach,tenkhachhang, diachi, sodienthoai);
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }
        public void SuaKhachHang(string maKhachHang, string tenKhach, string diaChi, string soDienThoai)
        {
            try
            {
                Connect();

                // Kiểm tra nếu số điện thoại đã tồn tại trong cơ sở dữ liệu ngoại trừ khách hàng đang sửa
                string checkExistSql = $"SELECT COUNT(*) FROM KhachHang WHERE DienThoai = '{soDienThoai}' AND MaKhach != '{maKhachHang}'";
                using (SqlCommand checkExistCmd = new SqlCommand(checkExistSql, SqlConnection))
                {
                    int count = Convert.ToInt32(checkExistCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại trong cơ sở dữ liệu.");
                        return;
                    }
                }

                // Tiếp tục sửa khách hàng
                string sql = $"UPDATE KhachHang SET TenKhach = N'{tenKhach}', DiaChi = N'{diaChi}', DienThoai = '{soDienThoai}' WHERE MaKhach = '{maKhachHang}'";

                if (RunSQL(sql))
                {
                    MessageBox.Show("Sửa khách hàng thành công!");
                }
                else
                {
                    MessageBox.Show("Sửa khách hàng không thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa thông tin khách hàng: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        private void txtten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho phép nhập chữ số
            }
        }

        private void EditKH_Load(object sender, EventArgs e)
        {
            txtma.Text = MaKhachHang;
            txtten.Text = TenKhachHang;
            txtdiachi.Text = DiaChi;
            txtsodienthoai.Text = SoDienThoai;
        }
    }
}
