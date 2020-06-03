﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;

namespace QuanLyNhaHang.Views
{
    public partial class FrmSearchNhanVien : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FrmSearchNhanVien()
        {
            InitializeComponent();
        }
        void loadcontrol()
        {
            cmbFind.Items.Clear();
            cmbFind.Items.Add("Id Nhân Viên");
            cmbFind.Items.Add("Tên Nhân Viên");
        }
        private void FrmSearchNhanVien_Load(object sender, EventArgs e)
        {
            cmbFind.Text = "Id Nhân Viên";
            loadcontrol();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFind.Text == "")
                MessageBox.Show("Hãy nhập vào ô tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                if (cmbFind.Text == "Id Nhân Viên")
                {
                    string _idNhanVien = txtFind.Text.ToString();
                    DataTable dt = new DataTable();
                    dt = Controllers.NhanVienCtrl.FillDataSet_getSearchNVbyId(_idNhanVien).Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        dgvDanhSachNV.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Id " + txtFind.Text + " Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    string _tenFind = txtFind.Text.ToString();
                    DataTable dt = new DataTable();
                    dt = Controllers.NhanVienCtrl.FillDataSet_FindNVByTen(_tenFind).Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        dgvDanhSachNV.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Tên " + txtFind.Text + " Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            if (cmbFind.Text == "Id Nhân Viên")
            {
                string _idNhanVien = txtFind.Text.ToString();
                DataTable dt = new DataTable();
                dt = Controllers.NhanVienCtrl.FillDataSet_getSearchNVbyId(_idNhanVien).Tables[0];
                dgvDanhSachNV.DataSource = dt;
            }
            else
            {
                string _tenFind = txtFind.Text.ToString();
                DataTable dt = new DataTable();
                dt = Controllers.NhanVienCtrl.FillDataSet_FindNVByTen(_tenFind).Tables[0];
                dgvDanhSachNV.DataSource = dt;
            }
        }

    }
}