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
