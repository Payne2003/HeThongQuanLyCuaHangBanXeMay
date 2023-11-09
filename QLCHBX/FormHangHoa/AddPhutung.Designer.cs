namespace QLCHBX.FormHangHoa
{
    partial class AddPhutung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPhutung));
            this.txtten = new Guna.UI2.WinForms.Guna2TextBox();
            this.btThem = new Guna.UI2.WinForms.Guna2Button();
            this.bthuy = new Guna.UI2.WinForms.Guna2Button();
            this.lb1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // txtten
            // 
            this.txtten.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtten.DefaultText = "";
            this.txtten.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtten.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtten.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtten.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtten.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtten.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtten.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtten.Location = new System.Drawing.Point(294, 161);
            this.txtten.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtten.Name = "txtten";
            this.txtten.PasswordChar = '\0';
            this.txtten.PlaceholderText = "";
            this.txtten.SelectedText = "";
            this.txtten.Size = new System.Drawing.Size(368, 78);
            this.txtten.TabIndex = 0;
            // 
            // btThem
            // 
            this.btThem.BorderRadius = 10;
            this.btThem.BorderThickness = 1;
            this.btThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btThem.ForeColor = System.Drawing.Color.White;
            this.btThem.Image = ((System.Drawing.Image)(resources.GetObject("btThem.Image")));
            this.btThem.Location = new System.Drawing.Point(465, 332);
            this.btThem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(153, 52);
            this.btThem.TabIndex = 54;
            this.btThem.Text = "Thêm";
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // bthuy
            // 
            this.bthuy.BorderRadius = 10;
            this.bthuy.BorderThickness = 1;
            this.bthuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bthuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bthuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bthuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bthuy.FillColor = System.Drawing.Color.Red;
            this.bthuy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bthuy.ForeColor = System.Drawing.Color.White;
            this.bthuy.Image = ((System.Drawing.Image)(resources.GetObject("bthuy.Image")));
            this.bthuy.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bthuy.Location = new System.Drawing.Point(226, 332);
            this.bthuy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bthuy.Name = "bthuy";
            this.bthuy.Size = new System.Drawing.Size(153, 52);
            this.bthuy.TabIndex = 55;
            this.bthuy.Text = "Hủy";
            this.bthuy.Click += new System.EventHandler(this.bthuy_Click);
            // 
            // lb1
            // 
            this.lb1.AutoSize = false;
            this.lb1.BackColor = System.Drawing.Color.Transparent;
            this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.Location = new System.Drawing.Point(172, 180);
            this.lb1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(81, 36);
            this.lb1.TabIndex = 56;
            this.lb1.Text = "Tên : ";
            // 
            // AddPhutung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.bthuy);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.txtten);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AddPhutung";
            this.Text = "AddPhutung";
            this.Load += new System.EventHandler(this.AddPhutung_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtten;
        private Guna.UI2.WinForms.Guna2Button btThem;
        private Guna.UI2.WinForms.Guna2Button bthuy;
        private Guna.UI2.WinForms.Guna2HtmlLabel lb1;
    }
}