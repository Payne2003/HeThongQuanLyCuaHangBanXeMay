using Guna.UI2.WinForms;
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
    public partial class Account : UserControl
    {
        public Account()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            accountControl1.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            historyDeliver1.BringToFront();
        }
    }
}
