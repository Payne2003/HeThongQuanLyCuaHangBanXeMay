using QLCHBX.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace QLCHBX.FormGiaoDich.ThanhToan
{
    public partial class XacNhanThanhToan : Form
    {
        public XacNhanThanhToan()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);   
        }

        public void LoadDataGridView()
        {
            ChiTietDonDatHangModel chiTietDonDatHangLoad = new ChiTietDonDatHangModel(int.Parse(lbSoDDH.Text));
            viewChitietDonDatHang.DataSource =  chiTietDonDatHangLoad.LayDuLieuCuaHoaDon();
        }

        public void CapNhatSauKhiThanhToan()
        {
            
            int soLuongBanDau = 0;
            int soluongSauKhiThanhtoan = 0;
            int soLuongMua = 0;
            int MaHangMua;
            DmhModel dmhModel;

            for (int i = 0; i < viewChitietDonDatHang.RowCount - 1; i++)
            {
                DataGridViewRow row = viewChitietDonDatHang.Rows[i];
                MaHangMua = int.Parse(row.Cells[0].Value.ToString());
                dmhModel = new DmhModel(MaHangMua);
                soLuongBanDau =  dmhModel.LaySoLuongKho();
                soLuongMua = int.Parse(row.Cells[2].Value.ToString());
                soluongSauKhiThanhtoan = soLuongBanDau - soLuongMua;
                dmhModel.CapNhatSoLuong(soluongSauKhiThanhtoan);
            }
        }
        
        public static void CreateMainContent(Excel.Worksheet exSheet,string TenKhach,string dienThoaiKhach,int soDDH,string diaChi)
        {
            int rowHeight = 20;
            int columnWidth = 25;

            for (int row = 1; row <= 7; row++)
            {
                exSheet.Rows[row].RowHeight = rowHeight;
            }

            for (int col = 1; col <= 7; col++)
            {
                exSheet.Columns[col].ColumnWidth = columnWidth;
            }


            Excel.Range headerRange = exSheet.get_Range("A1", "G1");
            headerRange.Merge();
            headerRange.Value = "FUSHION";
            headerRange.Font.Size = 18;
            headerRange.Font.Bold = true;
            headerRange.Interior.Color = Color.MintCream;
            headerRange.Font.Color = Color.Black;
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            headerRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            // Đặt chiều rộng cho hàng đầu
            headerRange.RowHeight = 80;

            // Địa chỉ
            Excel.Range diachi = exSheet.get_Range("A2", "B2");
            diachi.Merge();
            diachi.Value = "Địa chỉ: Số 69 Trần Duy Hưng";
            diachi.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Số điện thoại
            Excel.Range dienthoai = exSheet.get_Range("C2", "D2");
            dienthoai.Merge();
            dienthoai.Value = "SDT: 0395757650";
            dienthoai.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Email
            Excel.Range email = exSheet.get_Range("E2", "F2");
            email.Merge();
            email.Value = "Email: trantuan120803@gmail.com";
            email.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Ngày lập hóa đơn
            DateTime dt = DateTime.Now;
            Excel.Range ngayLapHoaDon = exSheet.get_Range("A3", "B3");
            ngayLapHoaDon.Merge();
            ngayLapHoaDon.Value = "Ngày lập hóa đơn: " + (dt.Date).ToString();
            ngayLapHoaDon.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Tên khách hàng
            Excel.Range nguoiNhanHoaDon = exSheet.get_Range("A4", "B4");
            nguoiNhanHoaDon.Merge();
            nguoiNhanHoaDon.Value = "Tên khách hàng: " + TenKhach;
            nguoiNhanHoaDon.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Số điện thoại khách hàng
            Excel.Range sodienThoaiKhach = exSheet.get_Range("C4", "D4");
            sodienThoaiKhach.Merge();
            sodienThoaiKhach.Value = "Số điện thoại khách hàng: " + dienThoaiKhach;
            sodienThoaiKhach.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Số hóa đơn
            Excel.Range soHoaDon = exSheet.get_Range("E4", "F4");
            soHoaDon.Merge();
            soHoaDon.Value = "#Số Hóa Đơn: " + soDDH;
            soHoaDon.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Địa chỉ khách hàng
            Excel.Range diaChiKhach = exSheet.get_Range("A5", "B5");
            diaChiKhach.Merge();
            diaChiKhach.Value = "Địa chỉ khách hàng: " + diaChi;
            diaChiKhach.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Danh sách mặt hàng mua
            Excel.Range danhsach = exSheet.get_Range("A6", "B6");
            danhsach.Merge();
            danhsach.Value = "Danh sách mặt hàng mua: ";
            danhsach.Font.Size = 10;
            danhsach.Font.Bold = true;
            danhsach.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
        }
        public void CreateExcelFile()
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            int soDDH = int.Parse(lbSoDDH.Text);
            DonDatHangModel donDatHang = new DonDatHangModel(soDDH);
            KhachHangModel khachHang = donDatHang.LayThongtinKhach();
            CreateMainContent(exSheet,khachHang.TenKhach,khachHang.DienThoai,soDDH,khachHang.DiaChi);
            
            exSheet.get_Range("A8:G8").Font.Size = 12;
            exSheet.get_Range("A8:G8").Font.Bold = true;
            exSheet.get_Range("A8").Value = "STT";
            exSheet.get_Range("B8").Value = "#Mã Hàng";
            exSheet.get_Range("C8").Value = "Tên Hàng";
            exSheet.get_Range("D8").Value = "Số lượng";
            exSheet.get_Range("E8").Value = "Đơn giá";
            exSheet.get_Range("F8").Value = "Giảm giá";
            exSheet.get_Range("G8").Value = "Thành tiền";

            
            int k = viewChitietDonDatHang.Rows.Count - 1;
            exSheet.get_Range("A8:G" + (k + 8).ToString()).
                Borders.LineStyle
                = Excel.XlLineStyle.xlDouble;//.Borders( true);
            for (int i = 0; i < viewChitietDonDatHang.Rows.Count - 1; i++)
            {
                exSheet.get_Range("A" + (9 + i).ToString()).Value =
                    (i + 1).ToString();
                exSheet.get_Range("B" + (9 + i).ToString()).Value =
                    viewChitietDonDatHang.Rows[i].Cells[0].Value.ToString();
                exSheet.get_Range("C" + (9 + i).ToString()).Value =
                    viewChitietDonDatHang.Rows[i].Cells[1].Value.ToString();
                exSheet.get_Range("D" + (9 + i).ToString()).Value =
                    viewChitietDonDatHang.Rows[i].Cells[2].Value.ToString();
                exSheet.get_Range("E" + (9 + i).ToString()).Value =
                    viewChitietDonDatHang.Rows[i].Cells[3].Value.ToString();
                exSheet.get_Range("F" + (9 + i).ToString()).Value =
                    viewChitietDonDatHang.Rows[i].Cells[4].Value.ToString();
                exSheet.get_Range("G" + (9 + i).ToString()).Value =
                    viewChitietDonDatHang.Rows[i].Cells[5].Value.ToString();

                exSheet.get_Range("A" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                exSheet.get_Range("B" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                exSheet.get_Range("C" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                exSheet.get_Range("D" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                exSheet.get_Range("E" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                exSheet.get_Range("F" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                exSheet.get_Range("G" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            }
            string phuongThucTT = "";
            if (btTienMat.Checked)
            {
                phuongThucTT = btTienMat.Text;
            }
            else if(btVNPay.Checked)
            {
                phuongThucTT = btVNPay.Text;
            }
            else if(btBank.Checked)
            {
                phuongThucTT = btBank.Text;
            }

            Excel.Range phuongThuc = exSheet.get_Range("A" + (k + 11), "B" + (k + 11));
            phuongThuc.Merge();
            phuongThuc.Value = "Phương thức thanh toán: " + phuongThucTT;
            phuongThuc.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            Excel.Range thue = exSheet.get_Range("F" + (k + 11), "G" + (k + 11));
            thue.Merge();
            thue.Value = "Thuế: " + donDatHang.LayThue();
            thue.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


            Excel.Range datCoc = exSheet.get_Range("F" + (k + 12), "G" + (k + 12));
            datCoc.Merge();
            datCoc.Value = "Đặt cọc: " + donDatHang.LayDatCoc();
            datCoc.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            Excel.Range tongtien = exSheet.get_Range("F" + (k + 13), "G" + (k + 13));
            tongtien.Merge();
            tongtien.Value = "Tổng tiền: " + lbTongTien.Text;
            tongtien.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            Excel.Range thongtin = exSheet.get_Range("A" + (k + 12), "B" + (k + 12));
            thongtin.Merge();
            thongtin.Value = "Thông tin tài khoản ngân hàng:";
            thongtin.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


            Excel.Range STK = exSheet.get_Range("A" + (k + 13), "B" + (k + 13));
            STK.Merge();
            STK.Value = "Tên tài khoản: TRAN QUOC TUAN";
            STK.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            Excel.Range nganHang = exSheet.get_Range("A" + (k + 14), "B" + (k + 14));
            nganHang.Merge();
            nganHang.Value = "Số tài khoản: 0395757650";
            nganHang.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


            Excel.Range thongbao = exSheet.get_Range("A" + (k + 15), "G" + (k + 15));
            thongbao.Merge();
            DateTime dt = DateTime.Now.AddDays(7);
            thongbao.Value = "Vui lòng thanh toán trước ngày " + dt.ToString("dd/MM/yyyy") + ". Cảm ơn bạn đã chọn FUSHION!";
            thongbao.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range loiCamOn = exSheet.get_Range("A" + (k + 16), "G" + (k + 16));
            loiCamOn.Merge();
            loiCamOn.Value = "Xin chân thành cảm ơn quý khách!";
            loiCamOn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            // Lưu tệp Excel

            SaveFileDialog svf = new SaveFileDialog();
            svf.Title = "Chọn đường dẫn và đặt tên tệp lưu dữ liệu";
            svf.InitialDirectory = @"D:\HoaDon\";  // Đặt đường dẫn mặc định là D:\
            svf.FileName = "HoaDon" + lbSoDDH.Text;
            svf.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";  // Lọc tệp để chỉ hiển thị các tệp Excel

            if (svf.ShowDialog() == DialogResult.OK)
            {
                string filePath = svf.FileName;
                // Tiếp tục với quá trình lưu tệp
                exBook.SaveAs(filePath);
                exApp.Quit();
                // Mở tệp sau khi lưu
                System.Diagnostics.Process.Start(filePath);
                MessageBox.Show("Tệp đã được lưu tại: " + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void XacNhan()
        {
            if (!(btTienMat.Checked || btVNPay.Checked || btBank.Checked))
            {
                MessageBox.Show("Yêu cầu nhập phương thức thanh toán.");
                return;
            }
            CreateExcelFile();
            DangThanhToan();

        }
        public void DangThanhToan()
        {
            DonDatHangModel model = new DonDatHangModel(int.Parse(lbSoDDH.Text));
            model.ThanhToan();
            CapNhatSauKhiThanhToan();
            MessageBox.Show("Thanh toán thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            GiaoDich giaoDich = Application.OpenForms["GiaoDich"] as GiaoDich;
            if (giaoDich != null)
            {
                giaoDich.Close();
            }
        }
        private void btXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            XacNhan();
        }
        private void XacNhanThanhToan_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
    }
}
