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

namespace QLCHBX.FormGiaoDich.OderHangHoa
{
    public partial class XemTongChi : Form
    {
        public XemTongChi()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }

        public void LoadData()
        {
            HoaDonNhapModel hoaDonNhapLoad = new HoaDonNhapModel();
            DataTable table = new DataTable();

            table = hoaDonNhapLoad.LayThongTinChi();

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

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void XemTongChi_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
