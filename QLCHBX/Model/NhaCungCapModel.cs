using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Model
{
    public class NhaCungCapModel : ProcessDatabase
    {
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi {  get; set; }
        public string DienThoai { get; set; }

        public DataTable DocBangNhaCungCap()
        {
            string sql = "SELECT * FROM NhaCungCap"; 
            return DocBang(sql);
        }
        public DataTable LayDanhSachNhaCungCap()
        {
            string sql = "SELECT MaNCC, TenNCC FROM NhaCungCap";
            return DocBang(sql);
        }

    }
}
