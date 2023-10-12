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
using QLCHBX.FormKhachHang;

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
            LoadDataGridView();
        }

        private void btThemvaoDs_Click(object sender, EventArgs e)
        { 
            AddKH addKH = new AddKH();
            addKH.ShowDialog();
            LoadDataGridView();
         
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = viewKhachhang.SelectedRows[0];

            string makhachhang = selectedRow.Cells[0].Value.ToString();

           

            if (!string.IsNullOrEmpty(makhachhang))
            {
                DialogResult result = MessageBox.Show("Xóa Khách hàng có mã: " + makhachhang + " ?", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Khachhang khachhang = new Khachhang();
                    khachhang.XoaKhachHang(makhachhang);
                    LoadDataGridView();
                }
                else
                {
                    return;
                } 
                    
               
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa.");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = viewKhachhang.SelectedRows[0];

            string makhachhang = selectedRow.Cells[0].Value.ToString();

            string tenkhach = selectedRow.Cells[1].Value.ToString();

            string diachi = selectedRow.Cells[2].Value.ToString();

            string sodienthoai = selectedRow.Cells[3].Value.ToString();

            EditKH editKH = new EditKH();
            editKH.MaKhachHang = makhachhang;
            editKH.TenKhachHang = tenkhach;
            editKH.DiaChi = diachi;
            editKH.SoDienThoai = sodienthoai;
            
            editKH.ShowDialog();
            LoadDataGridView();

        }

        private void btIn_Click(object sender, EventArgs e)
        {
            Document doc = new Document();
            string filePath = @"D:\Thong_tin khach_hang\thong_tin_khach_hang.pdf";
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            doc.Open();

            PdfPTable table = new PdfPTable(viewKhachhang.Columns.Count);

            for (int i = 0; i < viewKhachhang.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(viewKhachhang.Columns[i].HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.UNDEFINED, 12, iTextSharp.text.Font.BOLD)));
                table.AddCell(cell);
            }

            iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12);

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

            doc.Add(table);

            doc.Close();

            MessageBox.Show("Đã tạo tệp PDF thành công!");
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

        private void cbChucaidau_TextChanged(object sender, EventArgs e)
        {
            string selectedValue = cbChucaidau.Text;
            TimKiemTheoChuCaiDau(selectedValue);
        }

        private void ptreload_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtquequan_TextChanged(object sender, EventArgs e)
        {
            string selectedValue = txtquequan.Text;
            TimKiemTheoQueQuan(selectedValue);
        }

        private void viewKhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                if (e.RowIndex >= 0 && e.ColumnIndex == 4)
                {
                DataGridViewRow selectedRow = viewKhachhang.SelectedRows[0];

                string makhachhang = selectedRow.Cells[0].Value.ToString();

                string tenkhach = selectedRow.Cells[1].Value.ToString();

                string diachi = selectedRow.Cells[2].Value.ToString();

                string sodienthoai = selectedRow.Cells[3].Value.ToString();

                EditKH editKH = new EditKH();
                editKH.MaKhachHang = makhachhang;
                editKH.TenKhachHang = tenkhach;
                editKH.DiaChi = diachi;
                editKH.SoDienThoai = sodienthoai;

                editKH.ShowDialog();
                LoadDataGridView();
            }

        }
    }
}
