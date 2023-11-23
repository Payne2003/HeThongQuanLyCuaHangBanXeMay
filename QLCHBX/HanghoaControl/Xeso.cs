using iTextSharp.xmp.impl.xpath;

using QLCHBX.FormHangHoa;
using QLCHBX.FormKhachHang;
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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLCHBX.HanghoaControl
{
    public partial class Xeso : UserControl
    {
        ProcessDatabase dtBase = new ProcessDatabase();
        string connectionString = "Data Source=DuyLa;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
      
        public Xeso()
        {
            InitializeComponent();
            DataTable dt = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh,SoLuong From Dmh");
            dgv.DataSource = dt;
            Load();
        }
        public void Load()
        {
            btThem.Enabled = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns[0].Width = 40;
            pn1.Visible = false;
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            
            
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgv.SelectedRows[0];

            string maHang = selectedRow.Cells["MaHang"].Value.ToString();
            if (MessageBox.Show("Bạn có muốn xóa xe có mã là:" + maHang + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtBase.CapNhatDuLieu("delete Dmh where MaHang='" + maHang + "'");
				MessageBox.Show("Xóa thành công", "Thông báo");
				dgv.DataSource = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh,SoLuong From Dmh");              
            }
        }
        public void SetDataGridViewDataSource(DataTable dt)
        {
            dgv.DataSource = dt;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            AddXe xe = new AddXe();
            xe.ShowDialog();
            dgv.DataSource = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh,SoLuong From Dmh");
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];
                if (selectedRow.Cells[1].Value != null && selectedRow.Cells[1].Value.ToString() != "")
                {
                    pn1.Visible = true;
                    txtTen.Text = selectedRow.Cells[3].Value.ToString();
                    btThem.Enabled = false;
                    int ma = int.Parse(selectedRow.Cells["MaHang"].Value.ToString());
                    string query = "SELECT * FROM Dmh WHERE MaHang = @MaHang"; // Thay "TenBang" bằng tên bảng chứa thông tin
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MaHang", ma);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {                                                
                            string mahsx = reader["MaHangSX"].ToString();                           
                            reader.Close();
                            string qr = @"SELECT HangSanxuat.TenHangSX FROM dmh LEFT JOIN Hangsanxuat ON dmh.MaHangSX = Hangsanxuat.MaHangSX WHERE dmh.MaHangSX = @MaHangSX ";                
                            SqlCommand command2 = new SqlCommand(qr, connection);                           
                            command2.Parameters.AddWithValue("@MaHangSX", mahsx);                           
                            using (SqlDataReader reader2 = command2.ExecuteReader())
                            {
                                if (reader2.Read())
                                {                                 
                                    string tenHangSX = reader2["TenHangSX"].ToString();                                   
                                    txtHSX.Text = tenHangSX;                                  
                                }
                            }
                        }
                        reader.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv.Columns["ChiTiet"].Index)
            {
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];
                
                if (selectedRow.Cells[1].Value != null && selectedRow.Cells[1].Value.ToString() != "")
                {
                    int ma = int.Parse(selectedRow.Cells["MaHang"].Value.ToString());
                    string query = "SELECT * FROM Dmh WHERE MaHang = @MaHang"; // Thay "TenBang" bằng tên bảng chứa thông tin
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MaHang", ma);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        
                        if (reader.Read())
                        {
                            // Lấy thông tin chi tiết từ cột trong bảng
                            string mah = reader["MaHang"].ToString();
                            string tenh = reader["TenHang"].ToString();
                            string matl = reader["MaTheLoai"].ToString();
                            string mahsx = reader["MaHangSX"].ToString();
                            string mamau = reader["MaMau"].ToString();
                            string nsx = reader["NamSX"].ToString();
                            string map = reader["MaPhanh"].ToString();
                            string madc = reader["MaDongCo"].ToString();
                            string dtbx = reader["DungTichBinhXang"].ToString();
                            string mansx = reader["MaNuocSX"].ToString();
                            string matt = reader["MaTinhTrang"].ToString();
                            string sl = reader["SoLuong"].ToString();
                            string dgn = reader["DonGiaNhap"].ToString();
                            string dgb = reader["DonGiaBan"].ToString();
                            string time = reader["ThoiGianBaoHanh"].ToString();
                            byte[] imgPath = null;
                            if (reader["Anh"] != DBNull.Value)
                            {
                                imgPath = (byte[])reader["Anh"];
                            }                           
                            reader.Close();                            
                            if (string.IsNullOrEmpty(map))
                            {
                                string qr = @"SELECT TheLoai.TenTheLoai, HangSanxuat.TenHangSX, Nuocsanxuat.TenNuocSX,TinhTrang.TenTinhTrang
                            FROM  dmh LEFT JOIN TheLoai ON dmh.MaTheLoai = TheLoai.MaTheLoai
                                LEFT JOIN Hangsanxuat ON dmh.MaHangSX = Hangsanxuat.MaHangSX              
                                LEFT JOIN Nuocsanxuat ON dmh.MaNuocSX = Nuocsanxuat.MaNuocSX
                                LEFT JOIN TinhTrang ON dmh.MaTinhTrang = TinhTrang.MaTinhTrang
                                WHERE 
                                    dmh.MaTheLoai = @MaTheLoai AND
                                    dmh.MaHangSX = @MaHangSX AND
                                    dmh.MaNuocSX = @MaNuocSX AND
                                    dmh.MaTinhTrang = @MaTinhTrang ";

                                // Tạo đối tượng SqlCommand và thiết lập tham số
                                SqlCommand command2 = new SqlCommand(qr, connection);
                                command2.Parameters.AddWithValue("@MaTheLoai", matl);
                                command2.Parameters.AddWithValue("@MaHangSX", mahsx);
                                command2.Parameters.AddWithValue("@MaNuocSX", mansx);
                                command2.Parameters.AddWithValue("@MaTinhTrang", matt);

                                using (SqlDataReader reader2 = command2.ExecuteReader())
                                {
                                    if (reader2.Read())
                                    {
                                        string tenTheLoai = reader2["TenTheLoai"].ToString();
                                        string tenHangSX = reader2["TenHangSX"].ToString();         
                                        string tennuocsx = reader2["TenNuocSX"].ToString();
                                        string tinhtrang = reader2["TenTinhTrang"].ToString();
                                        ChiTiet ct = new ChiTiet();
                                        ct.MaHang = mah;
                                        ct.TenHang = tenh;
                                        ct.TenTheLoai = tenTheLoai;
                                        ct.TenHangSX = tenHangSX;                                     
                                        ct.NamSanXuat = nsx;                                                                              
                                        ct.TenNuocSX = tennuocsx;
                                        ct.TenTinhTrang = tinhtrang;
                                        ct.SoLuong = sl;
                                        ct.DonGiaNhap = dgn;
                                        ct.DonGiaBan = dgb;
                                        ct.ThoiGian = time;
                                        ct.img = imgPath;

                                        ct.ShowDialog();
                                    }
                                }
                            }
                            else
                            {
                                string qr = @"SELECT TheLoai.TenTheLoai, HangSanxuat.TenHangSX, MauSac.TenMau, PhanhXe.TenPhanh, DongCo.TenDongCo,Nuocsanxuat.TenNuocSX, TinhTrang.TenTinhTrang
                FROM dmh LEFT JOIN TheLoai ON dmh.MaTheLoai = TheLoai.MaTheLoai
                LEFT JOIN Hangsanxuat ON dmh.MaHangSX = Hangsanxuat.MaHangSX
                LEFT JOIN MauSac ON dmh.MaMau = MauSac.MaMau
                LEFT JOIN PhanhXe ON dmh.MaPhanh = PhanhXe.MaPhanh
                LEFT JOIN DongCo ON dmh.MaDongCo = DongCo.MaDongCo
                LEFT JOIN Nuocsanxuat ON dmh.MaNuocSX = Nuocsanxuat.MaNuocSX
                LEFT JOIN TinhTrang ON dmh.MaTinhTrang = TinhTrang.MaTinhTrang
                WHERE 
                    dmh.MaTheLoai = @MaTheLoai AND
                    dmh.MaHangSX = @MaHangSX AND
                    dmh.MaMau = @MaMau AND              
                    dmh.MaPhanh = @MaPhanh AND
                    dmh.MaDongCo = @MaDongCo AND
                    dmh.MaNuocSX = @MaNuocSX AND
                    dmh.MaTinhTrang = @MaTinhTrang ";
                                // Tạo đối tượng SqlCommand và thiết lập tham số
                                SqlCommand command2 = new SqlCommand(qr, connection);
                                command2.Parameters.AddWithValue("@MaTheLoai", matl);
                                command2.Parameters.AddWithValue("@MaHangSX", mahsx);
                                command2.Parameters.AddWithValue("@MaMau", mamau);

                                command2.Parameters.AddWithValue("@MaPhanh", map);
                                command2.Parameters.AddWithValue("@MaDongCo", madc);
                                command2.Parameters.AddWithValue("@MaNuocSX", mansx);
                                command2.Parameters.AddWithValue("@MaTinhTrang", matt);

                                using (SqlDataReader reader2 = command2.ExecuteReader())
                                {
                                    if (reader2.Read())
                                    {
                                        string tenTheLoai = reader2["TenTheLoai"].ToString();
                                        string tenHangSX = reader2["TenHangSX"].ToString();
                                        string tenMau = reader2["TenMau"].ToString();
                                        string tenPhanh = reader2["TenPhanh"].ToString();
                                        string tenDongCo = reader2["TenDongCo"].ToString();
                                        string tennuocsx = reader2["TenNuocSX"].ToString();
                                        string tinhtrang = reader2["TenTinhTrang"].ToString();
                                        ChiTiet ct = new ChiTiet();
                                        ct.MaHang = mah;
                                        ct.TenHang = tenh;
                                        ct.TenTheLoai = tenTheLoai;
                                        ct.TenHangSX = tenHangSX;
                                        ct.TenMau = tenMau;
                                        ct.NamSanXuat = nsx;
                                        ct.TenPhanh = tenPhanh;
                                        ct.TenDongCo = tenDongCo;
                                        ct.DungTichBX = dtbx;
                                        ct.TenNuocSX = tennuocsx;
                                        ct.TenTinhTrang = tinhtrang;
                                        ct.SoLuong = sl;
                                        ct.DonGiaNhap = dgn;
                                        ct.DonGiaBan = dgb;
                                        ct.ThoiGian = time;
                                        ct.img = imgPath;
                                        ct.ShowDialog();
                                    }
                                }
                            }
                        }
                        reader.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }
        }

        private void ptLoad_Click(object sender, EventArgs e)
        {
            Load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgv.SelectedRows[0];
            string maHang = selectedRow.Cells["MaHang"].Value.ToString();
            string tenHang = selectedRow.Cells["TenHang"].Value.ToString();
            string namSX = selectedRow.Cells["NamSX"].Value.ToString();
            Byte[] imgPath = (Byte[])selectedRow.Cells["Anh"].Value;
            string sl = selectedRow.Cells["SoLuong"].Value.ToString();
            string DGB = selectedRow.Cells["DonGiaBan"].Value.ToString();
            string Time = selectedRow.Cells["ThoiGianBaoHanh"].Value.ToString();

            EditXe edit = new EditXe();
            edit.MaHang = maHang;
            edit.TenHang = tenHang;
            edit.NamSanXuat = namSX;
            edit.SoLuong = sl;
            edit.DonGiaBan = DGB;
            edit.ThoiGian = Time;
            edit.img = imgPath;
            edit.ShowDialog();
            dgv.DataSource = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh,SoLuong From Dmh");
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string ten = txtSearch.Text;
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");               
            }
            else
            {
                dgv.DataSource = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh,SoLuong From Dmh where TenHang like N'%" + ten + "%'");
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgv.SelectedRows[0];

            string maHang = selectedRow.Cells["MaHang"].Value.ToString();
            if (MessageBox.Show("Bạn có muốn xóa xe có mã là:" + maHang + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtBase.CapNhatDuLieu("delete Dmh where MaHang='" + maHang + "'");
                MessageBox.Show("Xóa thành công", "Thông báo");
                dgv.DataSource = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh,SoLuong From Dmh");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                dgv.DataSource = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh,SoLuong From Dmh");
            }
        }

        private void ptexcel_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook =
            exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet =
                (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range tenvung = (Excel.Range)exSheet.Cells[1, 1];
            tenvung.Font.Name = "Arial"; tenvung.Font.Size = 16;
            tenvung.Font.Color = Color.Blue;
            tenvung.Value = "Danh sách Hàng hóa";
            exSheet.get_Range("A1: H1").Merge(true);
            exSheet.get_Range("A2:C2").Font.Size = 8;
            exSheet.get_Range("A2:C2").Font.Bold = true;
            exSheet.get_Range("A2").Value = "STT";
            exSheet.get_Range("B2").Value = "Ảnh";
            exSheet.get_Range("C2").Value = "Mã Hàng";
            exSheet.get_Range("D2").Value = "Tên Hàng";
            exSheet.get_Range("E2").Value = "Năm sản xuất";
            exSheet.get_Range("F2").Value = "Đơn giá bán";
            exSheet.get_Range("G2").Value = "Thời gian bảo hành";
            exSheet.get_Range("H2").Value = "Số lượng";
         
            int k = dgv.Rows.Count - 1;
            exSheet.get_Range("A2:H" + (k + 7).ToString()).
                Borders.LineStyle
                = Excel.XlLineStyle.xlDouble;//.Borders( true);
            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                exSheet.get_Range("A" + (3 + i).ToString()).Value =
                    (i + 1).ToString();
                exSheet.get_Range("B" + (3 + i).ToString()).Value =
                    dgv.Rows[i].Cells[2].Value.ToString();
                exSheet.get_Range("C" + (3 + i).ToString()).Value =
                    dgv.Rows[i].Cells[1].Value.ToString();
                exSheet.get_Range("D" + (3 + i).ToString()).Value =
                    dgv.Rows[i].Cells[3].Value.ToString();
                exSheet.get_Range("E" + (3 + i).ToString()).Value =
                    dgv.Rows[i].Cells[4].Value.ToString();
                exSheet.get_Range("F" + (3 + i).ToString()).Value =
                    dgv.Rows[i].Cells[5].Value.ToString();
                exSheet.get_Range("G" + (3 + i).ToString()).Value =
                    dgv.Rows[i].Cells[6].Value.ToString();
                exSheet.get_Range("H" + (3 + i).ToString()).Value =
                    dgv.Rows[i].Cells[7].Value.ToString();
                
            }
            exBook.Activate();
            SaveFileDialog svf = new SaveFileDialog();
            svf.Title = "chọn đg dẫn và đặt tên tệp lưu dl ";
            svf.ShowDialog();
            string filename = svf.FileName;
            if (filename == "")
            {
                MessageBox.Show("Bạn chưa đặt tên file");
            }
            else
            {
                exBook.SaveAs(filename);
            }
            
            exApp.Quit();
        }
    }
}
