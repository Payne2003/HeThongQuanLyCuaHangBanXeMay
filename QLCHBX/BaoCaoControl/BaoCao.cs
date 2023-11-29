using QLCHBX.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLCHBX.BaoCaoControl
{
	public partial class BaoCao : UserControl
	{
        HoaDonNhapModel HoaDonNhapModel = new HoaDonNhapModel();
        DonDatHangModel DonDatHangModel = new DonDatHangModel();
        int tongDDHCTT = 0;
        int tongDDHDTT = 0;
        int tongDDH = 0;
        int tongHDNCTT = 0;
        int tongHDNDTT = 0;
        int tongHDN = 0;
		public BaoCao()
		{
			InitializeComponent();
		}



        public void LoadData()
        {
            DataTable table = new DataTable();

            table = HoaDonNhapModel.LayThongTinChi();

            // Xóa các Series hiện tại trong biểu đồ
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Mã Hàng";
            chart1.ChartAreas[0].AxisY.Title = "Biểu đồ tổng tiền chi";

            // Tạo một Series mới với loại biểu đồ là Column
            Series series = chart1.Series.Add("Tổng tiền");
            series.ChartType = SeriesChartType.Column;

            foreach (DataRow row in table.Rows)
            {
                string maHang = row["MaHang"].ToString();
                double tongThanhTien = Convert.ToDouble(row["TongThanhTien"]);
                series.Points.AddXY(maHang, tongThanhTien);
            }
             
            tongDDHCTT = DonDatHangModel.LayTongDonChuaThanhToan();
            lbTongDDHChuaThanhToan.Text = tongDDHCTT.ToString();
            tongDDHDTT = DonDatHangModel.TongDonDaThanhToan();
            lbTongDDHDaThanhToan.Text = tongDDHDTT.ToString();
            tongDDH = tongDDHCTT + tongDDHDTT;
            lbTongSoDonDH.Text = tongDDH.ToString();

            tongHDNCTT = HoaDonNhapModel.LayTongHoaDonNhapChuaNhap();
            lbTongHDNCTT.Text = tongHDNCTT.ToString();
            tongHDNDTT = HoaDonNhapModel.TongDonDaNhap();
            lbTongHDNDTT.Text = tongHDNDTT.ToString();
            tongHDN = tongHDNCTT + tongHDNDTT;
            lbTongHDN.Text = tongHDN.ToString();
            try
            {
                DateTime ngayBD = DateTime.Parse(dtNgayBDDDH.Text);
                DateTime ngayKT = DateTime.Parse(dtNgayKTDDH.Text);
                if (ngayBD <= ngayKT)
                {
                    decimal doanhThu = DonDatHangModel.LayDoanhThu(ngayBD, ngayKT);
                    lbTongDT.Text = doanhThu.ToString();
                }
                else
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lỗi Khoảng Thời Gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ngày nhập không hợp lệ. Vui lòng nhập ngày theo định dạng MM/dd/yyyy.", "Lỗi Định Dạng Ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                DateTime ngayBD = DateTime.Parse(dtNgayBDDDH.Text);
                DateTime ngayKT = DateTime.Parse(dtNgayKTDDH.Text);
                if (ngayBD <= ngayKT)
                {
                    decimal tongChi = HoaDonNhapModel.LayTongChi(ngayBD, ngayKT);
                    lbTongChi.Text = tongChi.ToString();
                }
                else
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lỗi Khoảng Thời Gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ngày nhập không hợp lệ. Vui lòng nhập ngày theo định dạng MM/dd/yyyy.", "Lỗi Định Dạng Ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lbHienThiDDN_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayBD = DateTime.Parse(dtNgayBDDDH.Text);
                DateTime ngayKT = DateTime.Parse(dtNgayKTDDH.Text);
                if (ngayBD <= ngayKT)
                {
                    decimal doanhThu = DonDatHangModel.LayDoanhThu(ngayBD, ngayKT);
                    lbTongDT.Text = doanhThu.ToString();
                }
                else
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lỗi Khoảng Thời Gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ngày nhập không hợp lệ. Vui lòng nhập ngày theo định dạng MM/dd/yyyy.", "Lỗi Định Dạng Ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btHienthiHDN_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime ngayBD = DateTime.Parse(dtNgayBDHDN.Text);
                DateTime ngayKT = DateTime.Parse(dtNgayKTHDN.Text);
                if (ngayBD <= ngayKT)
                {
                    decimal tongChi = HoaDonNhapModel.LayTongChi(ngayBD, ngayKT);
                    lbTongChi.Text = tongChi.ToString();
                    DataTable table = new DataTable();

                    table = HoaDonNhapModel.LayThongTinChi(ngayBD, ngayKT);

                    // Xóa các Series hiện tại trong biểu đồ
                    chart1.Series.Clear();
                    chart1.ChartAreas[0].AxisX.Title = "Mã Hàng";
                    chart1.ChartAreas[0].AxisY.Title = "Biểu đồ tổng tiền chi";

                    // Tạo một Series mới với loại biểu đồ là Column
                    Series series = chart1.Series.Add("Tổng tiền");
                    series.ChartType = SeriesChartType.Column;

                    foreach (DataRow row in table.Rows)
                    {
                        string maHang = row["MaHang"].ToString();
                        double tongThanhTien = Convert.ToDouble(row["TongThanhTien"]);
                        series.Points.AddXY(maHang, tongThanhTien);
                    }
                }
                else
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lỗi Khoảng Thời Gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ngày nhập không hợp lệ. Vui lòng nhập ngày theo định dạng MM/dd/yyyy.", "Lỗi Định Dạng Ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}