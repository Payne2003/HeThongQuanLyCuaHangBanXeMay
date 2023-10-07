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

        
        public DashBoard()
        {
            InitializeComponent();
            khachhang1.Visible = false;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      

        private void MovePanel(Control control)
        {
            pnMoving.Top = control.Bottom;
            pnMoving.Left = control.Left;
        }


        private void btBaoCao_Click(object sender, EventArgs e)
        {
            MovePanel(btBaoCao);
            khachhang1.Visible = false;
        }

        private void btHangHoa_Click(object sender, EventArgs e)
        {
            MovePanel(btHangHoa);
            khachhang1.Visible = false;
        }

        private void btGiaoDich_Click(object sender, EventArgs e)
        {
            MovePanel(btGiaoDich);
            khachhang1.Visible = false;
        }

        private void btDoitac_Click(object sender, EventArgs e)
        {
            MovePanel(btDoitac);
            khachhang1.Visible = false;
        }

        private void btNhanvien_Click(object sender, EventArgs e)
        {
            MovePanel(btNhanvien);
            khachhang1.Visible = false;
        }

        private void btKhachhang_Click(object sender, EventArgs e)
        {
            MovePanel(btKhachhang);
            khachhang1.Visible = true;
        }
    }
}
