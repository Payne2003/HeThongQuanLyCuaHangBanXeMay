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
using QLCHBX.Model;

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
                DataGridViewRow row = viewKhachhang.Rows[e.RowIndex]; // Thay thế dataGridView1 bằng tên của DataGridView thực tế của bạn

                string makhachhang = row.Cells[0].Value.ToString();
                string tenkhach = row.Cells[1].Value.ToString();
                string diachi = row.Cells[2].Value.ToString(); // Đổi chỉ mục (index) của cột nếu cần
                string sodienthoai = row.Cells[3].Value.ToString(); // Đổi chỉ mục (index) của cột nếu cần

                EditKH editKH = new EditKH();
                editKH.MaKhachHang = makhachhang;
                editKH.TenKhachHang = tenkhach;
                editKH.DiaChi = diachi;
                editKH.SoDienThoai = sodienthoai;

                editKH.ShowDialog();
                LoadDataGridView();
            }


            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                DataGridViewRow row = viewKhachhang.Rows[e.RowIndex];

                string makhachhang = row.Cells[0].Value.ToString();



                if (!string.IsNullOrEmpty(makhachhang))
                {
                    DialogResult result = MessageBox.Show("Xóa Khách hàng có mã: " + makhachhang + " ?", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        KhachHangModel khachHang = new KhachHangModel();
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
        }
    }
}
