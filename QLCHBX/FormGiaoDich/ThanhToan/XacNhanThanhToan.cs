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
        public void XacNhan()
        {
            if (!(btTienMat.Checked || btVNPay.Checked || btBank.Checked))
            {
                MessageBox.Show("Yêu cầu nhập phương thức thanh toán.");
                return;
            }

            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook =
            exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet =
                (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range tenvung = (Excel.Range)exSheet.Cells[1, 1];
            tenvung.Font.Name = "Arial"; tenvung.Font.Size = 25;
            tenvung.Font.Color = Color.White;
            tenvung.Font.FontStyle = FontStyle.Bold;
            
            int k = viewChitietDonDatHang.Rows.Count - 1;
            exSheet.get_Range("A2:C" + (k + 8).ToString()).
                Borders.LineStyle
                = Excel.XlLineStyle.xlDouble;//.Borders( true);
            for (int i = 0; i < viewChitietDonDatHang.Rows.Count - 1; i++)
            {
                
            }
            exBook.Activate();
            SaveFileDialog svf = new SaveFileDialog();
            svf.Title = "chọn đg dẫn và đặt tên tệp lưu dl ";
            svf.ShowDialog();
            string filename = svf.FileName;
            if (filename == "")
            {
                MessageBox.Show("bạn chua dat ten file");
            }
            exBook.SaveAs(filename);
            exApp.Quit();

            DonDatHangModel model = new DonDatHangModel(int.Parse(lbSoDDH.Text));
            model.ThanhToan();

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
