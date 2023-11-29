using QLCHBX.ALLControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX
{
    public partial class DashBoard : Form
    {
     
        public DashBoard(int MaNV)
        { 
            InitializeComponent();
            lbMaNV.Text = MaNV.ToString();
            guna2ShadowForm1.SetShadowForm(this);
            
        }

        private void btBaoCao_Click(object sender, EventArgs e)
        {
            baoCao1.BringToFront();
        }

 
        private void DashBoard_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                guna2Elipse1.BorderRadius = 0;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                guna2Elipse1.BorderRadius = 5;
            }
        }

        private void btHangHoa_Click(object sender, EventArgs e)
        {
            hangHoa1.BringToFront();
        }

        private void btGiaoDich_Click(object sender, EventArgs e)
        {

            giaoDichCT1.BringToFront();
            giaoDichCT1.txtMaNV.Text = lbMaNV.Text;
        }

        private void btDoiTac_Click(object sender, EventArgs e)
        {
            nhacungcap1.BringToFront();
        }

        private void btNhanVien_Click(object sender, EventArgs e)
        {
            nhanVien1.BringToFront();
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            khachHang1.BringToFront();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            giaoDichCT1.txtMaNV.Text = lbMaNV.Text;
        }

        private void lbMaNV_Click(object sender, EventArgs e)
        {
            //account1.BringToFront();
        }
        private void btTaiKhoan_Click(object sender, EventArgs e)
        {

        }
    }
}
