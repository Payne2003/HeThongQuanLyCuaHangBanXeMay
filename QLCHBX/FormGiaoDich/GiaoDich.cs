﻿using QLCHBX.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX.FormGiaoDich
{
    public partial class GiaoDich : Form
    {
        public GiaoDich()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);

        }
        public GiaoDich(int SoDDH)
        {
            InitializeComponent();
            this.txtSoDDH.Text = SoDDH.ToString();
            guna2ShadowForm1.SetShadowForm(this);

        }
        public bool KiemTraTextsRong(params string[] texts)
        {
            return texts.Any(string.IsNullOrWhiteSpace);
        }

        private void GiaoDich_Load(object sender, EventArgs e)
        {
            time_1.Text = DateTime.Now.ToString("HH:mm");
            if (!KiemTraTextsRong(txtSoDDH.Text,txtMaNV.Text))
            {
                return;
            }
            else
            {
                DonDatHangModel donDatHang_new = new DonDatHangModel();
                DateTime NgayMua = DateTime.Now;
                int SoDDH = donDatHang_new.ThemDonDatHang(int.Parse(txtMaNV.Text),NgayMua);
                txtSoDDH.Text = SoDDH.ToString();
                xe1.txtSoDDH.Text = SoDDH.ToString();

            }
        }

        private void btchietkhau_Click(object sender, EventArgs e)
        {

        }

        private void btthemdondathang_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}