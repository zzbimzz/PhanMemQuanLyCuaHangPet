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
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }


        BUS_SanPham bus_sanpham = new BUS_SanPham();

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource= bus_sanpham.GetSanPham();
        }

        private void ResetForm()
        {
            txbMaSP.Text = "";
            txbTenSP.Text = "";
            txbGiaSP.Text = "";
            txbSoLuongSP.Text = "";


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int MaSP = int.Parse(txbMaSP.Text.Trim());
                string TenSP = txbTenSP.Text.Trim();
                float GiaTien = int.Parse(txbGiaSP.Text.Trim());
                int SoLuong = int.Parse(txbSoLuongSP.Text.Trim());
                SanPham sp = new SanPham(MaSP, TenSP, GiaTien,SoLuong);
                bus_sanpham.AddSanPham(sp);
                MessageBox.Show("Thêm thông tin khách hàng thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmSanPham_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int MaSP = int.Parse(txbMaSP.Text.Trim());
                string TenSP = txbTenSP.Text.Trim();
                float GiaTien = int.Parse(txbGiaSP.Text.Trim());
                int SoLuong = int.Parse(txbSoLuongSP.Text.Trim());
                SanPham sp = new SanPham(MaSP, TenSP, GiaTien, SoLuong);
                bus_sanpham.UpdateSanPham(sp);
                MessageBox.Show("Sửa thông tin khách hàng thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmSanPham_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int MaSP = int.Parse(txbMaSP.Text);
                bus_sanpham.DeleteSanPham(MaSP);
                frmSanPham_Load(sender, e);
                Reset();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }


        void Reset()
        {
            txbMaSP.Clear();
            txbTenSP.Clear();
            txbGiaSP.Clear();
            txbSoLuongSP.Clear();

        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaSP.Text = dgvSanPham[0, dgvSanPham.CurrentCell.RowIndex].Value.ToString();
            txbTenSP.Text = dgvSanPham[1, dgvSanPham.CurrentCell.RowIndex].Value.ToString();
            txbGiaSP.Text = dgvSanPham[2, dgvSanPham.CurrentCell.RowIndex].Value.ToString();
            txbSoLuongSP.Text = dgvSanPham[3, dgvSanPham.CurrentCell.RowIndex].Value.ToString();
        }

        private void txbTimSanPham_TextChanged(object sender, EventArgs e)
        {
            string keyWord = txbTimSanPham.Text;
            dgvSanPham.DataSource = bus_sanpham.SearchSanPham(keyWord);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin Sản Phẩm";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                    bus_sanpham.KetXuatWord(saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                try
                {
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
                    bus_sanpham.XuatExcel(saveFileDialog.FileName);
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
