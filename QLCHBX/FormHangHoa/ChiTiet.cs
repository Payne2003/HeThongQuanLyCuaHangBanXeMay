using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.FormHangHoa
{
    public partial class ChiTiet : Form
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string TenTheLoai { get; set; }
        public string TenHangSX { get; set; }
        public string TenMau { get; set; }
        public string NamSanXuat { get; set; }
        public string TenDongCo { get; set; }
        public string TenPhanh { get; set; }
        public string TenNuocSX { get; set; }
        public string TenTinhTrang { get; set; }
        public string SoLuong { get; set; }
        public string ThoiGian { get; set; }
        public string DungTichBX { get; set; }
        public string DonGiaNhap { get; set; }
        public string DonGiaBan { get; set; }
        public byte[] img { get; set; }
        public ChiTiet()
        {
            InitializeComponent();
        }

        private void ChiTiet_Load(object sender, EventArgs e)
        {
            lbmah.Text = "Mã Hàng : " + MaHang;
            lbtenh.Text = "Tên Hàng ; " + TenHang;
            lbmatl.Text = "Tên Thể Loại : " + TenTheLoai;
            lbmatt.Text = "Tình Trạng : " + TenTinhTrang;
            lbmadc.Text = "Động cơ : " + TenDongCo;
            lbmahsx.Text = "Hãng sản xuất : " + TenHangSX;
            lbmap.Text = "Phanh : " + TenPhanh;
            lbmamau.Text = "Màu sắc : " + TenMau;
            lbmansx.Text = "Nước sản xuất : " + TenNuocSX;
            lbnsx.Text = "Năm sản xuất : " + NamSanXuat;
            lbsl.Text = "Số lượng : " + SoLuong;
            lbtgbh.Text = "Thời gian bảo hành : " + ThoiGian + " năm ";
            lbdgn.Text = "Đơn giá nhập : " + DonGiaNhap;
            lbdgb.Text = "Đơn giá bán : " + DonGiaBan;
            lbdtbx.Text = "Dung tích bình xăng : " + DungTichBX;
            if (img != null && img.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(img))
                {
                    try
                    {
                        ptb1.Image = Image.FromStream(ms);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi chuyển đổi hình ảnh: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Mảng byte hình ảnh không hợp lệ.");
            }
        }

        private void ptb1_Click(object sender, EventArgs e)
        {

        }
    }
}
