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

namespace PhanMemQuanLyCuaHangPet
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        BUS_NhanVien bus_nhanvien = new BUS_NhanVien();

        private void ResetForm()
        {
            txbMaNV.Text = "";
            txbTenNV.Text = "";
            cmbChucVuNV.SelectedIndex = 0;
            txbDiaChiNV.Text = "";
            txbSoDienThoai.Text = "";


        }

        void Reset()
        {
            txbMaNV.Clear();
            txbTenNV.Clear();
            cmbChucVuNV.SelectedIndex=0; 
            txbDiaChiNV.Clear();
            txbSoDienThoai.Clear();

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = bus_nhanvien.GetNhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int MaNV = int.Parse(txbMaNV.Text.Trim());
                string TenKH = txbTenNV.Text.Trim();
                string ChucVu = cmbChucVuNV.Text.Trim();
                string DiaChi = txbDiaChiNV.Text.Trim();
                string SoDienThoai = txbSoDienThoai.Text.Trim();
                NhanVien nv = new NhanVien(MaNV, TenKH, ChucVu, DiaChi, SoDienThoai);
                bus_nhanvien.AddNhanVien(nv);
                MessageBox.Show("Thêm thông tin nhan vien thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmNhanVien_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int MaNV = int.Parse(txbMaNV.Text.Trim());
                string TenKH = txbTenNV.Text.Trim();
                string ChucVu = cmbChucVuNV.Text.Trim();
                string DiaChi = txbDiaChiNV.Text.Trim();
                string SoDienThoai = txbSoDienThoai.Text.Trim();
                NhanVien nv = new NhanVien(MaNV, TenKH, ChucVu, DiaChi, SoDienThoai);
                bus_nhanvien.EditNhanVien(nv);
                MessageBox.Show("Thêm thông tin nhan vien thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmNhanVien_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int MaNV = int.Parse(txbMaNV.Text);
                bus_nhanvien.DeleteNhanVien(MaNV);
                frmNhanVien_Load(sender, e);
                Reset();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void txbTimNV_TextChanged(object sender, EventArgs e)
        {
            string keyWord = txbTimNV.Text;
            dgvNhanVien.DataSource = bus_nhanvien.SearchNhanVien(keyWord);
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaNV.Text = dgvNhanVien[0, dgvNhanVien.CurrentCell.RowIndex].Value.ToString();
            txbTenNV.Text = dgvNhanVien[1, dgvNhanVien.CurrentCell.RowIndex].Value.ToString();
            cmbChucVuNV.Text = dgvNhanVien[2, dgvNhanVien.CurrentCell.RowIndex].Value.ToString();
            txbDiaChiNV.Text = dgvNhanVien[3, dgvNhanVien.CurrentCell.RowIndex].Value.ToString();
            txbSoDienThoai.Text = dgvNhanVien[4, dgvNhanVien.CurrentCell.RowIndex].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin Khách Hàng";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bus_nhanvien.KetXuatWord(saveFileDialog.FileName);
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
            saveFileDialog.Title = "Lưu thông tin phòng trọ";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bus_nhanvien.XuatExcel(saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }

    }
}
