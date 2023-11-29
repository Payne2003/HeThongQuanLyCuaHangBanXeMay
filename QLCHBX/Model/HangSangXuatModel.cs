using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QLCHBX.Model
{
    public class HangSanXuatModel : ProcessDatabase
    {
        public HangSanXuatModel()
        {
        }

        public HangSanXuatModel(int maHangSX)
        {
            MaHangSX = maHangSX;
        }

        public HangSanXuatModel(string tenHangSX, string anh)
        {
            TenHangSX = tenHangSX;
            Anh = anh;
        }

        public HangSanXuatModel(int maHangSX, string tenHangSX, string anh) : this(maHangSX)
        {
            TenHangSX = tenHangSX;
            Anh = anh;
        }

        public int MaHangSX { get; set; }
        public string TenHangSX { get; set; }
        public string Anh { get; set; }

        public DataTable LayDuLieuHangSX()
        {
            string sql = "SELECT MaHangSX, TenHangSX FROM Hangsanxuat";
            return DocBang(sql);
        }
        public string HangSXBanChay()
        {
            DataTable dataTable = new DataTable();
            string tenHangSXBanChay = "";
            int soLuongBanMax = 0;
            string sql = "SELECT * FROM ViewHangSanXuat";
            dataTable = DocBang(sql);

            // Tìm mặt hàng bán chạy nhất
            foreach (DataRow row in dataTable.Rows)
            {
                string tenHangSX = row["TenHangSanXuat"].ToString();
                int soLuongBan = Convert.ToInt32(row["SoLuongBan"]);

                if (soLuongBan > soLuongBanMax)
                {
                    soLuongBanMax = soLuongBan;
                    tenHangSXBanChay = tenHangSX;
                }
            }

            return tenHangSXBanChay;
        }

        public string layFileAnh()
        {
            string path = "";

            string sql = "SELECT Anh FROM Hangsanxuat WHERE MaHangSX = @MaHangSX;";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaHangSX", MaHangSX)
            };

            object result = ExecuteScalar(sql, sqlParameters);

            // Kiểm tra xem kết quả truy vấn có giá trị hay không
            if (result != null && result != DBNull.Value)
            {
                path = result.ToString(); // Gán đường dẫn từ cột "Anh" trong cơ sở dữ liệu
            }
            else
            {
                MessageBox.Show("Không tìm thấy tệp ảnh hoặc chưa có ảnh!");
            }

            return path;
        }

        public bool CapNhatHangSX()
        {
            string sql = "UPDATE Hangsanxuat SET TenHangSX = @TenHangSX, Anh = @Anh WHERE MaHangSX = @MaHangSX;";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@TenHangSX", TenHangSX),
                new SqlParameter("@Anh", Anh),
                new SqlParameter("@MaHangSX", MaHangSX)
            };

            return ExecuteNonQuery(sql, sqlParameters);
        }

        public bool ThemHangMoi()
        {
            string sql = "INSERT INTO Hangsanxuat (TenHangSX, Anh) VALUES (@TenHangSX, @Anh);";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@TenHangSX", TenHangSX),
                new SqlParameter("@Anh", Anh)
            };

            return ExecuteNonQuery(sql, sqlParameters);
        }


    }
}
