using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.Account
{
    public partial class taiKhoan : UserControl
    {
        public taiKhoan()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!guna2Panel2.Controls.Contains(AccountControl.Instance))
            {
                guna2Panel2.Controls.Add(AccountControl.Instance);
                AccountControl.Instance.BringToFront();
            }
            else
            {
                AccountControl.Instance.BringToFront();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!guna2Panel2.Controls.Contains(HistoryDeliver.Instance))
            {
                guna2Panel2.Controls.Add(HistoryDeliver.Instance);
                HistoryDeliver.Instance.BringToFront();
            }
            else
            {
                HistoryDeliver.Instance.BringToFront();
            }
        }
    }
}
