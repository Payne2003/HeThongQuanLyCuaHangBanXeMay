using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Model
{
    public class HoaDonNhapModel : ProcessDatabase
    {
        public int SoHDN { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayNhap { get; set; }
        public int MaNCC { get; set; }
        public decimal TongTien { get; set; }


        public HoaDonNhapModel()
        {

        }


        public bool ThemHoaDonNhap()
        {
            string sql = "";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@SoHDN",SoHDN),
                new SqlParameter("@MaNV",MaNV),
                new SqlParameter("@MaNCC",MaNCC),
                new SqlParameter("@NgayNhap",NgayNhap)
            };


            return ExecuteNonQuery(sql,sqlParameters);
        }
    }
}
