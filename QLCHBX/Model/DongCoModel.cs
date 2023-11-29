using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Model
{
    public class DongCoModel : ProcessDatabase
    {
        public DongCoModel() { }

        public int MaDongCo { get; set; }
        public string TenDongCo { get; set; }
        public DataTable LayDuLieuDongCo()
        {
            string sql = "SELECT MaDongCo, TenDongCo FROM Dongco;";
            return DocBang(sql);
        }

        public string DongCoBanChay()
        {
            DataTable dataTable = new DataTable();
            string tenDongBanChay = "";
            int soLuongBanMax = 0;
            string sql = "SELECT * FROM ViewDongCo";
            dataTable = DocBang(sql);

            // Tìm mặt hàng bán chạy nhất
            foreach (DataRow row in dataTable.Rows)
            {
                string tenHangSX = row["TenDongCo"].ToString();
                int soLuongBan = Convert.ToInt32(row["SoLuongBan"]);

                if (soLuongBan > soLuongBanMax)
                {
                    soLuongBanMax = soLuongBan;
                    tenDongBanChay = tenHangSX;
                }
            }

            return tenDongBanChay;
        }
    }
}