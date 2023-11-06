using QLCHBX.FormGiaoDich;
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

namespace QLCHBX.ALLControl
{
    public partial class GiaoDichCT : UserControl
    {
        public GiaoDichCT()
        {
            InitializeComponent();
        }

        public void LoadDataGridView()
        {
            grthongtindonhang.Visible = false;
            btThanhToan.Visible = false;
            btCapNhat.Visible = false;
            btTaoHoaDon.Visible = true;
        }
        public bool KiemTraTextRong()
        {
            return false;
        }
        public void SaveDataGridView() 
        {
            DonDatHangModel donDatHangCapNhat = new DonDatHangModel();
            donDatHangCapNhat.CapNhatDonDatHang(int.Parse(txtSoDDH.Text), DateTime.Parse(dtNgayNhap.Text), decimal.Parse(txtDatCoc.Text), decimal.Parse(txtThue.Text), decimal.Parse(txtTongTien.Text));
        }
        private void viewDonDatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rowDonDatHang = viewDonDatHang.Rows[e.RowIndex];
                if (rowDonDatHang.Cells[0].Value != null || rowDonDatHang.Cells[0].Value.ToString() == "")
                {
                    btCapNhat.Visible = true;
                    btThanhToan.Visible = true;
                    btTaoHoaDon.Visible = false;
                    txtSoDDH.Text = rowDonDatHang.Cells[0].Value.ToString();
                    txtMaNV.Text = rowDonDatHang.Cells[1].Value.ToString();
                    txtTenNV.Text = rowDonDatHang.Cells[2].Value.ToString();
                    txtThue.Text = rowDonDatHang.Cells[3].Value.ToString();
                    txtDatCoc.Text = rowDonDatHang.Cells[4].Value.ToString();
                    dtNgayNhap.Text = rowDonDatHang.Cells[5].Value.ToString();
                    txtTongTien.Text = rowDonDatHang.Cells[6].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void btOderHangHoa_Click(object sender, EventArgs e)
        {

        }

        private void viewDonDatHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rowDonDatHang = viewDonDatHang.Rows[e.RowIndex];
                if (rowDonDatHang.Cells[0].Value != null || rowDonDatHang.Cells[0].Value.ToString() == "")
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa đơn hàng " + rowDonDatHang.Cells[0].Value.ToString() + " ?", "Xác Nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GiaoDichCT_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            GiaoDich giaoDich = new GiaoDich();
        }

        private void btToaHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {

        }
    }
}
