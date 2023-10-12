namespace QLCHBX.ALLControl
{
    partial class GiaoDichCT
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnMoving = new Guna.UI2.WinForms.Guna2Panel();
            this.btGDSp = new Guna.UI2.WinForms.Guna2Button();
            this.btGDgj = new Guna.UI2.WinForms.Guna2Button();
            this.btGDch = new Guna.UI2.WinForms.Guna2Button();
            this.btHoadon = new Guna.UI2.WinForms.Guna2Button();
            this.pnControl = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.hoaDon1 = new QLCHBX.GDControl.HoaDon();
            this.goJek1 = new QLCHBX.GDControl.GoJek();
            this.gdCuahang1 = new QLCHBX.GDControl.GDCuahang();
            this.shopee1 = new QLCHBX.GDControl.Shopee();
            this.guna2Panel1.SuspendLayout();
            this.pnControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel1.Controls.Add(this.pnMoving);
            this.guna2Panel1.Controls.Add(this.btGDSp);
            this.guna2Panel1.Controls.Add(this.btGDgj);
            this.guna2Panel1.Controls.Add(this.btGDch);
            this.guna2Panel1.Controls.Add(this.btHoadon);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1386, 125);
            this.guna2Panel1.TabIndex = 0;
            // 
            // pnMoving
            // 
            this.pnMoving.BackColor = System.Drawing.Color.White;
            this.pnMoving.BorderRadius = 10;
            this.pnMoving.Location = new System.Drawing.Point(67, 114);
            this.pnMoving.Name = "pnMoving";
            this.pnMoving.Size = new System.Drawing.Size(180, 2);
            this.pnMoving.TabIndex = 4;
            // 
            // btGDSp
            // 
            this.btGDSp.BackColor = System.Drawing.Color.Transparent;
            this.btGDSp.BorderRadius = 10;
            this.btGDSp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btGDSp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btGDSp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btGDSp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btGDSp.FillColor = System.Drawing.Color.OrangeRed;
            this.btGDSp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btGDSp.ForeColor = System.Drawing.Color.White;
            this.btGDSp.Location = new System.Drawing.Point(871, 23);
            this.btGDSp.Name = "btGDSp";
            this.btGDSp.ShadowDecoration.BorderRadius = 10;
            this.btGDSp.ShadowDecoration.Enabled = true;
            this.btGDSp.Size = new System.Drawing.Size(180, 84);
            this.btGDSp.TabIndex = 3;
            this.btGDSp.Text = "GD - Shopee";
            this.btGDSp.Click += new System.EventHandler(this.btGDSp_Click);
            // 
            // btGDgj
            // 
            this.btGDgj.BackColor = System.Drawing.Color.Transparent;
            this.btGDgj.BorderRadius = 10;
            this.btGDgj.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btGDgj.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btGDgj.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btGDgj.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btGDgj.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btGDgj.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btGDgj.ForeColor = System.Drawing.Color.White;
            this.btGDgj.Location = new System.Drawing.Point(603, 23);
            this.btGDgj.Name = "btGDgj";
            this.btGDgj.ShadowDecoration.BorderRadius = 10;
            this.btGDgj.ShadowDecoration.Enabled = true;
            this.btGDgj.Size = new System.Drawing.Size(180, 84);
            this.btGDgj.TabIndex = 2;
            this.btGDgj.Text = "GD - Gojek";
            this.btGDgj.Click += new System.EventHandler(this.btGDgj_Click);
            // 
            // btGDch
            // 
            this.btGDch.BackColor = System.Drawing.Color.Transparent;
            this.btGDch.BorderRadius = 10;
            this.btGDch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btGDch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btGDch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btGDch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btGDch.FillColor = System.Drawing.Color.White;
            this.btGDch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btGDch.ForeColor = System.Drawing.Color.Black;
            this.btGDch.Location = new System.Drawing.Point(335, 23);
            this.btGDch.Name = "btGDch";
            this.btGDch.ShadowDecoration.BorderRadius = 10;
            this.btGDch.ShadowDecoration.Enabled = true;
            this.btGDch.Size = new System.Drawing.Size(180, 84);
            this.btGDch.TabIndex = 1;
            this.btGDch.Text = "GD - Cửa Hàng";
            this.btGDch.Click += new System.EventHandler(this.btGDch_Click);
            // 
            // btHoadon
            // 
            this.btHoadon.BackColor = System.Drawing.Color.Transparent;
            this.btHoadon.BorderRadius = 10;
            this.btHoadon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btHoadon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btHoadon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btHoadon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btHoadon.FillColor = System.Drawing.Color.White;
            this.btHoadon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btHoadon.ForeColor = System.Drawing.Color.Black;
            this.btHoadon.Location = new System.Drawing.Point(67, 23);
            this.btHoadon.Name = "btHoadon";
            this.btHoadon.ShadowDecoration.BorderRadius = 10;
            this.btHoadon.ShadowDecoration.Enabled = true;
            this.btHoadon.Size = new System.Drawing.Size(180, 84);
            this.btHoadon.TabIndex = 0;
            this.btHoadon.Text = "Hóa đơn";
            this.btHoadon.Click += new System.EventHandler(this.btHoadon_Click);
            // 
            // pnControl
            // 
            this.pnControl.Controls.Add(this.hoaDon1);
            this.pnControl.Controls.Add(this.goJek1);
            this.pnControl.Controls.Add(this.gdCuahang1);
            this.pnControl.Controls.Add(this.shopee1);
            this.pnControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnControl.Location = new System.Drawing.Point(0, 125);
            this.pnControl.Name = "pnControl";
            this.pnControl.Size = new System.Drawing.Size(1386, 600);
            this.pnControl.TabIndex = 1;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // hoaDon1
            // 
            this.hoaDon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hoaDon1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.hoaDon1.Location = new System.Drawing.Point(0, 0);
            this.hoaDon1.Margin = new System.Windows.Forms.Padding(4);
            this.hoaDon1.Name = "hoaDon1";
            this.hoaDon1.Size = new System.Drawing.Size(1386, 600);
            this.hoaDon1.TabIndex = 3;
            // 
            // goJek1
            // 
            this.goJek1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.goJek1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goJek1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.goJek1.Location = new System.Drawing.Point(0, 0);
            this.goJek1.Margin = new System.Windows.Forms.Padding(4);
            this.goJek1.Name = "goJek1";
            this.goJek1.Size = new System.Drawing.Size(1386, 600);
            this.goJek1.TabIndex = 2;
            // 
            // gdCuahang1
            // 
            this.gdCuahang1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gdCuahang1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdCuahang1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdCuahang1.Location = new System.Drawing.Point(0, 0);
            this.gdCuahang1.Margin = new System.Windows.Forms.Padding(4);
            this.gdCuahang1.Name = "gdCuahang1";
            this.gdCuahang1.Size = new System.Drawing.Size(1386, 600);
            this.gdCuahang1.TabIndex = 1;
            // 
            // shopee1
            // 
            this.shopee1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.shopee1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shopee1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.shopee1.Location = new System.Drawing.Point(0, 0);
            this.shopee1.Margin = new System.Windows.Forms.Padding(4);
            this.shopee1.Name = "shopee1";
            this.shopee1.Size = new System.Drawing.Size(1386, 600);
            this.shopee1.TabIndex = 0;
            // 
            // GiaoDichCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnControl);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "GiaoDichCT";
            this.Size = new System.Drawing.Size(1386, 725);
            this.guna2Panel1.ResumeLayout(false);
            this.pnControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btHoadon;
        private Guna.UI2.WinForms.Guna2Panel pnControl;
        private Guna.UI2.WinForms.Guna2Button btGDSp;
        private Guna.UI2.WinForms.Guna2Button btGDgj;
        private Guna.UI2.WinForms.Guna2Button btGDch;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private GDControl.GoJek goJek1;
        private GDControl.GDCuahang gdCuahang1;
        private GDControl.Shopee shopee1;
        private GDControl.HoaDon hoaDon1;
        private Guna.UI2.WinForms.Guna2Panel pnMoving;
    }
}
