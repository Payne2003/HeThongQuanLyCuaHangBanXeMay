namespace QLCHBX.ALLControl
{
    partial class HangHoa
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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.conToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phutungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dongcoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.phanhToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mausacToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theloaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tinhtrangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hsxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nsxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dongco1 = new QLCHBX.HanghoaControl.Dongco();
            this.xeso1 = new QLCHBX.HanghoaControl.Xeso();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xeToolStripMenuItem,
            this.phutungToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 8, 0, 8);
            this.menuStrip1.Size = new System.Drawing.Size(824, 41);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // xeToolStripMenuItem
            // 
            this.xeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soToolStripMenuItem,
            this.gaToolStripMenuItem1,
            this.conToolStripMenuItem});
            this.xeToolStripMenuItem.Name = "xeToolStripMenuItem";
            this.xeToolStripMenuItem.Size = new System.Drawing.Size(89, 25);
            this.xeToolStripMenuItem.Text = "Hàng hóa";
            this.xeToolStripMenuItem.Click += new System.EventHandler(this.xeToolStripMenuItem_Click);
            // 
            // soToolStripMenuItem
            // 
            this.soToolStripMenuItem.Name = "soToolStripMenuItem";
            this.soToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.soToolStripMenuItem.Text = "Số";
            this.soToolStripMenuItem.Click += new System.EventHandler(this.soToolStripMenuItem_Click);
            // 
            // gaToolStripMenuItem1
            // 
            this.gaToolStripMenuItem1.Name = "gaToolStripMenuItem1";
            this.gaToolStripMenuItem1.Size = new System.Drawing.Size(108, 26);
            this.gaToolStripMenuItem1.Text = "Ga";
            this.gaToolStripMenuItem1.Click += new System.EventHandler(this.gaToolStripMenuItem1_Click);
            // 
            // conToolStripMenuItem
            // 
            this.conToolStripMenuItem.Name = "conToolStripMenuItem";
            this.conToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.conToolStripMenuItem.Text = "Côn";
            this.conToolStripMenuItem.Click += new System.EventHandler(this.conToolStripMenuItem_Click);
            // 
            // phutungToolStripMenuItem
            // 
            this.phutungToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dongcoToolStripMenuItem2,
            this.phanhToolStripMenuItem1,
            this.mausacToolStripMenuItem,
            this.theloaiToolStripMenuItem,
            this.tinhtrangToolStripMenuItem,
            this.hsxToolStripMenuItem,
            this.nsxToolStripMenuItem});
            this.phutungToolStripMenuItem.Name = "phutungToolStripMenuItem";
            this.phutungToolStripMenuItem.Size = new System.Drawing.Size(85, 25);
            this.phutungToolStripMenuItem.Text = "Phụ tùng";
            this.phutungToolStripMenuItem.Click += new System.EventHandler(this.phutungToolStripMenuItem_Click);
            // 
            // dongcoToolStripMenuItem2
            // 
            this.dongcoToolStripMenuItem2.Name = "dongcoToolStripMenuItem2";
            this.dongcoToolStripMenuItem2.Size = new System.Drawing.Size(179, 26);
            this.dongcoToolStripMenuItem2.Text = "Động cơ";
            this.dongcoToolStripMenuItem2.Click += new System.EventHandler(this.dongcoToolStripMenuItem2_Click);
            // 
            // phanhToolStripMenuItem1
            // 
            this.phanhToolStripMenuItem1.Name = "phanhToolStripMenuItem1";
            this.phanhToolStripMenuItem1.Size = new System.Drawing.Size(179, 26);
            this.phanhToolStripMenuItem1.Text = "Phanh";
            this.phanhToolStripMenuItem1.Click += new System.EventHandler(this.phanhToolStripMenuItem1_Click);
            // 
            // mausacToolStripMenuItem
            // 
            this.mausacToolStripMenuItem.Name = "mausacToolStripMenuItem";
            this.mausacToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.mausacToolStripMenuItem.Text = "Màu sắc";
            this.mausacToolStripMenuItem.Click += new System.EventHandler(this.mausacToolStripMenuItem_Click);
            // 
            // theloaiToolStripMenuItem
            // 
            this.theloaiToolStripMenuItem.Name = "theloaiToolStripMenuItem";
            this.theloaiToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.theloaiToolStripMenuItem.Text = "thể loại";
            this.theloaiToolStripMenuItem.Click += new System.EventHandler(this.theloaiToolStripMenuItem_Click);
            // 
            // tinhtrangToolStripMenuItem
            // 
            this.tinhtrangToolStripMenuItem.Name = "tinhtrangToolStripMenuItem";
            this.tinhtrangToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.tinhtrangToolStripMenuItem.Text = "Tình trạng";
            this.tinhtrangToolStripMenuItem.Click += new System.EventHandler(this.tinhtrangToolStripMenuItem_Click);
            // 
            // hsxToolStripMenuItem
            // 
            this.hsxToolStripMenuItem.Name = "hsxToolStripMenuItem";
            this.hsxToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.hsxToolStripMenuItem.Text = "Hăng sản xuất";
            this.hsxToolStripMenuItem.Click += new System.EventHandler(this.hsxToolStripMenuItem_Click);
            // 
            // nsxToolStripMenuItem
            // 
            this.nsxToolStripMenuItem.Name = "nsxToolStripMenuItem";
            this.nsxToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.nsxToolStripMenuItem.Text = "Nước sản xuất";
            this.nsxToolStripMenuItem.Click += new System.EventHandler(this.nsxToolStripMenuItem_Click);
            // 
            // dongco1
            // 
            this.dongco1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dongco1.Font = new System.Drawing.Font("Segoe UI Semilight", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongco1.HangHoaForm = null;
            this.dongco1.Location = new System.Drawing.Point(0, 41);
            this.dongco1.Name = "dongco1";
            this.dongco1.Size = new System.Drawing.Size(824, 707);
            this.dongco1.TabIndex = 16;
            // 
            // xeso1
            // 
            this.xeso1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xeso1.Font = new System.Drawing.Font("Segoe UI Semilight", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xeso1.Location = new System.Drawing.Point(0, 41);
            this.xeso1.Name = "xeso1";
            this.xeso1.Size = new System.Drawing.Size(824, 707);
            this.xeso1.TabIndex = 15;
            // 
            // HangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dongco1);
            this.Controls.Add(this.xeso1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "HangHoa";
            this.Size = new System.Drawing.Size(824, 748);
            this.Load += new System.EventHandler(this.HangHoa_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem soToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phutungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phanhToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dongcoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mausacToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theloaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tinhtrangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hsxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nsxToolStripMenuItem;
        
        private System.Windows.Forms.ToolStripMenuItem conToolStripMenuItem;
		private HanghoaControl.Dongco dongco1;
		private HanghoaControl.Xeso xeso1;
    }
}
