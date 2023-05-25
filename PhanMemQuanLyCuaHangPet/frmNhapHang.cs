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

            for (int i = 0; i < dgvNhapHang.CurrentRow.Cells.Count; i++)
            {
                data.Columns.Add(dgvNhapHang[i, dgvNhapHang.CurrentCell.RowIndex].Value.ToString());
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
