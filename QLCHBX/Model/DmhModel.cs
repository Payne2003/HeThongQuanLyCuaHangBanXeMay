using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHBX.Model
{
    public class DmhModel : ProcessDatabase
    {
        public int MaHang { get; set; }
        public string TenHang { get; set;}
        public int MaTheLoai { get; set; }
        public int MaHangSX { get; set; }
        public int MaMau { get; set; }
        public string NamSX { get; set; }
        public int MaPhanh { get; set;}

        public int MaDongCo { get; set; }
        public decimal DungTichBinhXang { get; set; }   
        public int MaNuocSx { get; set; }
        public int MaTinhTrang { get; set; }
        public byte Anh { get; set; }
        public int SoLuong { get; set;}
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public int ThoiGianBaoHanh { get; set; }
    }
}
