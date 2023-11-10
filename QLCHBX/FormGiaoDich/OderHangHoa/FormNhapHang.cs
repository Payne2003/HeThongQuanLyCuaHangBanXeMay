using QLCHBX.FormGiaoDich.FormLoaiXe;
using QLCHBX.FormGiaoDich.ThemKhachHang;
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

namespace QLCHBX.FormGiaoDich.OderHangHoa
{
    public partial class FormNhapHang : Form
    {
        public FormNhapHang(int MaNV,int MaNCC)
        {
            InitializeComponent();
            txtMaNV.Text = MaNV.ToString();
            txtMaNCC.Text = MaNCC.ToString();   
            guna2ShadowForm1.SetShadowForm(this);
        }
        public FormNhapHang(int SoHDN)
        {
            InitializeComponent();
            txtSoHDN.Text = SoHDN.ToString();
            guna2ShadowForm1.SetShadowForm(this);
        }
        private void honDaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public void LoadDataGirdView()
        {

        }
        public bool KiemTraTextsRong(params string[] texts)
        {
            return texts.Any(string.IsNullOrWhiteSpace);
        }
        private void FormNhapHang_Load(object sender, EventArgs e)
        {
            LoadDataGirdView();
            if (!KiemTraTextsRong(txtSoHDN.Text))
            {
               txtMaNV.Visible = false;
               txtMaNCC.Visible = false;
            }
            else
            {
                DateTime NgayMua = DateTime.Now;
                HoaDonNhapModel hoaDonNhap_New= new HoaDonNhapModel(int.Parse(txtMaNV.Text),NgayMua,int.Parse(txtMaNCC.Text));
                int SoHDN = hoaDonNhap_New.ThemHoaDonNhap();
                txtSoHDN.Text = SoHDN.ToString();
            }
        }
    }
}
