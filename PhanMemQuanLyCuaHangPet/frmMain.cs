﻿using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyCuaHangPet
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        BUS_TaiKhoan bus_taikhoan = new BUS_TaiKhoan();



        private Form currentformchild;
        private void OpenchildForm(Form childForm)
        {
            if (currentformchild != null)
            {
                currentformchild.Close();
            }
            currentformchild = childForm;
            childForm.TopLevel = false;

            pnlChild.Controls.Add(childForm);
            pnlChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnCuahang_Click(object sender, EventArgs e)
        {
            pnlHienthi.Height = btnCuahang.Height;
            pnlHienthi.Top = btnCuahang.Top;
            OpenchildForm(new frmCuaHang());
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            pnlHienthi.Height = btnSanPham.Height;
            pnlHienthi.Top = btnSanPham.Top;
            OpenchildForm(new frmSanPham());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            pnlHienthi.Height = btnNhanVien.Height;
            pnlHienthi.Top = btnNhanVien.Top;
            OpenchildForm(new frmNhanVien());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            pnlHienthi.Height = btnKhachHang.Height;
            pnlHienthi.Top = btnKhachHang.Top;
            OpenchildForm(new frmKhachHang());
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            pnlHienthi.Height = btnNhapHang.Height;
            pnlHienthi.Top = btnNhapHang.Top;
            OpenchildForm(new frmNhapHang());
        }

        private void btnNhaCC_Click(object sender, EventArgs e)
        {
            pnlHienthi.Height = btnNhaCC.Height;
            pnlHienthi.Top = btnNhaCC.Top;
            OpenchildForm(new frmNhaCungCap ());
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            pnlHienthi.Height = btnBanHang.Height;
            pnlHienthi.Top = btnBanHang.Top;
            OpenchildForm(new frmBanHang());
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            pnlHienthi.Height = btnTaiKhoan.Height;
            pnlHienthi.Top = btnTaiKhoan.Top;
            OpenchildForm(new frmDangKyTK());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DataTable data = bus_taikhoan.GetTaiKhoanNhanVien(frmDangNhap.tenTaiKhoan, frmDangNhap.matKhau);
            foreach (DataRow row in data.Rows) 
            {
                lblTaiKhoan.Text = row[0].ToString();
                lblChucVu.Text = row[1].ToString();
            }
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            pnlHienthi.Height = btnKhoHang.Height;
            pnlHienthi.Top = btnKhoHang.Top;
            OpenchildForm(new frmKhoHang());
        }
    }
}