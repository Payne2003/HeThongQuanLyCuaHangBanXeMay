using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using QLCHBX.FormHangHoa;
using QLCHBX.HanghoaControl;

namespace QLCHBX.ALLControl
{
    public partial class HangHoa : UserControl
    {
        ProcessDatabase dtBase = new ProcessDatabase();
        public int d = 8;    
        public HangHoa()
        {
            InitializeComponent();
            
            xeso1.BringToFront();
            dongco1.HangHoaForm = this;

        }

        private void HangHoa_Load(object sender, EventArgs e)
        {
                    
        }
        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }           

        private void xeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xeso1.BringToFront();
            DataTable dt = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh,SoLuong From Dmh");
            xeso1.SetDataGridViewDataSource(dt);
            d = 8;
        }

        private void phutungToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            dongco1.BringToFront();
            DataTable dt = dtBase.DocBang("SELECT * FROM DongCo");
            dongco1.SetDataGridViewDataSource(dt);
            d = 1;
            
        }
        private void phanhToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBase.DocBang("SELECT * FROM PhanhXe");
            dongco1.SetDataGridViewDataSource(dt);
            d = 2;
        }

        private void dongcoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBase.DocBang("SELECT * FROM DongCo");
            dongco1.SetDataGridViewDataSource(dt);
            d = 1;

        }
        private void mausacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBase.DocBang("SELECT * FROM MauSac");
            dongco1.SetDataGridViewDataSource(dt);
            d = 3;
        }
        private void theloaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBase.DocBang("SELECT * FROM TheLoai");
            dongco1.SetDataGridViewDataSource(dt);
            d = 4;
        }
        private void tinhtrangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBase.DocBang("SELECT * FROM TinhTrang");
            dongco1.SetDataGridViewDataSource(dt);
            d = 5;
        }
        private void hsxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBase.DocBang("SELECT * FROM Hangsanxuat");
            dongco1.SetDataGridViewDataSource(dt);
            d = 6;
        }
        private void nsxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBase.DocBang("SELECT * FROM Nuocsanxuat");
            dongco1.SetDataGridViewDataSource(dt);
            d = 7;
        }
        private void gaToolStripMenuItem1_Click(object sender, EventArgs e)
        {         
            DataTable dt = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh,SoLuong From Dmh where MaTheLoai='" + 1 + "'");
            xeso1.SetDataGridViewDataSource(dt);
            d = 8;
        }
        private void soToolStripMenuItem_Click(object sender, EventArgs e)
        {        
            DataTable dt = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh,SoLuong  From Dmh where MaTheLoai='" + 2 + "'");
            xeso1.SetDataGridViewDataSource(dt);
            d = 8;
        }
        private void conToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DataTable dt = dtBase.DocBang("Select MaHang,Anh,TenHang,NamSX,DonGiaBan,ThoiGianBaoHanh,SoLuong  From Dmh where MaTheLoai='" + 3 + "'");
            xeso1.SetDataGridViewDataSource(dt);
            d = 8;
        }

        private void ptthem_Click(object sender, EventArgs e)
        {
            

        }

        private void ptxoa_Click(object sender, EventArgs e)
        {
           
        }

        private void dongco1_Click(object sender, EventArgs e)
        {

        }

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}
	}
}
