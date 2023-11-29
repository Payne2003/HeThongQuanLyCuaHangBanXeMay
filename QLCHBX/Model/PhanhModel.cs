using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Model
{
    public class PhanhModel : ProcessDatabase
    {
        public PhanhModel() { }

        public int MaPhanh { get; set; }
        public string TenPhanh { get; set; }

        public DataTable LayDuLieuPhanhTrongDmh()
        {
            string sql = "SELECT MaPhanh, TenPhanh FROM Phanhxe;";
            return DocBang(sql);
        }

        public string PhanhBanChay()
        {
            DataTable dataTable = new DataTable();
            string tenPhanhBanChay = "";
            int soLuongBanMax = 0;
            string sql = "SELECT * FROM ViewPhanh";
            dataTable = DocBang(sql);

            // Tìm mặt hàng bán chạy nhất
            foreach (DataRow row in dataTable.Rows)
            {
                string tenHangSX = row["TenPhanh"].ToString();
                int soLuongBan = Convert.ToInt32(row["SoLuongBan"]);

                if (soLuongBan > soLuongBanMax)
                {
                    soLuongBanMax = soLuongBan;
                    tenPhanhBanChay = tenHangSX;
                }
            }

            return tenPhanhBanChay;
        }
    }
}
