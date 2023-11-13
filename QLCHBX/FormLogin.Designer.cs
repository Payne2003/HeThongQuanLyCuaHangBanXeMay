namespace QLCHBX
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnmoving = new System.Windows.Forms.Panel();
            this.ctminimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.ctThoat = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnControl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.linkLogin = new System.Windows.Forms.LinkLabel();
            this.linkquenmk = new System.Windows.Forms.LinkLabel();
            this.linkDangky = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.login1 = new QLCHBX.ALLControl.Login();
            this.signup1 = new QLCHBX.ALLControl.Signup();
            this.forgotPassword1 = new QLCHBX.ALLControl.ForgotPassword();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.pnmoving.SuspendLayout();
            this.pnControl.SuspendLayout();
            this.panel3.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.guna2PictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 360);
            this.panel1.TabIndex = 0;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(400, 360);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // pnmoving
            // 
            this.pnmoving.BackColor = System.Drawing.Color.MintCream;
            this.pnmoving.Controls.Add(this.ctminimize);
            this.pnmoving.Controls.Add(this.ctThoat);
            this.pnmoving.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnmoving.Location = new System.Drawing.Point(0, 0);
            this.pnmoving.Name = "pnmoving";
            this.pnmoving.Size = new System.Drawing.Size(800, 40);
            this.pnmoving.TabIndex = 1;
            // 
            // ctminimize
            // 
            this.ctminimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.ctminimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctminimize.FillColor = System.Drawing.Color.Transparent;
            this.ctminimize.HoverState.FillColor = System.Drawing.Color.White;
            this.ctminimize.HoverState.IconColor = System.Drawing.Color.Blue;
            this.ctminimize.IconColor = System.Drawing.Color.Black;
            this.ctminimize.Location = new System.Drawing.Point(720, 0);
            this.ctminimize.Name = "ctminimize";
            this.ctminimize.Size = new System.Drawing.Size(40, 40);
            this.ctminimize.TabIndex = 2;
            this.ctminimize.Click += new System.EventHandler(this.ctminimize_Click);
            // 
            // ctThoat
            // 
            this.ctThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctThoat.FillColor = System.Drawing.Color.Transparent;
            this.ctThoat.HoverState.FillColor = System.Drawing.Color.Red;
            this.ctThoat.HoverState.IconColor = System.Drawing.Color.Blue;
            this.ctThoat.IconColor = System.Drawing.Color.Black;
            this.ctThoat.Location = new System.Drawing.Point(760, 0);
            this.ctThoat.Name = "ctThoat";
            this.ctThoat.Size = new System.Drawing.Size(40, 40);
            this.ctThoat.TabIndex = 0;
            this.ctThoat.Click += new System.EventHandler(this.ctThoat_Click);
            // 
            // pnControl
            // 
            this.pnControl.Controls.Add(this.label1);
            this.pnControl.Controls.Add(this.linkLabel3);
            this.pnControl.Controls.Add(this.linkLabel2);
            this.pnControl.Controls.Add(this.label2);
            this.pnControl.Controls.Add(this.linkLabel1);
            this.pnControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnControl.Location = new System.Drawing.Point(400, 350);
            this.pnControl.Name = "pnControl";
            this.pnControl.Size = new System.Drawing.Size(400, 50);
            this.pnControl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "/";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(345, 19);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(41, 13);
            this.linkLabel3.TabIndex = 56;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "English";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(268, 19);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(54, 13);
            this.linkLabel2.TabIndex = 55;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Tiếng việt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Phần mềm được tạo bởi nhóm 14 - 2023";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(14, 19);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(27, 13);
            this.linkLabel1.TabIndex = 53;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "help";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 5;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.DimGray;
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // linkLogin
            // 
            this.linkLogin.AutoSize = true;
            this.linkLogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.linkLogin.Location = new System.Drawing.Point(0, 16);
            this.linkLogin.Name = "linkLogin";
            this.linkLogin.Size = new System.Drawing.Size(89, 13);
            this.linkLogin.TabIndex = 1;
            this.linkLogin.TabStop = true;
            this.linkLogin.Text = "Đã có tài khoản?";
            this.linkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogin_LinkClicked);
            // 
            // linkquenmk
            // 
            this.linkquenmk.AutoSize = true;
            this.linkquenmk.Dock = System.Windows.Forms.DockStyle.Right;
            this.linkquenmk.Location = new System.Drawing.Point(227, 13);
            this.linkquenmk.Name = "linkquenmk";
            this.linkquenmk.Size = new System.Drawing.Size(80, 13);
            this.linkquenmk.TabIndex = 2;
            this.linkquenmk.TabStop = true;
            this.linkquenmk.Text = "Quên mật khẩu";
            this.linkquenmk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkquenmk_LinkClicked);
            // 
            // linkDangky
            // 
            this.linkDangky.AutoSize = true;
            this.linkDangky.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkDangky.Location = new System.Drawing.Point(0, 0);
            this.linkDangky.Name = "linkDangky";
            this.linkDangky.Size = new System.Drawing.Size(92, 13);
            this.linkDangky.TabIndex = 3;
            this.linkDangky.TabStop = true;
            this.linkDangky.Text = "Tạo tài khoản mới";
            this.linkDangky.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDangky_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.guna2Panel4);
            this.panel3.Controls.Add(this.guna2Panel3);
            this.panel3.Controls.Add(this.guna2Panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(400, 321);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 29);
            this.panel3.TabIndex = 0;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Controls.Add(this.linkquenmk);
            this.guna2Panel4.Controls.Add(this.linkLogin);
            this.guna2Panel4.Controls.Add(this.linkDangky);
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel4.Location = new System.Drawing.Point(41, 0);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(307, 29);
            this.guna2Panel4.TabIndex = 6;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel3.Location = new System.Drawing.Point(348, 0);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(52, 29);
            this.guna2Panel3.TabIndex = 5;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(41, 29);
            this.guna2Panel2.TabIndex = 4;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.login1);
            this.guna2Panel1.Controls.Add(this.signup1);
            this.guna2Panel1.Controls.Add(this.forgotPassword1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(400, 40);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(400, 281);
            this.guna2Panel1.TabIndex = 3;
            // 
            // login1
            // 
            this.login1.BackColor = System.Drawing.Color.White;
            this.login1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login1.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login1.Location = new System.Drawing.Point(0, 0);
            this.login1.manhanvien = null;
            this.login1.Margin = new System.Windows.Forms.Padding(4);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(400, 281);
            this.login1.TabIndex = 0;
            // 
            // signup1
            // 
            this.signup1.BackColor = System.Drawing.Color.White;
            this.signup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signup1.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup1.ForeColor = System.Drawing.Color.Black;
            this.signup1.Location = new System.Drawing.Point(0, 0);
            this.signup1.Margin = new System.Windows.Forms.Padding(4);
            this.signup1.Name = "signup1";
            this.signup1.Size = new System.Drawing.Size(400, 281);
            this.signup1.TabIndex = 2;
            // 
            // forgotPassword1
            // 
            this.forgotPassword1.BackColor = System.Drawing.Color.White;
            this.forgotPassword1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forgotPassword1.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotPassword1.Location = new System.Drawing.Point(0, 0);
            this.forgotPassword1.Margin = new System.Windows.Forms.Padding(4);
            this.forgotPassword1.Name = "forgotPassword1";
            this.forgotPassword1.Size = new System.Drawing.Size(400, 281);
            this.forgotPassword1.TabIndex = 1;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.pnmoving;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnmoving);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.pnmoving.ResumeLayout(false);
            this.pnControl.ResumeLayout(false);
            this.pnControl.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Panel pnmoving;
        private System.Windows.Forms.Panel pnControl;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2ControlBox ctminimize;
        private Guna.UI2.WinForms.Guna2ControlBox ctThoat;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel linkDangky;
        private System.Windows.Forms.LinkLabel linkquenmk;
        private System.Windows.Forms.LinkLabel linkLogin;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private ALLControl.Login login1;
        private ALLControl.Signup signup1;
        private ALLControl.ForgotPassword forgotPassword1;
    }
}