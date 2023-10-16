using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.ThongBao
{
    public partial class MessageBoxForm : Form
    {
        private Timer timer = new Timer();
        public MessageBoxForm(string message)
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            messageLabel.Text = message;
            Controls.Add(messageLabel);

            timer.Interval = 1000; // 2 giây
            timer.Tick += (sender, e) => CloseForm();
            timer.Start();
        }

        private void CloseForm()
        {
            timer.Stop();
            timer.Dispose();
            Close();
        }

    }
}
