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

namespace QLCHBX.ALLControl
{
    public partial class HangHoa : UserControl
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DuyLa;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From Dongco";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv1.DataSource = table;
           
        }
        public HangHoa()
        {
            InitializeComponent();
            //phanh1.Visible = false;
            //dongco1.Visible = false;
            xeso1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void HangHoa_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void phanhToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //phanh1.Visible = true;
            phanh1.BringToFront();
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void độngCơToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //dongco1.Visible=true;
            dongco1.BringToFront();
        }

        private void maToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mausac1.BringToFront();
        }

        private void thểLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            theloai1.BringToFront();
        }

        private void tìnhTrạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tinhtrang1.BringToFront();
        }

        private void hăngSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hangsanxuat1.BringToFront();
        }

        private void nướcSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuocsanxuat1.BringToFront();
        }

        private void gaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void soToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xeso1.BringToFront();
        }
    }
}
