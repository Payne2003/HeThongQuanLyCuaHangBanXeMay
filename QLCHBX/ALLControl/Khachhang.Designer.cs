﻿namespace QLCHBX.ALLControl
{
    partial class KhachHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KhachHang));
            this.ptLoad = new Guna.UI2.WinForms.Guna2PictureBox();
            this.viewKhachhang = new System.Windows.Forms.DataGridView();
            this.Sua = new System.Windows.Forms.DataGridViewButtonColumn();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lbLoad = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btThemKhachHang = new Guna.UI2.WinForms.Guna2Button();
            this.txtSsearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.grThongtinKhachHang = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtDienThoai = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTenKhach = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtDiaChi = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtMaKhach = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ptLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewKhachhang)).BeginInit();
            this.guna2GroupBox2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel5.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.grThongtinKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ptLoad
            // 
            this.ptLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptLoad.BackColor = System.Drawing.Color.Transparent;
            this.ptLoad.FillColor = System.Drawing.Color.Transparent;
            this.ptLoad.Image = ((System.Drawing.Image)(resources.GetObject("ptLoad.Image")));
            this.ptLoad.ImageRotate = 0F;
            this.ptLoad.Location = new System.Drawing.Point(783, 0);
            this.ptLoad.Name = "ptLoad";
            this.ptLoad.Size = new System.Drawing.Size(38, 40);
            this.ptLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptLoad.TabIndex = 7;
            this.ptLoad.TabStop = false;
            this.ptLoad.Click += new System.EventHandler(this.ptLoad_Click);
            // 
            // viewKhachhang
            // 
            this.viewKhachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewKhachhang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sua});
            this.viewKhachhang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewKhachhang.Location = new System.Drawing.Point(0, 40);
            this.viewKhachhang.Name = "viewKhachhang";
            this.viewKhachhang.ReadOnly = true;
            this.viewKhachhang.Size = new System.Drawing.Size(824, 556);
            this.viewKhachhang.TabIndex = 0;
            this.viewKhachhang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.viewKhachhang_CellClick);
            this.viewKhachhang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.viewKhachhang_CellDoubleClick);
            // 
            // Sua
            // 
            this.Sua.HeaderText = "Sửa";
            this.Sua.MinimumWidth = 10;
            this.Sua.Name = "Sua";
            this.Sua.ReadOnly = true;
            this.Sua.Text = "Sửa";
            this.Sua.ToolTipText = "Sửa";
            this.Sua.Width = 10;
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Controls.Add(this.lbLoad);
            this.guna2GroupBox2.Controls.Add(this.guna2HtmlLabel5);
            this.guna2GroupBox2.Controls.Add(this.ptLoad);
            this.guna2GroupBox2.Controls.Add(this.viewKhachhang);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.MintCream;
            this.guna2GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox2.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(824, 596);
            this.guna2GroupBox2.TabIndex = 1;
            this.guna2GroupBox2.Text = "Danh sách khách hàng tri ân";
            // 
            // lbLoad
            // 
            this.lbLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLoad.BackColor = System.Drawing.Color.Transparent;
            this.lbLoad.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoad.Location = new System.Drawing.Point(753, 13);
            this.lbLoad.Name = "lbLoad";
            this.lbLoad.Size = new System.Drawing.Size(26, 15);
            this.lbLoad.TabIndex = 8;
            this.lbLoad.Text = "Load";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.Red;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(225, 13);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(135, 15);
            this.guna2HtmlLabel5.TabIndex = 8;
            this.guna2HtmlLabel5.Text = "Ấn 2 lần để xóa khách hàng";
            this.guna2HtmlLabel5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.guna2GroupBox2);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 152);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(824, 596);
            this.guna2Panel3.TabIndex = 1;
            // 
            // btThemKhachHang
            // 
            this.btThemKhachHang.BorderColor = System.Drawing.Color.Silver;
            this.btThemKhachHang.BorderThickness = 1;
            this.btThemKhachHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btThemKhachHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btThemKhachHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btThemKhachHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btThemKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btThemKhachHang.FillColor = System.Drawing.Color.MintCream;
            this.btThemKhachHang.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThemKhachHang.ForeColor = System.Drawing.Color.Black;
            this.btThemKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("btThemKhachHang.Image")));
            this.btThemKhachHang.ImageSize = new System.Drawing.Size(50, 50);
            this.btThemKhachHang.Location = new System.Drawing.Point(0, 80);
            this.btThemKhachHang.Name = "btThemKhachHang";
            this.btThemKhachHang.Size = new System.Drawing.Size(369, 72);
            this.btThemKhachHang.TabIndex = 0;
            this.btThemKhachHang.Text = "Thêm khách hàng mới";
            this.btThemKhachHang.Click += new System.EventHandler(this.btThemKhachHang_Click);
            // 
            // txtSsearch
            // 
            this.txtSsearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSsearch.DefaultText = "";
            this.txtSsearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSsearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSsearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSsearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSsearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSsearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSsearch.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.txtSsearch.ForeColor = System.Drawing.Color.Black;
            this.txtSsearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSsearch.Location = new System.Drawing.Point(0, 0);
            this.txtSsearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSsearch.Name = "txtSsearch";
            this.txtSsearch.PasswordChar = '\0';
            this.txtSsearch.PlaceholderText = "Tìm kiếm theo số điện thoại hoặc tên khách hàng hoặc địa chỉ\r\n";
            this.txtSsearch.SelectedText = "";
            this.txtSsearch.Size = new System.Drawing.Size(238, 80);
            this.txtSsearch.TabIndex = 1;
            this.txtSsearch.TextChanged += new System.EventHandler(this.txtSsearch_TextChanged);
            this.txtSsearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSsearch_KeyPress);
            // 
            // btTimKiem
            // 
            this.btTimKiem.BorderColor = System.Drawing.Color.Gainsboro;
            this.btTimKiem.BorderThickness = 1;
            this.btTimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btTimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btTimKiem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btTimKiem.FillColor = System.Drawing.Color.MintCream;
            this.btTimKiem.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btTimKiem.ForeColor = System.Drawing.Color.Black;
            this.btTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btTimKiem.Image")));
            this.btTimKiem.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btTimKiem.ImageSize = new System.Drawing.Size(40, 40);
            this.btTimKiem.Location = new System.Drawing.Point(238, 0);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.Size = new System.Drawing.Size(131, 80);
            this.btTimKiem.TabIndex = 3;
            this.btTimKiem.Text = "Tìm kiếm";
            this.btTimKiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.Controls.Add(this.txtSsearch);
            this.guna2Panel5.Controls.Add(this.btTimKiem);
            this.guna2Panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel5.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.Size = new System.Drawing.Size(369, 80);
            this.guna2Panel5.TabIndex = 2;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.btThemKhachHang);
            this.guna2Panel2.Controls.Add(this.guna2Panel5);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(455, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(369, 152);
            this.guna2Panel2.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.grThongtinKhachHang);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(824, 152);
            this.guna2Panel1.TabIndex = 2;
            // 
            // grThongtinKhachHang
            // 
            this.grThongtinKhachHang.Controls.Add(this.txtDienThoai);
            this.grThongtinKhachHang.Controls.Add(this.guna2HtmlLabel4);
            this.grThongtinKhachHang.Controls.Add(this.txtTenKhach);
            this.grThongtinKhachHang.Controls.Add(this.guna2HtmlLabel3);
            this.grThongtinKhachHang.Controls.Add(this.txtDiaChi);
            this.grThongtinKhachHang.Controls.Add(this.guna2HtmlLabel2);
            this.grThongtinKhachHang.Controls.Add(this.txtMaKhach);
            this.grThongtinKhachHang.Controls.Add(this.guna2HtmlLabel1);
            this.grThongtinKhachHang.Controls.Add(this.guna2PictureBox1);
            this.grThongtinKhachHang.CustomBorderColor = System.Drawing.Color.MintCream;
            this.grThongtinKhachHang.Dock = System.Windows.Forms.DockStyle.Left;
            this.grThongtinKhachHang.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grThongtinKhachHang.ForeColor = System.Drawing.Color.Black;
            this.grThongtinKhachHang.Location = new System.Drawing.Point(0, 0);
            this.grThongtinKhachHang.Name = "grThongtinKhachHang";
            this.grThongtinKhachHang.Size = new System.Drawing.Size(455, 152);
            this.grThongtinKhachHang.TabIndex = 2;
            this.grThongtinKhachHang.Text = "Thông tin khách hàng";
            this.grThongtinKhachHang.Visible = false;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDienThoai.DefaultText = "";
            this.txtDienThoai.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDienThoai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDienThoai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDienThoai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDienThoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDienThoai.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDienThoai.ForeColor = System.Drawing.Color.Black;
            this.txtDienThoai.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDienThoai.Location = new System.Drawing.Point(237, 111);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.PasswordChar = '\0';
            this.txtDienThoai.PlaceholderText = "";
            this.txtDienThoai.ReadOnly = true;
            this.txtDienThoai.SelectedText = "";
            this.txtDienThoai.Size = new System.Drawing.Size(209, 26);
            this.txtDienThoai.TabIndex = 9;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(237, 90);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(64, 15);
            this.guna2HtmlLabel4.TabIndex = 8;
            this.guna2HtmlLabel4.Text = "Số điện thoại";
            // 
            // txtTenKhach
            // 
            this.txtTenKhach.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenKhach.DefaultText = "";
            this.txtTenKhach.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenKhach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenKhach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKhach.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKhach.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenKhach.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKhach.ForeColor = System.Drawing.Color.Black;
            this.txtTenKhach.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenKhach.Location = new System.Drawing.Point(237, 58);
            this.txtTenKhach.Name = "txtTenKhach";
            this.txtTenKhach.PasswordChar = '\0';
            this.txtTenKhach.PlaceholderText = "";
            this.txtTenKhach.ReadOnly = true;
            this.txtTenKhach.SelectedText = "";
            this.txtTenKhach.Size = new System.Drawing.Size(209, 26);
            this.txtTenKhach.TabIndex = 9;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(237, 43);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(53, 15);
            this.guna2HtmlLabel3.TabIndex = 8;
            this.guna2HtmlLabel3.Text = "Tên Khách";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiaChi.DefaultText = "";
            this.txtDiaChi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiaChi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiaChi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiaChi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiaChi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.ForeColor = System.Drawing.Color.Black;
            this.txtDiaChi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiaChi.Location = new System.Drawing.Point(10, 111);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.PasswordChar = '\0';
            this.txtDiaChi.PlaceholderText = "";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.SelectedText = "";
            this.txtDiaChi.Size = new System.Drawing.Size(209, 26);
            this.txtDiaChi.TabIndex = 9;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(10, 90);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(35, 15);
            this.guna2HtmlLabel2.TabIndex = 8;
            this.guna2HtmlLabel2.Text = "Địa chỉ";
            // 
            // txtMaKhach
            // 
            this.txtMaKhach.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaKhach.DefaultText = "";
            this.txtMaKhach.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaKhach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaKhach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKhach.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKhach.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaKhach.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKhach.ForeColor = System.Drawing.Color.Black;
            this.txtMaKhach.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaKhach.Location = new System.Drawing.Point(10, 58);
            this.txtMaKhach.Name = "txtMaKhach";
            this.txtMaKhach.PasswordChar = '\0';
            this.txtMaKhach.PlaceholderText = "";
            this.txtMaKhach.ReadOnly = true;
            this.txtMaKhach.SelectedText = "";
            this.txtMaKhach.Size = new System.Drawing.Size(209, 26);
            this.txtMaKhach.TabIndex = 9;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(10, 43);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(51, 15);
            this.guna2HtmlLabel1.TabIndex = 8;
            this.guna2HtmlLabel1.Text = "Mã Khách";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(410, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(38, 40);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 7;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 0;
            this.guna2Elipse1.TargetControl = this;
            // 
            // KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KhachHang";
            this.Size = new System.Drawing.Size(824, 748);
            this.Load += new System.EventHandler(this.KhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewKhachhang)).EndInit();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.grThongtinKhachHang.ResumeLayout(false);
            this.grThongtinKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2PictureBox ptLoad;
        private System.Windows.Forms.DataGridView viewKhachhang;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Button btThemKhachHang;
        private Guna.UI2.WinForms.Guna2TextBox txtSsearch;
        private Guna.UI2.WinForms.Guna2Button btTimKiem;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GroupBox grThongtinKhachHang;
        private Guna.UI2.WinForms.Guna2TextBox txtDienThoai;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2TextBox txtTenKhach;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2TextBox txtDiaChi;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox txtMaKhach;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.DataGridViewButtonColumn Sua;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbLoad;
    }
}
