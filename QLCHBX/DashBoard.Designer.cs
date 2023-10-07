namespace QLCHBX
{
    partial class DashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnhead = new Guna.UI2.WinForms.Guna2Panel();
            this.btKhachhang = new Guna.UI2.WinForms.Guna2Button();
            this.pnMoving = new Guna.UI2.WinForms.Guna2Panel();
            this.btNhanvien = new Guna.UI2.WinForms.Guna2Button();
            this.btDoitac = new Guna.UI2.WinForms.Guna2Button();
            this.btGiaoDich = new Guna.UI2.WinForms.Guna2Button();
            this.btHangHoa = new Guna.UI2.WinForms.Guna2Button();
            this.btBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.pnControlDashBoard = new Guna.UI2.WinForms.Guna2Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.khachhang1 = new QLCHBX.ALLControl.Khachhang();
            this.pnhead.SuspendLayout();
            this.pnControlDashBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnhead
            // 
            this.pnhead.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pnhead.BorderRadius = 20;
            this.pnhead.Controls.Add(this.btKhachhang);
            this.pnhead.Controls.Add(this.pnMoving);
            this.pnhead.Controls.Add(this.btNhanvien);
            this.pnhead.Controls.Add(this.btDoitac);
            this.pnhead.Controls.Add(this.btGiaoDich);
            this.pnhead.Controls.Add(this.btHangHoa);
            this.pnhead.Controls.Add(this.btBaoCao);
            this.pnhead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnhead.Location = new System.Drawing.Point(0, 0);
            this.pnhead.Name = "pnhead";
            this.pnhead.Size = new System.Drawing.Size(1386, 65);
            this.pnhead.TabIndex = 1;
            // 
            // btKhachhang
            // 
            this.btKhachhang.BorderRadius = 5;
            this.btKhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btKhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btKhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btKhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btKhachhang.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btKhachhang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btKhachhang.ForeColor = System.Drawing.Color.White;
            this.btKhachhang.HoverState.BorderColor = System.Drawing.Color.Black;
            this.btKhachhang.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btKhachhang.HoverState.FillColor = System.Drawing.Color.White;
            this.btKhachhang.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btKhachhang.Location = new System.Drawing.Point(1062, 12);
            this.btKhachhang.Name = "btKhachhang";
            this.btKhachhang.Size = new System.Drawing.Size(204, 45);
            this.btKhachhang.TabIndex = 6;
            this.btKhachhang.Text = "Khách hàng";
            this.btKhachhang.Click += new System.EventHandler(this.btKhachhang_Click);
            // 
            // pnMoving
            // 
            this.pnMoving.AutoRoundedCorners = true;
            this.pnMoving.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnMoving.Location = new System.Drawing.Point(12, 60);
            this.pnMoving.Name = "pnMoving";
            this.pnMoving.Size = new System.Drawing.Size(204, 2);
            this.pnMoving.TabIndex = 5;
            // 
            // btNhanvien
            // 
            this.btNhanvien.BorderRadius = 5;
            this.btNhanvien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btNhanvien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btNhanvien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btNhanvien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btNhanvien.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btNhanvien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btNhanvien.ForeColor = System.Drawing.Color.White;
            this.btNhanvien.HoverState.BorderColor = System.Drawing.Color.Black;
            this.btNhanvien.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btNhanvien.HoverState.FillColor = System.Drawing.Color.White;
            this.btNhanvien.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btNhanvien.Location = new System.Drawing.Point(852, 12);
            this.btNhanvien.Name = "btNhanvien";
            this.btNhanvien.Size = new System.Drawing.Size(204, 45);
            this.btNhanvien.TabIndex = 4;
            this.btNhanvien.Text = "Nhân viên";
            this.btNhanvien.Click += new System.EventHandler(this.btNhanvien_Click);
            // 
            // btDoitac
            // 
            this.btDoitac.BorderRadius = 5;
            this.btDoitac.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btDoitac.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btDoitac.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btDoitac.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btDoitac.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btDoitac.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btDoitac.ForeColor = System.Drawing.Color.White;
            this.btDoitac.HoverState.BorderColor = System.Drawing.Color.Black;
            this.btDoitac.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btDoitac.HoverState.FillColor = System.Drawing.Color.White;
            this.btDoitac.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btDoitac.Location = new System.Drawing.Point(642, 12);
            this.btDoitac.Name = "btDoitac";
            this.btDoitac.Size = new System.Drawing.Size(204, 45);
            this.btDoitac.TabIndex = 3;
            this.btDoitac.Text = "Đối Tác";
            this.btDoitac.Click += new System.EventHandler(this.btDoitac_Click);
            // 
            // btGiaoDich
            // 
            this.btGiaoDich.BorderRadius = 5;
            this.btGiaoDich.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btGiaoDich.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btGiaoDich.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btGiaoDich.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btGiaoDich.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btGiaoDich.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btGiaoDich.ForeColor = System.Drawing.Color.White;
            this.btGiaoDich.HoverState.BorderColor = System.Drawing.Color.Black;
            this.btGiaoDich.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btGiaoDich.HoverState.FillColor = System.Drawing.Color.White;
            this.btGiaoDich.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btGiaoDich.Location = new System.Drawing.Point(432, 10);
            this.btGiaoDich.Name = "btGiaoDich";
            this.btGiaoDich.Size = new System.Drawing.Size(204, 45);
            this.btGiaoDich.TabIndex = 2;
            this.btGiaoDich.Text = "Giao Dịch";
            this.btGiaoDich.Click += new System.EventHandler(this.btGiaoDich_Click);
            // 
            // btHangHoa
            // 
            this.btHangHoa.BorderRadius = 5;
            this.btHangHoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btHangHoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btHangHoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btHangHoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btHangHoa.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btHangHoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btHangHoa.ForeColor = System.Drawing.Color.White;
            this.btHangHoa.HoverState.BorderColor = System.Drawing.Color.Black;
            this.btHangHoa.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btHangHoa.HoverState.FillColor = System.Drawing.Color.White;
            this.btHangHoa.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btHangHoa.Location = new System.Drawing.Point(222, 10);
            this.btHangHoa.Name = "btHangHoa";
            this.btHangHoa.Size = new System.Drawing.Size(204, 45);
            this.btHangHoa.TabIndex = 1;
            this.btHangHoa.Text = "Hàng Hóa";
            this.btHangHoa.Click += new System.EventHandler(this.btHangHoa_Click);
            // 
            // btBaoCao
            // 
            this.btBaoCao.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btBaoCao.BorderRadius = 5;
            this.btBaoCao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btBaoCao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btBaoCao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btBaoCao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btBaoCao.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btBaoCao.FocusedColor = System.Drawing.Color.White;
            this.btBaoCao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btBaoCao.ForeColor = System.Drawing.Color.White;
            this.btBaoCao.HoverState.BorderColor = System.Drawing.Color.Black;
            this.btBaoCao.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btBaoCao.HoverState.FillColor = System.Drawing.Color.White;
            this.btBaoCao.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btBaoCao.Location = new System.Drawing.Point(12, 12);
            this.btBaoCao.Name = "btBaoCao";
            this.btBaoCao.Size = new System.Drawing.Size(204, 45);
            this.btBaoCao.TabIndex = 0;
            this.btBaoCao.Text = "Báo Cáo";
            this.btBaoCao.Click += new System.EventHandler(this.btBaoCao_Click);
            // 
            // pnControlDashBoard
            // 
            this.pnControlDashBoard.Controls.Add(this.khachhang1);
            this.pnControlDashBoard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnControlDashBoard.Location = new System.Drawing.Point(0, 63);
            this.pnControlDashBoard.Name = "pnControlDashBoard";
            this.pnControlDashBoard.Size = new System.Drawing.Size(1386, 725);
            this.pnControlDashBoard.TabIndex = 2;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // khachhang1
            // 
            this.khachhang1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.khachhang1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.khachhang1.Location = new System.Drawing.Point(0, 0);
            this.khachhang1.Name = "khachhang1";
            this.khachhang1.Size = new System.Drawing.Size(1386, 725);
            this.khachhang1.TabIndex = 0;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.pnhead);
            this.Controls.Add(this.pnControlDashBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashBoard";
            this.pnhead.ResumeLayout(false);
            this.pnControlDashBoard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnhead;
        private Guna.UI2.WinForms.Guna2Panel pnControlDashBoard;
        private Guna.UI2.WinForms.Guna2Button btBaoCao;
        private Guna.UI2.WinForms.Guna2Button btNhanvien;
        private Guna.UI2.WinForms.Guna2Button btDoitac;
        private Guna.UI2.WinForms.Guna2Button btGiaoDich;
        private Guna.UI2.WinForms.Guna2Button btHangHoa;
        private Guna.UI2.WinForms.Guna2Panel pnMoving;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Button btKhachhang;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private ALLControl.Khachhang khachhang1;
    }
}