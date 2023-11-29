using QLCHBX.ALLControl;

namespace QLCHBX.BaoCaoControl
{
	partial class BaoCao
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
			this.cbbHienThi = new Guna.UI2.WinForms.Guna2ComboBox();
			this.dgvBaoCao = new Guna.UI2.WinForms.Guna2DataGridView();
			this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
			this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// guna2Elipse1
			// 
			this.guna2Elipse1.BorderRadius = 0;
			this.guna2Elipse1.TargetControl = this;
			// 
			// cbbHienThi
			// 
			this.cbbHienThi.BackColor = System.Drawing.Color.White;
			this.cbbHienThi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbbHienThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbbHienThi.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cbbHienThi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cbbHienThi.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.cbbHienThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
			this.cbbHienThi.ItemHeight = 30;
			this.cbbHienThi.Items.AddRange(new object[] {
            "Theo Ngày",
            "Theo Tuần",
            "Theo Tháng",
            "Theo Năm"});
			this.cbbHienThi.Location = new System.Drawing.Point(218, 171);
			this.cbbHienThi.Name = "cbbHienThi";
			this.cbbHienThi.Size = new System.Drawing.Size(134, 36);
			this.cbbHienThi.TabIndex = 2;
			this.cbbHienThi.SelectedIndexChanged += new System.EventHandler(this.cbbHienThi_SelectedIndexChanged);
			// 
			// dgvBaoCao
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
			this.dgvBaoCao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvBaoCao.BackgroundColor = System.Drawing.Color.Gainsboro;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvBaoCao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvBaoCao.ColumnHeadersHeight = 4;
			this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvBaoCao.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvBaoCao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvBaoCao.Location = new System.Drawing.Point(0, 246);
			this.dgvBaoCao.Name = "dgvBaoCao";
			this.dgvBaoCao.RowHeadersVisible = false;
			this.dgvBaoCao.RowHeadersWidth = 51;
			this.dgvBaoCao.RowTemplate.Height = 24;
			this.dgvBaoCao.Size = new System.Drawing.Size(824, 499);
			this.dgvBaoCao.TabIndex = 3;
			this.dgvBaoCao.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
			this.dgvBaoCao.ThemeStyle.AlternatingRowsStyle.Font = null;
			this.dgvBaoCao.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
			this.dgvBaoCao.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
			this.dgvBaoCao.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
			this.dgvBaoCao.ThemeStyle.BackColor = System.Drawing.Color.Gainsboro;
			this.dgvBaoCao.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvBaoCao.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
			this.dgvBaoCao.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvBaoCao.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvBaoCao.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
			this.dgvBaoCao.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			this.dgvBaoCao.ThemeStyle.HeaderStyle.Height = 4;
			this.dgvBaoCao.ThemeStyle.ReadOnly = false;
			this.dgvBaoCao.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
			this.dgvBaoCao.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvBaoCao.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvBaoCao.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.dgvBaoCao.ThemeStyle.RowsStyle.Height = 24;
			this.dgvBaoCao.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvBaoCao.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			// 
			// guna2HtmlLabel1
			// 
			this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
			this.guna2HtmlLabel1.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.guna2HtmlLabel1.Location = new System.Drawing.Point(346, 32);
			this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
			this.guna2HtmlLabel1.Size = new System.Drawing.Size(138, 36);
			this.guna2HtmlLabel1.TabIndex = 4;
			this.guna2HtmlLabel1.Text = "BÁO CÁO";
			// 
			// guna2HtmlLabel2
			// 
			this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
			this.guna2HtmlLabel2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.guna2HtmlLabel2.Location = new System.Drawing.Point(94, 171);
			this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
			this.guna2HtmlLabel2.Size = new System.Drawing.Size(79, 28);
			this.guna2HtmlLabel2.TabIndex = 5;
			this.guna2HtmlLabel2.Text = "Hiển thị";
			// 
			// guna2PictureBox2
			// 
			this.guna2PictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
			this.guna2PictureBox2.FillColor = System.Drawing.Color.Transparent;
			this.guna2PictureBox2.Image = global::QLCHBX.Properties.Resources.icons8_bill_100;
			this.guna2PictureBox2.ImageRotate = 0F;
			this.guna2PictureBox2.Location = new System.Drawing.Point(663, 0);
			this.guna2PictureBox2.Name = "guna2PictureBox2";
			this.guna2PictureBox2.Size = new System.Drawing.Size(158, 145);
			this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.guna2PictureBox2.TabIndex = 9;
			this.guna2PictureBox2.TabStop = false;
			// 
			// BaoCao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.MintCream;
			this.Controls.Add(this.guna2PictureBox2);
			this.Controls.Add(this.guna2HtmlLabel2);
			this.Controls.Add(this.guna2HtmlLabel1);
			this.Controls.Add(this.dgvBaoCao);
			this.Controls.Add(this.cbbHienThi);
			this.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "BaoCao";
			this.Size = new System.Drawing.Size(824, 748);
			((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
		private Guna.UI2.WinForms.Guna2ComboBox cbbHienThi;
		private Guna.UI2.WinForms.Guna2DataGridView dgvBaoCao;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
		private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
		private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
	}
}