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

namespace QLCHBX.HanghoaControl
{
    public partial class Xeso : UserControl
    {
        ProcessDatabase dtBase = new ProcessDatabase();
        string connectionString = "Data Source=DuyLa;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
      
        public Xeso()
        {
            InitializeComponent();
            DataTable dt = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh From Dmh");
            dgv.DataSource = dt;
        }
          
        private void txtma_TextChanged(object sender, EventArgs e)
        {
            string maHang = txtma.Text;
            if (string.IsNullOrEmpty(maHang))
            {
                dgv.DataSource = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh From Dmh");
            }
            else
            {
                dgv.DataSource = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh From Dmh where MaHang='" + maHang + "'");
            }
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            AddXe xe = new AddXe();
            xe.ShowDialog();
            dgv.DataSource = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh From Dmh");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           
            DataGridViewRow selectedRow =dgv.SelectedRows[0];

            string maHang = selectedRow.Cells["MaHang"].Value.ToString();

            string tenHang = selectedRow.Cells["TenHang"].Value.ToString();           
            string namSX = selectedRow.Cells["NamSX"].Value.ToString();                             
            Byte[] imgPath = (Byte[])selectedRow.Cells["Anh"].Value;          
            string DGB = selectedRow.Cells["DonGiaBan"].Value.ToString();
            string Time = selectedRow.Cells["ThoiGianBaoHanh"].Value.ToString();
            EditXe edit = new EditXe();
            edit.MaHang = maHang;
            edit.TenHang = tenHang;           
            edit.NamSanXuat = namSX;          
                  
            edit.DonGiaBan = DGB;
            edit.ThoiGian = Time;          
            edit.img= imgPath;                            
            edit.ShowDialog();
            dgv.DataSource = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh From Dmh");

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            
            
        }

      

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv.Columns["ChiTiet"].Index)
            {
                DataGridViewRow selectedRow = dgv.SelectedRows[0];
                int ma = int.Parse(selectedRow.Cells["MaHang"].Value.ToString()); // Thay "Ma" bằng tên cột chứa mã
                
                // Truy vấn cơ sở dữ liệu để lấy thông tin chi tiết
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
                        Byte[] imgPath = (Byte[]) reader["Anh"];
                        reader.Close();
                        string qr = @"SELECT 
                    TheLoai.TenTheLoai, 
                    HangSanxuat.TenHangSX, 
                    MauSac.TenMau, 
                    PhanhXe.TenPhanh, 
                    DongCo.TenDongCo,
                    Nuocsanxuat.TenNuocSX,
                    TinhTrang.TenTinhTrang
                FROM 
                    dmh
                LEFT JOIN TheLoai ON dmh.MaTheLoai = TheLoai.MaTheLoai
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
                    dmh.NamSX = @NamSX AND
                    dmh.MaPhanh = @MaPhanh AND
                    dmh.MaDongCo = @MaDongCo AND
                    dmh.MaNuocSX = @MaNuocSX AND
                    dmh.MaTinhTrang = @MaTinhTrang ";

                        // Tạo đối tượng SqlCommand và thiết lập tham số
                        SqlCommand command2 = new SqlCommand(qr, connection);
                        command2.Parameters.AddWithValue("@MaTheLoai", matl);
                        command2.Parameters.AddWithValue("@MaHangSX", mahsx);
                        command2.Parameters.AddWithValue("@MaMau", mamau);
                        command2.Parameters.AddWithValue("@NamSX", nsx);
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
                    reader.Close();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgv.SelectedRows[0];

            string maHang = selectedRow.Cells["MaHang"].Value.ToString();
            if (MessageBox.Show("Bạn có muốn xóa xe có mã là:" + maHang + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtBase.CapNhatDuLieu("delete Dmh where MaHang='" + maHang + "'");
                dgv.DataSource = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh From Dmh");

               
            }
        }
        public void SetDataGridViewDataSource(DataTable dt)
        {
            dgv.DataSource = dt;
        }
    }
}
