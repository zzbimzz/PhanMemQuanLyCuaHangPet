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
using BUS;

namespace PhanMemQuanLyCuaHangPet
{
    public partial class frmBanHang : Form
    {

        BUS_KhachHang bus_khachhang = new BUS_KhachHang();
        BUS_SanPham bus_sanpham = new BUS_SanPham();
        BUS_HoaDon_CTietHoaDon bus_hd_cthd = new BUS_HoaDon_CTietHoaDon();
        BUS_NhanVien bus_nhanvien = new BUS_NhanVien();
        
        public frmBanHang()
        {
            InitializeComponent();
            txbNgayLap.Text=DateTime.Now.ToShortDateString();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            dgvBanHang.DataSource = bus_hd_cthd.GetHoaDon();

            cmbTenKH.DataSource = bus_khachhang.GetKhachHang();
            cmbTenKH.ValueMember = "MaKH";
            cmbTenKH.DisplayMember = "TenKH";

            cmbTenSP.DataSource = bus_sanpham.GetSanPham();
            cmbTenSP.ValueMember = "MaSP";
            cmbTenSP.DisplayMember = "TenSP";

            cmbTenNV.DataSource = bus_nhanvien.GetNhanVien();
            cmbTenNV.ValueMember = "MaNV";
            cmbTenNV.DisplayMember = "TenNV";
        }


        DataTable data = new DataTable();
        private void dgvBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaHD.Text = dgvBanHang[0, dgvBanHang.CurrentCell.RowIndex].Value.ToString();
            cmbTenKH.Text = dgvBanHang[1, dgvBanHang.CurrentCell.RowIndex].Value.ToString();
            cmbTenSP.Text = dgvBanHang[2, dgvBanHang.CurrentCell.RowIndex].Value.ToString();
            cmbTenNV.Text = dgvBanHang[3, dgvBanHang.CurrentCell.RowIndex].Value.ToString();
            txbNgayLap.Text = dgvBanHang[4, dgvBanHang.CurrentCell.RowIndex].Value.ToString();
            txbSoLuong.Text = dgvBanHang[5, dgvBanHang.CurrentCell.RowIndex].Value.ToString();
            txbDonGia.Text = dgvBanHang[6, dgvBanHang.CurrentCell.RowIndex].Value.ToString();
            txbTongTien.Text = dgvBanHang[7, dgvBanHang.CurrentCell.RowIndex].Value.ToString();

/*            for(int i = 0; i < dgvBanHang.CurrentRow.Cells.Count; i++)
            {
                data.Columns.Add(dgvBanHang[i, dgvBanHang.CurrentCell.RowIndex].Value.ToString());

            }*/

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        void Reset()
        {

            txbMaHD.Clear();
            cmbTenKH.SelectedIndex=0;
            cmbTenSP.SelectedIndex = 0;
            cmbTenNV.SelectedIndex = 0;
            txbNgayLap.Clear();
            txbSoLuong.Clear();
            txbDonGia.Clear();
            txbTongTien.Clear();
        }
        private void ResetForm()
        {
            txbMaHD.Text="";
            cmbTenKH.SelectedIndex = 0;
            cmbTenSP.SelectedIndex = 0;
            cmbTenNV.SelectedIndex = 0;
            txbNgayLap.Text="";
            txbSoLuong.Text = "";
            txbDonGia.Text = "";
            txbTongTien.Text = "";

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int MaHD = int.Parse(txbMaHD.Text.Trim());
                int TenKH = int.Parse(cmbTenKH.SelectedValue.ToString());
                int TenSP = int.Parse(cmbTenSP.SelectedValue.ToString());
                int TenNV = int.Parse(cmbTenKH.SelectedValue.ToString());
                DateTime NgayLap = DateTime.Parse(txbNgayLap.Text.Trim());
                int SoLuong = int.Parse(txbSoLuong.Text.Trim());
                float DonGia = float.Parse(txbDonGia.Text.Trim());
                int TongTien = int.Parse(txbTongTien.Text.Trim());
                HoaDon hoaDon = new HoaDon(MaHD,NgayLap,TongTien,TenKH,TenNV);
                CtietHoaDon cthd = new CtietHoaDon(MaHD, TenSP, SoLuong, DonGia);
                bus_hd_cthd.AddHoaDon(hoaDon, cthd);
                MessageBox.Show("Thêm thông tin hóa đơn thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmBanHang_Load(sender, e);
            }
        }

        private void txbTongTien_Enter(object sender, EventArgs e)
        {
            string dongia = txbDonGia.Text;
            string soluong = txbSoLuong.Text;
            int dongia1 = int.Parse(txbDonGia.Text.Trim());
            int soluong1 = int.Parse(txbSoLuong.Text.Trim());
            int tong;
            if (dongia1 > 0 && soluong1 > 0)
            {
                tong = dongia1 * soluong1;
                txbTongTien.Text = tong.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int MaHD = int.Parse(txbMaHD.Text.Trim());
                int TenKH = int.Parse(cmbTenKH.SelectedValue.ToString());
                int TenSP = int.Parse(cmbTenSP.SelectedValue.ToString());
                int TenNV = int.Parse(cmbTenKH.SelectedValue.ToString());
                DateTime NgayLap = DateTime.Parse(txbNgayLap.Text.Trim());
                int SoLuong = int.Parse(txbSoLuong.Text.Trim());
                float DonGia = float.Parse(txbDonGia.Text.Trim());
                int TongTien = int.Parse(txbTongTien.Text.Trim());
                HoaDon hoaDon = new HoaDon(MaHD, NgayLap, TongTien, TenKH, TenNV);
                CtietHoaDon cthd = new CtietHoaDon(MaHD, TenSP, SoLuong, DonGia);
                bus_hd_cthd.UpdateHoaDon(hoaDon, cthd);
                MessageBox.Show("Sửa thông tin hóa đơn thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmBanHang_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int MaKH = int.Parse(txbMaHD.Text);
                bus_hd_cthd.DeleteHoaDon(MaKH);
                frmBanHang_Load(sender, e);
                Reset();
            }
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin Hóa Đơn";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bus_hd_cthd.KetXuatWord(saveFileDialog.FileName,int.Parse(txbMaHD.Text));
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Lưu thông tin hóa đơn";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bus_hd_cthd.XuatExcel(saveFileDialog.FileName,int.Parse(txbMaHD.Text));
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
