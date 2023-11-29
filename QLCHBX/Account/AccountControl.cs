using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.Account
{
    public partial class AccountControl : UserControl
    {
        private static AccountControl instance;
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;
        public static AccountControl Instance
        {
            get
            {
                if (instance == null) instance = new AccountControl();
                return instance;
            }
        }
        public AccountControl()
        {
            conn.ConnectionString = @"Data Source=DESKTOP-L935296;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
            InitializeComponent();
        }
        private void LoadDuLieu(string sql)
        {
            ds = new DataSet();
            adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(ds);
            dgvUser.DataSource = ds.Tables[0];
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtUserName.ReadOnly = false;
            txtMaNV.Text = "";
            txtUserName.Text = "";
            txtPassWord.Text = "";
            txtTimKiem.Text = "";
            LoadDuLieu("SELECT * FROM TaiKhoan");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa User " + txtUserName.Text + " không ?", "Xóa sản phẩm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int currentIndex = dgvUser.CurrentCell.RowIndex;
                    string userName = Convert.ToString(dgvUser.Rows[currentIndex].Cells[0].Value.ToString());
                    string sql = "DELETE FROM TaiKhoan WHERE Username = '" + userName + "'";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = "SELECT * FROM TaiKhoan";
                    LoadDuLieu(sql);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (txtUserName.Text.Trim() == "")
            {
                errAccount.SetError(txtUserName, "UserName không được để trống");
                return;
            }
            else
            {
                errAccount.Clear();
            }
            if (txtPassWord.Text.Trim() == "")
            {
                errAccount.SetError(txtPassWord, "Password không được để trống");
                return;
            }
            else
            {
                errAccount.Clear();
            }
            if (txtMaNV.Text.Trim() == "")
            {
                errAccount.SetError(txtMaNV, "Mã Nhân viên không được trống");
                return;
            }
            else
            {
                errAccount.Clear();
            }
            sql = "SELECT COUNT(*) FROM TaiKhoan WHERE Username = N'" + txtUserName.Text + "'";
            cmd = new SqlCommand(sql, conn);
            int val = (int)cmd.ExecuteScalar();
            if (val > 0)
            {
                errAccount.SetError(txtUserName, "UserName không được trùng");
                return;
            }
            else
            {
                errAccount.Clear();
            }
            sql = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = '" + txtMaNV.Text + "'";
            cmd = new SqlCommand(sql, conn);
            int sum = (int)cmd.ExecuteScalar();
            if(sum == 0)
            {
                errAccount.SetError(txtMaNV, "Không có nhân viên có mã là " + txtMaNV.Text + " tồn tại");
                return;
            }
            else
            {
                errAccount.Clear();
            }
            sql = "INSERT INTO TaiKhoan(Username,Password,MaNV)VALUES(";
            sql += "N'" + txtUserName.Text + "',N'" + txtPassWord.Text + "','" + txtMaNV.Text + "')";
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            sql = "SELECT * FROM TaiKhoan";
            LoadDuLieu(sql);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (txtUserName.Text.Trim() == "")
            {
                errAccount.SetError(txtUserName, "UserName không được để trống");
                return;
            }
            else
            {
                errAccount.Clear();
            }
            if (txtPassWord.Text.Trim() == "")
            {
                errAccount.SetError(txtPassWord, "Password không được để trống");
                return;
            }
            else
            {
                errAccount.Clear();
            }
            if (txtMaNV.Text.Trim() == "")
            {
                errAccount.SetError(txtMaNV, "Mã Nhân viên không được trống");
                return;
            }
            else
            {
                errAccount.Clear();
            }
            int index = dgvUser.CurrentRow.Index;
            sql = "UPDATE TaiKhoan SET ";
            sql += "Password = N'" + txtPassWord.Text + "', MaNV = '" + txtMaNV.Text + "' WHERE Username = '" + txtUserName.Text + "'";
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            sql = "SELECT * FROM TaiKhoan";
            LoadDuLieu(sql);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "";
            sql = "SELECT COUNT(*) FROM TaiKhoan WHERE Username = N'" + txtTimKiem.Text + "'";
            cmd = new SqlCommand(sql, conn);
            int val = (int)cmd.ExecuteScalar();
            if (val == 0)
            {
                MessageBox.Show("Không tìm thấy tài khoản có tên " + txtTimKiem.Text + "!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            LoadDuLieu("SELECT * FROM TaiKhoan WHERE Username = N'" + txtTimKiem.Text + "'");
            conn.Close();
        }
        private void dgvUser_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtUserName.Text = dgvUser[0, e.RowIndex].Value.ToString();
                txtPassWord.Text = dgvUser[1, e.RowIndex].Value.ToString();
                txtMaNV.Text = dgvUser[2, e.RowIndex].Value.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtUserName.ReadOnly = true;
                txtUserName.Text = dgvUser[0, e.RowIndex].Value.ToString();
                txtPassWord.Text = dgvUser[1, e.RowIndex].Value.ToString();
                txtMaNV.Text = dgvUser[2, e.RowIndex].Value.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private void AccountControl_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-L935296;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
            LoadDuLieu("SELECT * FROM TaiKhoan");
        }
    }
}
