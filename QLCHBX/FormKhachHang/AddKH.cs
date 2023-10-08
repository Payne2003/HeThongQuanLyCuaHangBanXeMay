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
    public partial class AddKH : Form
    {
        private string connectionString = "Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlConnection SqlConnection;
        DataTable tblKhachhang;

        public AddKH()
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
        private void btthem_Click(object sender, EventArgs e)
        {
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

            ThemKhachHang(tenkhachhang,diachi,sodienthoai);

        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }

        private string TaoMaKhachHangKhongTrung()
        {
            Random random = new Random();
            string maKhachHangMoi;

            // Thử tạo mã khách hàng ngẫu nhiên và kiểm tra xem có trùng không
            do
            {
                int randomNumber = random.Next(1, 1000); // Thay đổi khoảng tùy ý
                maKhachHangMoi = "KH" + randomNumber.ToString("D3"); // Định dạng mã theo mong muốn
            } while (KiemTraTonTaiMaKhachHang(maKhachHangMoi)); // Kiểm tra xem mã đã tồn tại chưa

            return maKhachHangMoi;
        }

        // Hàm kiểm tra xem mã khách hàng đã tồn tại trong cơ sở dữ liệu chưa
        private bool KiemTraTonTaiMaKhachHang(string maKhachHang)
        {
            string sql = $"SELECT COUNT(*) FROM KhachHang WHERE MaKhach = '{maKhachHang}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int rowCount = (int)command.ExecuteScalar();
                    return rowCount > 0;
                }
            }
        }

        public void ThemKhachHang(string tenKhach, string diaChi, string soDienThoai)
        {
            try
            {
                Connect();

                // Tạo mã khách hàng ngẫu nhiên
                string maKhachHangMoi = TaoMaKhachHangKhongTrung();
                // Kiểm tra nếu số điện thoại đã tồn tại trong cơ sở dữ liệu
                string checkExistSql = $"SELECT COUNT(*) FROM KhachHang WHERE DienThoai = '{soDienThoai}'";
                using (SqlCommand checkExistCmd = new SqlCommand(checkExistSql, SqlConnection))
                {
                    int count = Convert.ToInt32(checkExistCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại trong cơ sở dữ liệu.");
                        return;
                    }
                }

                // Tiếp tục thêm khách hàng
                string sql = $"INSERT INTO KhachHang (MaKhach, TenKhach, DiaChi, DienThoai) VALUES ('{maKhachHangMoi}', N'{tenKhach}', N'{diaChi}', '{soDienThoai}')";

                if (RunSQL(sql))
                {
                    MessageBox.Show("Thêm khách hàng thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng không thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
            }
            finally
            {
                Disconnect();
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

        private void txtten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho phép nhập chữ số
            }
        }

        private void AddKH_Load(object sender, EventArgs e)
        {

        }
    }
}
