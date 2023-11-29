using QLCHBX.FormHangHoa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.HanghoaControl
{
    public partial class Nhacungcap : UserControl
    {
        ProcessDatabase dtBase = new ProcessDatabase();
        public void Load()
        {
            btnLuu.Enabled = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pn1.Visible = false;
        }
        public Nhacungcap()
        {
            InitializeComponent();
            DataTable dt = dtBase.DocBang("Select * From NhaCungCap");
            dgv.DataSource = dt;
            Load();
        }

        private void Nhacungcap_Load(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgv.SelectedRows[0];

            string maNCC = selectedRow.Cells["MaNCC"].Value.ToString();
            if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp có mã là:" + maNCC + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtBase.CapNhatDuLieu("delete NhaCungCap where MaNCC='" + maNCC + "'");
                MessageBox.Show("Xóa thành công", "Thông báo");
                dgv.DataSource = dtBase.DocBang("Select * From NhaCungCap");
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                {
                    pn1.Visible = true;
                    txtMa.Text = row.Cells[0].Value.ToString();
                    txtTen.Text = row.Cells[1].Value.ToString();
                    txtdc.Text = row.Cells[2].Value.ToString();
                    txtsdt.Text = row.Cells[3].Value.ToString();

                    btnLuu.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ở Ô: " + e.RowIndex + ", Vui lòng thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text;
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
            }
            else
            {
                dgv.DataSource = dtBase.DocBang("Select * From NhaCungCap where DienThoai like N'%" + key + "%' OR DiaChi LIKE N'%" + key + "%' OR TenNCC LIKE N'%" + key + "%'");
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgv.SelectedRows[0];

            string maNCC = selectedRow.Cells[0].Value.ToString();
            if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp có mã là:" + maNCC + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtBase.CapNhatDuLieu("delete NhaCUngCap where MaNCC='" + maNCC + "'");
                MessageBox.Show("Bạn đã xóa thành công", "Thông báo");
                dgv.DataSource = dtBase.DocBang("Select * From NhaCungCap");
                Load();
            }
        }

        private void ptThem_Click(object sender, EventArgs e)
        {
            pn1.Visible = true;
            txtMa.Text = "";
            btnLuu.Enabled = true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "")
            {
                if (txtTen.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tên nhà cung cấp.", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtdc.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ nhà cung cấp.", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!IsValidPhoneNumber(txtsdt.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 số.", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    dtBase.CapNhatDuLieu("insert into NhaCungCap values(N'" + txtTen.Text + "', N'" + txtdc.Text + "', N'" + txtsdt.Text + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                    dgv.DataSource = dtBase.DocBang("SELECT * FROM NhaCungCap");
                }
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn sửa nhà cung cấp có mã là:" + txtMa.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!IsValidPhoneNumber(txtsdt.Text))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 số.", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        dtBase.CapNhatDuLieu("update NhaCungCap set TenNCC = N'" + txtTen.Text + "', DiaChi = N'" + txtdc.Text + "', DienThoai = N'" + txtsdt.Text + "' where MaNCC = '" + txtMa.Text + "'");
                        MessageBox.Show("Bạn đã sửa thành công");
                        dgv.DataSource = dtBase.DocBang("SELECT * FROM NhaCungCap");
                        ptLoad_Click(sender, e);
                    }
                }
            }
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }

        private void ptLoad_Click(object sender, EventArgs e)
        {
            Load();
            txtMa.Text = "";
            txtTen.Text = "";
            txtdc.Text = "";
            txtsdt.Text = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                dgv.DataSource = dtBase.DocBang("SELECT * FROM NhaCungCap");
            }
        }
    }
}