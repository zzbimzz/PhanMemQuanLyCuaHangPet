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
    public partial class frmNhapHang : Form
    {

        BUS_NhaCungCap bus_ncc = new BUS_NhaCungCap();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        BUS_SanPham bus_sp = new BUS_SanPham();
        BUS_HoaDonNhap_CTHDNhap bus_hdn_cthdn = new BUS_HoaDonNhap_CTHDNhap();
        BUS_KhoHang bus_khohang = new BUS_KhoHang();
        public frmNhapHang()
        {
            InitializeComponent();
            txbNgayNhap.Text = DateTime.Now.ToShortDateString();
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            dgvNhapHang.DataSource = bus_hdn_cthdn.GetHoaDonNhap();

            cmbTenNCC.DataSource = bus_ncc.GetNhaCungCap();
            cmbTenNCC.ValueMember = "MaNCC";
            cmbTenNCC.DisplayMember = "TenNCC";

            cmbTenSP.DataSource = bus_sp.GetSanPham();
            cmbTenSP.ValueMember = "MaSP";
            cmbTenSP.DisplayMember = "TenSP";

            cmbTenNV.DataSource = bus_nv.GetNhanVien();
            cmbTenNV.ValueMember = "MaNV";
            cmbTenNV.DisplayMember = "TenNV";
        }

        DataTable data = new DataTable();
        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaHDN.Text = dgvNhapHang[0, dgvNhapHang.CurrentCell.RowIndex].Value.ToString();
            cmbTenNCC.Text = dgvNhapHang[1, dgvNhapHang.CurrentCell.RowIndex].Value.ToString();
            cmbTenSP.Text = dgvNhapHang[2, dgvNhapHang.CurrentCell.RowIndex].Value.ToString();
            cmbTenNV.Text = dgvNhapHang[3, dgvNhapHang.CurrentCell.RowIndex].Value.ToString();
            txbNgayNhap.Text = dgvNhapHang[4, dgvNhapHang.CurrentCell.RowIndex].Value.ToString();
            txbSoLuong.Text = dgvNhapHang[5, dgvNhapHang.CurrentCell.RowIndex].Value.ToString();
            txbDonGia.Text = dgvNhapHang[6, dgvNhapHang.CurrentCell.RowIndex].Value.ToString();
            txbTongTien.Text = dgvNhapHang[7, dgvNhapHang.CurrentCell.RowIndex].Value.ToString();

/*            for (int i = 0; i < dgvNhapHang.CurrentRow.Cells.Count; i++)
            {
                data.Columns.Add(dgvNhapHang[i, dgvNhapHang.CurrentCell.RowIndex].Value.ToString());
            }*/
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void Reset()
        {

            txbMaHDN.Clear();
            cmbTenNCC.SelectedIndex = 0;
            cmbTenSP.SelectedIndex = 0;
            cmbTenNV.SelectedIndex = 0;
            txbNgayNhap.Clear();
            txbSoLuong.Clear();
            txbDonGia.Clear();
            txbTongTien.Clear();
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

        private void btnWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin Nhập hàng";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bus_hdn_cthdn.KetXuatWord(saveFileDialog.FileName, int.Parse(txbMaHDN.Text));
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }


        private void cmbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tensp = cmbTenSP.Text;
            float giaTien = bus_sp.GetTienSanPham(tensp);
            txbDonGia.Text = giaTien.ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Lưu thông tin Nhập Hàng";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bus_hdn_cthdn.XuatExcel(saveFileDialog.FileName, int.Parse(txbMaHDN.Text));
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int MaHDN = int.Parse(txbMaHDN.Text.Trim());
                int TenNCC = int.Parse(cmbTenNCC.SelectedValue.ToString());
                int TenSP = int.Parse(cmbTenSP.SelectedValue.ToString());
                int TenNV = int.Parse(cmbTenNV.SelectedValue.ToString());
                DateTime NgayNhap = DateTime.Parse(txbNgayNhap.Text.Trim());
                int SoLuong = int.Parse(txbSoLuong.Text.Trim());
                float DonGia = float.Parse(txbDonGia.Text.Trim());
                int TongTien = int.Parse(txbTongTien.Text.Trim());
                HoaDonNhap hdn = new HoaDonNhap(MaHDN, NgayNhap, TongTien, TenNCC, TenNV);
                ChiTietHoaDonNhap cthdn = new ChiTietHoaDonNhap(MaHDN, TenSP, SoLuong, DonGia);
                bus_hdn_cthdn.AddHoaDonNhap(hdn, cthdn);
                MessageBox.Show("Thêm thông tin hóa đơn nhập thành công!");
                Capnhatsoluongton();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmNhapHang_Load(sender, e);
            }
        }


        private void Capnhatsoluongton()
        {
            // Lấy thông tin sản phẩm và số lượng từ giao diện thanh toán

            int maSP = (int)cmbTenSP.SelectedValue;
            int soLuongNhap = int.Parse(txbSoLuong.Text);

            // Cập nhật số lượng tồn trong bảng KhoHang
            bus_khohang.CapNhatSoLuongTon(maSP, soLuongNhap);

            // Hiển thị thông báo thành công
            MessageBox.Show("Nhập hàng thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int MaHDN = int.Parse(txbMaHDN.Text.Trim());
                int TenNCC = int.Parse(cmbTenNCC.SelectedValue.ToString());
                int TenSP = int.Parse(cmbTenSP.SelectedValue.ToString());
                int TenNV = int.Parse(cmbTenNV.SelectedValue.ToString());
                DateTime NgayNhap = DateTime.Parse(txbNgayNhap.Text.Trim());
                int SoLuong = int.Parse(txbSoLuong.Text.Trim());
                float DonGia = float.Parse(txbDonGia.Text.Trim());
                int TongTien = int.Parse(txbTongTien.Text.Trim());
                HoaDonNhap hdn = new HoaDonNhap(MaHDN, NgayNhap, TongTien, TenNCC, TenNV);
                ChiTietHoaDonNhap cthdn = new ChiTietHoaDonNhap(MaHDN, TenSP, SoLuong, DonGia);
                bus_hdn_cthdn.UpdateHoaDonNhap(hdn, cthdn);
                MessageBox.Show("Sửa thông tin hóa đơn nhập thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmNhapHang_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int MaHDN = int.Parse(txbMaHDN.Text);
                bus_hdn_cthdn.DeleteHoaDonNhap(MaHDN);
                frmNhapHang_Load(sender, e);
                Reset();
            }
        }

        private void txbTimKhachHang_TextChanged(object sender, EventArgs e)
        {
            string keyWord = txbTimHDN.Text;
            dgvNhapHang.DataSource = bus_hdn_cthdn.SearchHoaDonNhap(keyWord);
        }

        private void txbSoLuong_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(txbSoLuong.Text, out int soLuong)) // chuyển đổi giá trị chuỗi thành giá trị số nguyên
            {
                MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập một số nguyên.");

            }

            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.");

            }
        }
    }
}
