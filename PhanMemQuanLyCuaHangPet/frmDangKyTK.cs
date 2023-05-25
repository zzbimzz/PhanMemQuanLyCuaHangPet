 using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using OfficeOpenXml;

namespace PhanMemQuanLyCuaHangPet
{
    public partial class frmDangKyTK : Form
    {
        public frmDangKyTK()
        {
            InitializeComponent();
        }

        BUS_TaiKhoan bus_taikhoan = new BUS_TaiKhoan();

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int MaTK = int.Parse(txbMaTK.Text.Trim());
                string TenTK = txbTenTK.Text.Trim();
                string MatKhau = txbMatKhau.Text.Trim();
                int MaNV = int.Parse(cmbMaNV.SelectedValue.ToString());

                TaiKhoan tk = new TaiKhoan(MaTK,TenTK,MatKhau,MaNV);
                bus_taikhoan.AddTaiKhoan(tk);
                MessageBox.Show("Thêm thông tin tài khoản thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmDangKyTK_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int MaTK = int.Parse(txbMaTK.Text.Trim());
                string TenTK = txbTenTK.Text.Trim();
                string MatKhau = txbMatKhau.Text.Trim();
                int MaNV = int.Parse(cmbMaNV.SelectedValue.ToString());

                TaiKhoan tk = new TaiKhoan(MaTK, TenTK, MatKhau, MaNV);
                bus_taikhoan.UpdateTaiKhoan(tk);
                MessageBox.Show("Sửa thông tin tài khoản thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmDangKyTK_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int MaNV = int.Parse(txbMaTK.Text);
                bus_taikhoan.DeleteTaiKhoan(MaNV);
                frmDangKyTK_Load(sender, e);
                Reset();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin tài khoản";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bus_taikhoan.KetXuatWord(saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Lưu thông tin tài khoản";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bus_taikhoan.XuatExcel(saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }

        private void txbTimTK_TextChanged(object sender, EventArgs e)
        {
            string keyWord = txbTimTK.Text;
            dgvTaiKhoan.DataSource = bus_taikhoan.SearchTaiKhoan(keyWord);
        }

        private void frmDangKyTK_Load(object sender, EventArgs e)
        {
            BUS_NhanVien bUS_NhanVien = new BUS_NhanVien();
            dgvTaiKhoan.DataSource = bus_taikhoan.GetTaiKhoan();
            cmbMaNV.DataSource = bUS_NhanVien.GetNhanVien();
            cmbMaNV.ValueMember = "MaNV";
            cmbMaNV.DisplayMember = "TenNV";
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaTK.Text = dgvTaiKhoan[0, dgvTaiKhoan.CurrentCell.RowIndex].Value.ToString();
            txbTenTK.Text = dgvTaiKhoan[1, dgvTaiKhoan.CurrentCell.RowIndex].Value.ToString();
            txbMatKhau.Text = dgvTaiKhoan[2, dgvTaiKhoan.CurrentCell.RowIndex].Value.ToString();
            cmbMaNV.Text = dgvTaiKhoan[3, dgvTaiKhoan.CurrentCell.RowIndex].Value.ToString();
        }

        private void ResetForm()
        {
            txbMaTK.Text = "";
            txbTenTK.Text = "";
            txbMatKhau.Text = "";
            cmbMaNV.SelectedIndex = 0;
        }
        void Reset()
        {
            txbMaTK.Clear();
            txbTenTK.Clear();
            txbMatKhau.Clear();
            cmbMaNV.SelectedIndex = 0;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
