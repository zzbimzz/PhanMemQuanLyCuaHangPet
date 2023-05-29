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
    public partial class frmThongKe : Form
    {
        BUS_KhachHang bus_khachhang = new BUS_KhachHang();
        BUS_SanPham bus_sanpham = new BUS_SanPham();
        BUS_HoaDon_CTietHoaDon bus_hd_cthd = new BUS_HoaDon_CTietHoaDon();
        BUS_NhanVien bus_nhanvien = new BUS_NhanVien();
        BUS_ThongKe bus_thongke = new BUS_ThongKe();
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void dtpThongKe_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayChon = dtpThongKe.Value;
            float tongTien = bus_thongke.LayTongTienSanPhamDaBan(ngayChon);

            // Hiển thị tổng tiền lên TextBox
            txbTongTien.Text = tongTien.ToString();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            dgvBanHang.DataSource = bus_hd_cthd.GetHoaDon();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime thangChon = dtpThongKeThang.Value;
            float tongTien = bus_thongke.LayTongTienSanPhamDaBanTheoThang(thangChon);

            // Hiển thị tổng tiền lên TextBox
            txbThongKeThang.Text = tongTien.ToString();
        }

        private void dtpThongKeNam_ValueChanged(object sender, EventArgs e)
        {
            DateTime namchon = dtpThongKeNam.Value;
            float tongTien = bus_thongke.LayTongTienSanPhamDaBanTheoNam(namchon);

            // Hiển thị tổng tiền lên TextBox
            txbThongKeNam.Text = tongTien.ToString();
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
                    bus_thongke.KetXuatWord(saveFileDialog.FileName, new List<int>()
                    {
                        txbTongTien.Text.Trim() == "" ? 0 : int.Parse(txbTongTien.Text.Trim()),
                        txbThongKeThang.Text.Trim() == ""    ? 0 : int.Parse(txbThongKeThang.Text.Trim()),
                        txbThongKeNam.Text.Trim() == ""    ? 0 : int.Parse(txbThongKeNam.Text.Trim()),
                    }) ; 
                try
                {
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
            saveFileDialog.Title = "Lưu thông tin khách hàng";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bus_thongke.XuatExcel(saveFileDialog.FileName);
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
