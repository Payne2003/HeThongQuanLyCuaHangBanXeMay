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
    public partial class HistoryDeliver : UserControl
    {
        public static HistoryDeliver instance;
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter adapter;
        DataSet ds;
        public static HistoryDeliver Instance
        {
            get
            {
                if (instance == null) instance = new HistoryDeliver();
                return instance;
            }
        }
        public HistoryDeliver()
        {
            InitializeComponent();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "";
            sql = "SELECT COUNT(SOHDN) AS SoDonNhapTrongNgay, NgayNhap FROM HoaDonNhap WHERE NgayNhap ='" + dtpNhap.Value + "'" + "GROUP BY NgayNhap";
            LoadDuLieu_Nhap(sql);
            conn.Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "";
            sql = "SELECT COUNT(SoDDH) AS SoDonMuaTrongNgay ,NgayMua FROM DonDatHang WHERE NgayMua = '" + dtpDat.Value + "'" + "GROUP BY NgayMua";
            LoadDuLieu_Dat(sql);
        }

        private void btnReDat_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            LoadDuLieu_Dat("SELECT COUNT(SoDDH) AS SoDonMuaTrongNgay ,NgayMua FROM DonDatHang GROUP BY NgayMua");
            conn.Close();
        }

        private void HistoryDeliver_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-L935296;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
            LoadDuLieu_Nhap("SELECT COUNT(SOHDN) AS SoDonNhapTrongNgay, NgayNhap FROM HoaDonNhap GROUP BY NgayNhap");
            LoadDuLieu_Dat("SELECT COUNT(SoDDH) AS SoDonMuaTrongNgay ,NgayMua FROM DonDatHang GROUP BY NgayMua");
        }
        private void LoadDuLieu_Nhap(string sql)
        {
            ds = new DataSet();
            adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(ds);
            dgvNhap.DataSource = ds.Tables[0];
        }
        private void LoadDuLieu_Dat(string sql)
        {
            ds = new DataSet();
            adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(ds);
            dgvDat.DataSource = ds.Tables[0];
        }

        private void btnReNhap_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            LoadDuLieu_Nhap("SELECT COUNT(SOHDN) AS SoDonNhapTrongNgay, NgayNhap FROM HoaDonNhap GROUP BY NgayNhap");
            conn.Close();
        }
    }
}
