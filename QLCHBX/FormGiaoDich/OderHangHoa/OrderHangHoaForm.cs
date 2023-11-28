using QLCHBX.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLCHBX.FormGiaoDich.OderHangHoa
{
    public partial class OrderHangHoaForm : Form
    {
        public OrderHangHoaForm()
        {
            InitializeComponent();
        }
        public void LoadDataGridView()
        {
            HoaDonNhapModel hoaDonNhapLoad = new HoaDonNhapModel();
            viewHoaDonNhap.DataSource = hoaDonNhapLoad.LayDuLieuHoaDonNhapChuaNhap();
            grbChiTietHoaDonNhap.Visible = false;
            NhaCungCapModel nhaCungCapLoad = new NhaCungCapModel(); 
            DataTable dtNhaCungCap = nhaCungCapLoad.LayDanhSachNhaCungCap();
            cbbMaNCC.DataSource = dtNhaCungCap;
            cbbMaNCC.DisplayMember = "TenNCC";
            cbbMaNCC.ValueMember = "MaNCC";
            
            cbbbNCCNew.DataSource = dtNhaCungCap;
            cbbbNCCNew.DisplayMember = "TenNCC";
            cbbbNCCNew.ValueMember = "MaNCC";
            lbMaNCC_New.Visible = true;
            //lbMaNCC_New.Text = ((DataRowView)cbbMaNCC.SelectedItem)["MaNCC"].ToString();

            LoadGiaoDien();
        }
        
        public void LoadGiaoDien()
        {
            btNhapHang.Visible = false;
            btSua.Visible = false;
            btCapNhat.Visible = false;
            grbThongTinHoaDonNhap.Visible = false;
            btLichSu.Visible = true;
            grbThongTinDonMoi.Visible = true;
            btTaoHoaDonNhap.Visible = true;
            txtTongTien.Text = "";
        }
        private void OrderHangHoaForm_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        public void LoadClickDataGridView()
        {
            grbThongTinHoaDonNhap.Visible = true;
            grbThongTinDonMoi.Visible = false;
            lbMaNCC_New.Visible = false;
            btTaoHoaDonNhap.Visible = false;
            btLichSu.Visible = false;
            btSua.Visible = true;
            btCapNhat.Visible=true;
            btNhapHang.Visible= true;
            grbChiTietHoaDonNhap.Visible = true;
        }
       
        public void SaveData()
        {
            int SoHDN = int.Parse(txtSoHDN.Text);
            int MaNV = int.Parse(txtMaNV.Text);
            DateTime dt = DateTime.Parse(dtNgayNhap.Text);
            int MaNCC = int.Parse(lbMaNCC_CapNhat.Text);
            decimal TongTien = decimal.Parse(txtTongTien.Text);
            lbMaNCC_New.Visible = true;
            lbMaNCC_New.Text = ((DataRowView)cbbMaNCC.SelectedItem)["MaNCC"].ToString();
            HoaDonNhapModel hoaDonNhap_CapNhat = new HoaDonNhapModel(SoHDN, MaNV, dt.Date, MaNCC, TongTien);
            hoaDonNhap_CapNhat.CapNhatHoaDonNhap();
            LoadDataGridView();
        }
        private void viewHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewHoaDonNhap.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    LoadClickDataGridView();
                    txtSoHDN.Text = row.Cells[0].Value.ToString();
                    txtMaNV.Text = row.Cells[1].Value.ToString();
                    txtTenNhanVien.Text = row.Cells[2].Value.ToString();
                    cbbMaNCC.Text = row.Cells[4].Value.ToString();
                    dtNgayNhap.Text = row.Cells[5].Value.ToString();
                    txtTongTien.Text = row.Cells[6].Value.ToString();
                    ChiTietHoaDonNhapModel chiTietHoaDonNhapLoad = new ChiTietHoaDonNhapModel(int.Parse(row.Cells[0].Value.ToString()));
                    viewChiTietHoaDonNhap.DataSource = chiTietHoaDonNhapLoad.LayChiTietHoaDonNhap();
                    viewChiTietHoaDonNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void viewHoaDonNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = viewHoaDonNhap.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    string SoHDN = row.Cells[0].Value.ToString();
                    if (!string.IsNullOrEmpty(SoHDN)) 
                    {
                        DialogResult result = MessageBox.Show("Xóa Khách hàng có mã: " + SoHDN + " ?", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            ChiTietHoaDonNhapModel chiTietHoaDon_Xoa = new ChiTietHoaDonNhapModel(int.Parse(SoHDN));
                            chiTietHoaDon_Xoa.XoaChiTietHoaDonNhap();
                            chiTietHoaDon_Xoa.XoaHoaDonNhap();
                            LoadDataGridView();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }
        }

        private void btTaoHoaDonNhap_Click(object sender, EventArgs e)
        {
            FormNhapHang formNhapHang = new FormNhapHang(int.Parse(txtMaNV.Text),int.Parse(lbMaNCC_New.Text));
            formNhapHang.ShowDialog();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            FormNhapHang formNhapHang = new FormNhapHang(int.Parse(txtSoHDN.Text));
            formNhapHang.ShowDialog();
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btNhapHang_Click(object sender, EventArgs e)
        {
            XacNhan();
        }
        public void CapNhatSauKhiThanhToan()
        {

            int soLuongBanDau = 0;
            int soluongSauKhiThanhtoan = 0;
            int soluongNhap = 0;
            int MaHangMua;
            DmhModel dmhModel;

            for (int i = 0; i < viewChiTietHoaDonNhap.RowCount - 1; i++)
            {
                DataGridViewRow row = viewChiTietHoaDonNhap.Rows[i];
                MaHangMua = int.Parse(row.Cells[0].Value.ToString());
                dmhModel = new DmhModel(MaHangMua);
                soLuongBanDau = dmhModel.LaySoLuongKho();
                soluongNhap = int.Parse(row.Cells[2].Value.ToString());
                soluongSauKhiThanhtoan = soLuongBanDau + soluongNhap;
                dmhModel.CapNhatSoLuong(soluongSauKhiThanhtoan);
            }
        }
        public void DangThanhToan()
        {
            HoaDonNhapModel model = new HoaDonNhapModel(int.Parse(txtSoHDN.Text));
            model.NhapHang();
            CapNhatSauKhiThanhToan();
            MessageBox.Show("Nhập hàng thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView();
        }

        public void XacNhan()
        {

            DialogResult result = MessageBox.Show("Yêu cầu nhập mã đơn: " + txtSoHDN.Text + " ?", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                CreateExcelFile();
                DangThanhToan();
            }
            else
            {
                LoadDataGridView();
                return;
            }
            

        }
        private void cbbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaNCC.SelectedItem != null)
            {
                if (cbbMaNCC.SelectedItem is DataRowView)
                {
                    string maNCC = ((DataRowView)cbbMaNCC.SelectedItem)["MaNCC"].ToString();
                    lbMaNCC_CapNhat.Text = maNCC;
                }
                else
                {
                    lbMaNCC_CapNhat.Text = "";
                }
            }
            else
            {
                lbMaNCC_CapNhat.Text = "";
            }
        }

        private void cbbbNCCNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbbNCCNew.SelectedItem != null)
            {
                if (cbbbNCCNew.SelectedItem is DataRowView)
                {
                    string maNCC = ((DataRowView)cbbbNCCNew.SelectedItem)["MaNCC"].ToString();
                    lbMaNCC_New.Text = maNCC;
                }
                else
                {
                    lbMaNCC_New.Text = "";
                }
            }
            else
            {
                lbMaNCC_New.Text = "";
            }
        }

        private void btLichSu_Click(object sender, EventArgs e)
        {
            this.Close();
            LichSuNhapHangForm lichSuNhapHang = new LichSuNhapHangForm();
            lichSuNhapHang.ShowDialog();
        }
        public static void CreateMainContent(Excel.Worksheet exSheet, string TenNCC, string dienThoaiNCC, int SoHDN, string diaChiNCC)
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
            headerRange.Value = TenNCC;
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
            diachi.Value = "Địa chỉ: " + diaChiNCC;
            diachi.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Số điện thoại
            Excel.Range dienthoai = exSheet.get_Range("C2", "D2");
            dienthoai.Merge();
            dienthoai.Value = "SDT: " + dienThoaiNCC;
            dienthoai.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Ngày lập hóa đơn
            DateTime dt = DateTime.Now;
            Excel.Range ngayLapHoaDon = exSheet.get_Range("A3", "B3");
            ngayLapHoaDon.Merge();
            ngayLapHoaDon.Value = "Ngày lập hóa đơn: " + (dt.Date).ToString();
            ngayLapHoaDon.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Tên khách hàng
            Excel.Range nguoiNhanHoaDon = exSheet.get_Range("A4", "B4");
            nguoiNhanHoaDon.Merge();
            nguoiNhanHoaDon.Value = "Tên công ty nhận: FUSHION";
            nguoiNhanHoaDon.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Số điện thoại khách hàng
            Excel.Range sodienThoaiKhach = exSheet.get_Range("C4", "D4");
            sodienThoaiKhach.Merge();
            sodienThoaiKhach.Value = "Số điện thoại FUSHION: 0395757650";
            sodienThoaiKhach.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Số hóa đơn
            Excel.Range soHoaDon = exSheet.get_Range("E4", "F4");
            soHoaDon.Merge();
            soHoaDon.Value = "#Số Hóa Đơn: " + SoHDN;
            soHoaDon.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Địa chỉ khách hàng
            Excel.Range diaChiKhach = exSheet.get_Range("A5", "B5");
            diaChiKhach.Merge();
            diaChiKhach.Value = "Địa chỉ: Số 69 Trần Duy Hưng";
            diaChiKhach.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Danh sách mặt hàng mua
            Excel.Range danhsach = exSheet.get_Range("A6", "B6");
            danhsach.Merge();
            danhsach.Value = "Danh sách mặt hàng nhập: ";
            danhsach.Font.Size = 10;
            danhsach.Font.Bold = true;
            danhsach.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
        }
        public void CreateExcelFile()
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            int soHDN = int.Parse(txtSoHDN.Text);
            HoaDonNhapModel hoaDonNhap = new HoaDonNhapModel(soHDN);
            NhaCungCapModel nhaCungCap = hoaDonNhap.LayThongTinNhaCungCap();
            CreateMainContent(exSheet, nhaCungCap.TenNCC, nhaCungCap.DienThoai, soHDN, nhaCungCap.DiaChi);
            exSheet.get_Range("A8:G8").Font.Size = 12;
            exSheet.get_Range("A8:G8").Font.Bold = true;
            exSheet.get_Range("A8").Value = "STT";
            exSheet.get_Range("B8").Value = "#Mã Hàng";
            exSheet.get_Range("C8").Value = "Tên Hàng";
            exSheet.get_Range("D8").Value = "Số lượng";
            exSheet.get_Range("E8").Value = "Đơn giá";
            exSheet.get_Range("F8").Value = "Giảm giá";
            exSheet.get_Range("G8").Value = "Thành tiền";


            int k = viewChiTietHoaDonNhap.Rows.Count - 1;
            exSheet.get_Range("A8:G" + (k + 8).ToString()).
                Borders.LineStyle
                = Excel.XlLineStyle.xlDouble;//.Borders( true);
            for (int i = 0; i < viewChiTietHoaDonNhap.Rows.Count - 1; i++)
            {
                exSheet.get_Range("A" + (9 + i).ToString()).Value =
                    (i + 1).ToString();
                exSheet.get_Range("B" + (9 + i).ToString()).Value =
                    viewChiTietHoaDonNhap.Rows[i].Cells[0].Value.ToString();
                exSheet.get_Range("C" + (9 + i).ToString()).Value =
                    viewChiTietHoaDonNhap.Rows[i].Cells[1].Value.ToString();
                exSheet.get_Range("D" + (9 + i).ToString()).Value =
                    viewChiTietHoaDonNhap.Rows[i].Cells[2].Value.ToString();
                exSheet.get_Range("E" + (9 + i).ToString()).Value =
                    viewChiTietHoaDonNhap.Rows[i].Cells[4].Value.ToString();
                exSheet.get_Range("F" + (9 + i).ToString()).Value =
                    viewChiTietHoaDonNhap.Rows[i].Cells[3].Value.ToString();
                exSheet.get_Range("G" + (9 + i).ToString()).Value =
                    viewChiTietHoaDonNhap.Rows[i].Cells[5].Value.ToString();

                exSheet.get_Range("A" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                exSheet.get_Range("B" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                exSheet.get_Range("C" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                exSheet.get_Range("D" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                exSheet.get_Range("E" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                exSheet.get_Range("F" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                exSheet.get_Range("G" + (9 + i).ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            }

            Excel.Range tongtien = exSheet.get_Range("F" + (k + 11), "G" + (k + 11));
            tongtien.Merge();
            tongtien.Value = "Tổng tiền: " + txtTongTien.Text;
            tongtien.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            Excel.Range thongtin = exSheet.get_Range("A" + (k + 11), "B" + (k + 11));
            thongtin.Merge();
            thongtin.Value = "Thông tin tài khoản ngân hàng:";
            thongtin.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


            Excel.Range STK = exSheet.get_Range("A" + (k + 12), "B" + (k + 12));
            STK.Merge();
            STK.Value = "Tên tài khoản: TRAN QUOC TUAN";
            STK.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            Excel.Range nganHang = exSheet.get_Range("A" + (k + 13), "B" + (k + 13));
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
            svf.FileName = "HoaDon" + txtSoHDN.Text;
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

        private void ptTinhToan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yêu Cầu xem tổng chi của Cửa Hàng FuShion", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                XemTongChi xemTongChi = new XemTongChi();
                xemTongChi.Show();
            }
        }
    }
}

