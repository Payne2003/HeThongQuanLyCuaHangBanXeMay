using QLCHBX.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.FormGiaoDich.FormLoaiXe
{
   
    public partial class Xe : UserControl
    {
       
        string fileAnh;
        public Xe()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            HangSanXuatModel hangSanXuatModel = new HangSanXuatModel();
            DmhModel dmhModel = new DmhModel();
            txtBanChay.Text = hangSanXuatModel.HangSXBanChay();
            viewDmhHang.DataSource = dmhModel.LayDuLieuDmh();
            DataTable dtHangSX = hangSanXuatModel.LayDuLieuHangSX();
            cbHangXe.DataSource = dtHangSX;
            cbHangXe.DisplayMember = "TenHangSX";
            cbHangXe.ValueMember = "MaHangSX";
            ptHang.Image=null;
            
        }

        private void btThemSP_Click(object sender, EventArgs e)
        {
            ThemDMhang themDMhang = new ThemDMhang();
            themDMhang.lbMaHoaDon.Text = txtSoDDH.Text;
            themDMhang.txtSoDDH.Text = txtSoDDH.Text;
            themDMhang.ShowDialog(this);
        }

        private void cbHangXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHangXe.SelectedItem != null)
            {
                if (cbHangXe.SelectedItem is DataRowView)
                {
                    string ID = ((DataRowView)cbHangXe.SelectedItem)["MaHangSX"].ToString();
                    string tenHang = cbHangXe.Text;
                    lbHang.Text = tenHang;
                    HangSanXuatModel hangSanXuatModel = new HangSanXuatModel(int.Parse(ID));
                    fileAnh = hangSanXuatModel.layFileAnh();
                    DmhModel dmh = new DmhModel();
                    viewDmhHang.DataSource = dmh.LayDuLieuDmhTheoMaHangSX(ID);
                    if (File.Exists(fileAnh))
                    {
                        ptHang.Image = Image.FromFile(fileAnh);
                    }
                    else
                    {
                        ptHang.Image = null;
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void Xe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btThemNSX_Click(object sender, EventArgs e)
        {
            ThemHangSX themHangSX = new ThemHangSX();
            themHangSX.Show();
        }

        private void btCapnhat_Click(object sender, EventArgs e)
        {
            if (ptHang.Image == null)
            {
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn cập nhật ảnh của hãng "+cbHangXe.Text+" không?", "Xác nhận cập nhật ảnh",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string ID = ((DataRowView)cbHangXe.SelectedItem)["MaHangSX"].ToString();
                    string tenHang = cbHangXe.Text;
                    HangSanXuatModel hangSanXuatModel = new HangSanXuatModel(int.Parse(ID),tenHang,fileAnh);
                    hangSanXuatModel.CapNhatHangSX();
                    LoadData();
                }
            }
           
        }


        private void btChonanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPEG Image|*.jpg|PNG Image|*.png|All files|*.*";
            openFile.FilterIndex = 1;
            openFile.InitialDirectory = Application.StartupPath;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ptHang.Image = Image.FromFile(openFile.FileName);
                fileAnh = openFile.FileName; // Lấy đường dẫn của tệp tin đã chọn
                MessageBox.Show(fileAnh);
            }
        }
    }
}
