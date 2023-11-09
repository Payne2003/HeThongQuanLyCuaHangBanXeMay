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

namespace QLCHBX.FormHangHoa
{
    public partial class AddPhutung : Form
    {     
        ProcessDatabase dtBase = new ProcessDatabase();
        private int d;
        public AddPhutung(int d)
        {
            InitializeComponent();
            this.d = d;
        }
        
        private bool kiemtradl()
        {
            if (txtten.Text.Trim() == string.Empty )
                return false;
            return true;

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            

            if (kiemtradl() == false)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin vào chỗ trống.", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {            
                string ten = txtten.Text;
                if (d == 1)
                {                   
                    dtBase.CapNhatDuLieu("insert into DongCo values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                   
                }
                if (d == 2)
                {                  
                    dtBase.CapNhatDuLieu("insert into PhanhXe values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                                       
                }
                if (d == 3)
                {
                    dtBase.CapNhatDuLieu("insert into MauSac values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");                   
                }
                if (d == 4)
                {
                    dtBase.CapNhatDuLieu("insert into TheLoai values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");                  
                }
                if (d == 5)
                {
                    dtBase.CapNhatDuLieu("insert into TinhTrang values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                }
                if (d == 6)
                {
                    dtBase.CapNhatDuLieu("insert into Hangsanxuat values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");                   
                }
                if (d == 7)
                {
                    dtBase.CapNhatDuLieu("insert into Nuocsanxuat values(N'" + ten + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                }
                txtten.Text = "";
            }
            
            
        }

        private void AddPhutung_Load(object sender, EventArgs e)
        {
           
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
