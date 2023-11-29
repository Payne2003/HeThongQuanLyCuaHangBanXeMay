namespace QLCHBX.FormGiaoDich
{
    partial class LichSuGia
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
            this.viewLichSuGia = new System.Windows.Forms.DataGridView();
            this.lbSanPham = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbMaHang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbTenHang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbDonGiaNhap = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbDonGiaBan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btThoat = new Guna.UI2.WinForms.Guna2Button();
            this.dtNgayNhap = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.ptHang = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.viewLichSuGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptHang)).BeginInit();
            this.SuspendLayout();
            // 
            // viewLichSuGia
            // 
            this.viewLichSuGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewLichSuGia.Location = new System.Drawing.Point(12, 31);
            this.viewLichSuGia.Name = "viewLichSuGia";
            this.viewLichSuGia.Size = new System.Drawing.Size(396, 357);
            this.viewLichSuGia.TabIndex = 0;
            this.viewLichSuGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.viewLichSuGia_CellClick);
            // 
            // lbSanPham
            // 
            this.lbSanPham.BackColor = System.Drawing.Color.Transparent;
            this.lbSanPham.Location = new System.Drawing.Point(414, 31);
            this.lbSanPham.Name = "lbSanPham";
            this.lbSanPham.Size = new System.Drawing.Size(57, 15);
            this.lbSanPham.TabIndex = 1;
            this.lbSanPham.Text = "Tên Hàng : ";
            // 
            // lbMaHang
            // 
            this.lbMaHang.BackColor = System.Drawing.Color.Transparent;
            this.lbMaHang.Location = new System.Drawing.Point(12, 10);
            this.lbMaHang.Name = "lbMaHang";
            this.lbMaHang.Size = new System.Drawing.Size(44, 15);
            this.lbMaHang.TabIndex = 1;
            this.lbMaHang.Text = "MaHang";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(414, 68);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(79, 15);
            this.guna2HtmlLabel2.TabIndex = 1;
            this.guna2HtmlLabel2.Text = "Giá nhập hàng :";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(415, 103);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(61, 15);
            this.guna2HtmlLabel3.TabIndex = 1;
            this.guna2HtmlLabel3.Text = "Ngày nhập :";
            // 
            // lbTenHang
            // 
            this.lbTenHang.BackColor = System.Drawing.Color.Transparent;
            this.lbTenHang.Location = new System.Drawing.Point(475, 31);
            this.lbTenHang.Name = "lbTenHang";
            this.lbTenHang.Size = new System.Drawing.Size(22, 15);
            this.lbTenHang.TabIndex = 1;
            this.lbTenHang.Text = "Tên";
            // 
            // lbDonGiaNhap
            // 
            this.lbDonGiaNhap.BackColor = System.Drawing.Color.Transparent;
            this.lbDonGiaNhap.Location = new System.Drawing.Point(492, 68);
            this.lbDonGiaNhap.Name = "lbDonGiaNhap";
            this.lbDonGiaNhap.Size = new System.Drawing.Size(45, 15);
            this.lbDonGiaNhap.TabIndex = 1;
            this.lbDonGiaNhap.Text = "GiaNhap";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(414, 151);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(73, 15);
            this.guna2HtmlLabel6.TabIndex = 1;
            this.guna2HtmlLabel6.Text = "Giá bán hàng : ";
            // 
            // lbDonGiaBan
            // 
            this.lbDonGiaBan.BackColor = System.Drawing.Color.Transparent;
            this.lbDonGiaBan.Location = new System.Drawing.Point(492, 151);
            this.lbDonGiaBan.Name = "lbDonGiaBan";
            this.lbDonGiaBan.Size = new System.Drawing.Size(38, 15);
            this.lbDonGiaBan.TabIndex = 1;
            this.lbDonGiaBan.Text = "GiaBan";
            // 
            // btThoat
            // 
            this.btThoat.BorderColor = System.Drawing.Color.Gray;
            this.btThoat.BorderRadius = 1;
            this.btThoat.BorderThickness = 1;
            this.btThoat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btThoat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btThoat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btThoat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btThoat.FillColor = System.Drawing.Color.MintCream;
            this.btThoat.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.btThoat.ForeColor = System.Drawing.Color.Black;
            this.btThoat.ImageSize = new System.Drawing.Size(40, 40);
            this.btThoat.Location = new System.Drawing.Point(419, 348);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(165, 39);
            this.btThoat.TabIndex = 3;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // dtNgayNhap
            // 
            this.dtNgayNhap.Checked = true;
            this.dtNgayNhap.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayNhap.Location = new System.Drawing.Point(491, 103);
            this.dtNgayNhap.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtNgayNhap.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtNgayNhap.Name = "dtNgayNhap";
            this.dtNgayNhap.Size = new System.Drawing.Size(103, 29);
            this.dtNgayNhap.TabIndex = 4;
            this.dtNgayNhap.Value = new System.DateTime(2023, 11, 28, 13, 44, 31, 628);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.LightGray;
            // 
            // ptHang
            // 
            this.ptHang.Location = new System.Drawing.Point(419, 188);
            this.ptHang.Name = "ptHang";
            this.ptHang.Size = new System.Drawing.Size(166, 137);
            this.ptHang.TabIndex = 2;
            this.ptHang.TabStop = false;
            // 
            // LichSuGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.dtNgayNhap);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.ptHang);
            this.Controls.Add(this.lbMaHang);
            this.Controls.Add(this.lbDonGiaBan);
            this.Controls.Add(this.lbDonGiaNhap);
            this.Controls.Add(this.lbTenHang);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.lbSanPham);
            this.Controls.Add(this.viewLichSuGia);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LichSuGia";
            this.Text = "LichSuGia";
            this.Load += new System.EventHandler(this.LichSuGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewLichSuGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView viewLichSuGia;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbSanPham;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTenHang;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbDonGiaNhap;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbDonGiaBan;
        private System.Windows.Forms.PictureBox ptHang;
        private Guna.UI2.WinForms.Guna2Button btThoat;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtNgayNhap;
        public Guna.UI2.WinForms.Guna2HtmlLabel lbMaHang;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
    }
}