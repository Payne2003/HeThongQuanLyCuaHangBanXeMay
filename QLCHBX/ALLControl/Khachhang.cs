using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.ALLControl

{
 
    public partial class Khachhang : UserControl
    {
        private string connectionString = "Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlConnection SqlConnection;
        DataTable tblKhachhang;
        public Khachhang()
        {
            InitializeComponent();
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
        public void LoadDataGridView()
        {
            string sql = "SELECT * from KhachHang";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter MyData = new SqlDataAdapter(sql, connection); // Set the connection
                tblKhachhang = new DataTable(); // Initialize the table
                MyData.Fill(tblKhachhang); // Fill the table with data
                viewKhachhang.DataSource = tblKhachhang;
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


        private void Khachhang_Load(object sender, EventArgs e)
        {
            this.khachHangTableAdapter.Fill(this.motorcycle_shop_managerDataSet.KhachHang);
        }

    



        // Sự kiện khi nút "Thêm vào DS" được nhấn
        private void btThemvaoDs_Click(object sender, EventArgs e)
        { 
            
         
        }

        // Sự kiện khi nút "Xóa" được nhấn
        private void btXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = viewKhachhang.SelectedRows[0];

            string makhachhang = selectedRow.Cells[0].Value.ToString();

            if (!string.IsNullOrEmpty(makhachhang))
            {
                XoaKhachHang(makhachhang);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa.");
            }
        }

        // Sự kiện khi nút "Sửa" được nhấn
        private void btSua_Click(object sender, EventArgs e)
        {
          
        }

        private void btIn_Click(object sender, EventArgs e)
        {
            // Tạo một tệp PDF mới
            Document doc = new Document();
            string filePath = @"D:\Thong_tin khach_hang\thong_tin_khach_hang.pdf";
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            // Mở tài liệu để viết
            doc.Open();

            // Tạo một bảng PDF
            PdfPTable table = new PdfPTable(viewKhachhang.Columns.Count);

            // Thêm tiêu đề của cột vào bảng
            for (int i = 0; i < viewKhachhang.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(viewKhachhang.Columns[i].HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.UNDEFINED, 12, iTextSharp.text.Font.BOLD)));
                table.AddCell(cell);
            }

            // Tạo font cho dữ liệu
            iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12);

            // Thêm dữ liệu từ DataGridView vào bảng PDF
            for (int i = 0; i < viewKhachhang.Rows.Count; i++)
            {
                for (int j = 0; j < viewKhachhang.Columns.Count; j++)
                {
                    if (viewKhachhang.Rows[i].Cells[j].Value != null)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(viewKhachhang.Rows[i].Cells[j].Value.ToString(), font));
                        table.AddCell(cell);
                    }
                }
            }

            // Thêm bảng vào tài liệu
            doc.Add(table);

            // Đóng tài liệu
            doc.Close();

            MessageBox.Show("Đã tạo tệp PDF thành công!");
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        public void ThemKhachHang( string tenKhach, string diaChi, string soDienThoai)
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

                LoadDataGridView();
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
        public void XoaKhachHang(string maKhachHang)
        {
            try
            {
                Connect(); // Mở kết nối

                // Tạo câu lệnh SQL để xóa khách hàng theo mã
                string sql = $"DELETE FROM KhachHang WHERE MaKhach = '{maKhachHang}'";

               

                if (RunSQL(sql))
                {
                    MessageBox.Show("Xóa khách hàng thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng không thành công!");

                }



                // Tải lại dữ liệu trong DataGridView sau khi xóa
                LoadDataGridView();
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                Disconnect(); // Ngắt kết nối sau khi hoàn tất thao tác
            }
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

                LoadDataGridView();
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

        // Hàm tạo mã khách hàng ngẫu nhiên không trùng
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

        public void TimKiemKhachHang(string soDienThoai)
        {
            try
            {
                Connect();

                // Sử dụng câu truy vấn SQL để tìm kiếm khách hàng theo số điện thoại
                string sql = $"SELECT * FROM KhachHang WHERE DienThoai LIKE '%{soDienThoai}%'";

                using (SqlCommand cmd = new SqlCommand(sql, SqlConnection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    tblKhachhang = new DataTable();
                    adapter.Fill(tblKhachhang);
                    viewKhachhang.DataSource = tblKhachhang;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        private void cbQuequan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedValue = cbQuequan.SelectedItem.ToString();
            TimKiemTheoQueQuan(selectedValue);
        }

        private void cbChucaidau_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedValue = cbChucaidau.Text;
            TimKiemTheoChuCaiDau(selectedValue);
        }
        public void TimKiemTheoQueQuan(string queQuan)
        {
            try
            {
                Connect();

                // Sử dụng câu truy vấn SQL để tìm kiếm khách hàng theo quê quán
                string sql = $"SELECT * FROM KhachHang WHERE DiaChi LIKE N'%{queQuan}%'";

                using (SqlCommand cmd = new SqlCommand(sql, SqlConnection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    tblKhachhang = new DataTable();
                    adapter.Fill(tblKhachhang);
                    viewKhachhang.DataSource = tblKhachhang;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khách hàng theo quê quán: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }
        public void TimKiemTheoChuCaiDau(string chucaidau)
        {
            try
            {
                Connect();

                // Sử dụng câu truy vấn SQL để tìm kiếm khách hàng theo chữ cái đầu
                string sql = $"SELECT * FROM KhachHang WHERE TenKhach LIKE N'{chucaidau}%'";

                using (SqlCommand cmd = new SqlCommand(sql, SqlConnection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    tblKhachhang = new DataTable();
                    adapter.Fill(tblKhachhang);
                    viewKhachhang.DataSource = tblKhachhang;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khách hàng theo chữ cái đầu: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

  
        private void pttimkiem_Click_1(object sender, EventArgs e)
        {

            string soDienThoai = txtsodienthoai.Text.Trim();

            if (!string.IsNullOrEmpty(soDienThoai))
            {
                TimKiemKhachHang(soDienThoai);
            }
            else
            {
                if (!string.IsNullOrEmpty(soDienThoai))
                {
                    TimKiemKhachHang(soDienThoai);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại để tìm kiếm.");
                }
                LoadDataGridView();
            }
        }
    }
}
