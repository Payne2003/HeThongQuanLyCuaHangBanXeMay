using QLCHBX.Db;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Model
{
    public class GiaoDichModel : DbConnection
    {
        private int SoDDH { get ; set; }
        public string username;
        public string password;
        public string manhanvien { get; set; }
        private decimal sumtien { get; set; }

        public GiaoDichModel() { }

        public int ThemDonDatHang( DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string sql = "INSERT INTO DonDatHang ( NgayMua) OUTPUT INSERTED.SoDDH VALUES (@NgayMua);";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@NgayMua", date);

                // Thực hiện lệnh SQL và lấy giá trị SoDDH
                SoDDH = (int)command.ExecuteScalar();

                return SoDDH;
            }
        }
        public bool CapNhatMaNV(int SoDDH, string MaNV)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                // Cập nhật MaNV trong đơn đặt hàng dựa trên SoDDH
                string updateMaNVSql = "UPDATE DonDatHang SET MaNV = @MaNV WHERE SoDDH = @SoDDH;";
                SqlCommand updateMaNVCommand = new SqlCommand(updateMaNVSql, connection);
                updateMaNVCommand.Parameters.AddWithValue("@MaNV", MaNV);
                updateMaNVCommand.Parameters.AddWithValue("@SoDDH", SoDDH);

                // Thực hiện lệnh SQL để cập nhật MaNV trong đơn đặt hàng
                int rowsAffected = updateMaNVCommand.ExecuteNonQuery();


                return rowsAffected > 0;
            }
        }
     
        public bool XoaDonDatHang(int soDDH)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                // Xóa đơn đặt hàng dựa trên SoDDH
                string deleteDonDatHangSql = "DELETE FROM DonDatHang WHERE SoDDH = @SoDDH;";
                SqlCommand deleteDonDatHangCommand = new SqlCommand(deleteDonDatHangSql, connection);
                deleteDonDatHangCommand.Parameters.AddWithValue("@SoDDH", soDDH);

                // Thử xóa đơn đặt hàng và kiểm tra số hàng bị ảnh hưởng
                int rowsAffected = deleteDonDatHangCommand.ExecuteNonQuery();

                // Trả về true nếu có ít nhất một hàng bị ảnh hưởng (đã xóa), ngược lại trả về false
                return rowsAffected > 0;
            }
        }


    }


}
