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
    public partial class frmKhachHang : Form
    {

        public frmKhachHang()
        {
            InitializeComponent();

        }

        BUS_KhachHang bus_khachhang = new BUS_KhachHang();




        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = bus_khachhang.GetKhachHang();
        }

        private void ResetForm()
        {
            txbMaKhachHang.Text = "";
            txbTenKhachHang.Text = "";
            txbDiaChi.Text = "";
            txbSDT.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int MaKh = int.Parse(txbMaKhachHang.Text.Trim());
                string TenKH = txbTenKhachHang.Text.Trim();
                string DiaChi = txbDiaChi.Text.Trim();
                string SoDienThoai = txbSDT.Text.Trim();
                KhachHang kh = new KhachHang(MaKh, TenKH, DiaChi, SoDienThoai);
                bus_khachhang.AddKhachHang(kh);
                MessageBox.Show("Thêm thông tin khách hàng thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmKhachHang_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {


            try
            {
                int MaKh = int.Parse(txbMaKhachHang.Text.Trim());
                string TenKH = txbTenKhachHang.Text.Trim();
                string DiaChi = txbDiaChi.Text.Trim();
                string SoDienThoai = txbSDT.Text.Trim();
                KhachHang kh = new KhachHang(MaKh, TenKH, DiaChi, SoDienThoai);
                bus_khachhang.EditKhachHang(kh);
                MessageBox.Show("Sửa thông tin khách hàng thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmKhachHang_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int MaKH = int.Parse(txbMaKhachHang.Text);
                bus_khachhang.DeleteKhachHang(MaKH);
                frmKhachHang_Load(sender, e);
                Reset();
            }

        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaKhachHang.Text = dgvKhachHang[0, dgvKhachHang.CurrentCell.RowIndex].Value.ToString();
            txbTenKhachHang.Text = dgvKhachHang[1, dgvKhachHang.CurrentCell.RowIndex].Value.ToString();
            txbDiaChi.Text = dgvKhachHang[2, dgvKhachHang.CurrentCell.RowIndex].Value.ToString();
            txbSDT.Text = dgvKhachHang[3, dgvKhachHang.CurrentCell.RowIndex].Value.ToString();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        void Reset()
        {
            txbMaKhachHang.Clear();
            txbTenKhachHang.Clear();
            txbDiaChi.Clear();
            txbSDT.Clear();

        }

        private void txbTimKhachHang_TextChanged(object sender, EventArgs e)
        {
            string keyWord = txbTimKhachHang.Text;
            dgvKhachHang.DataSource = bus_khachhang.SearchKhachHang(keyWord);
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
                    bus_khachhang.KetXuatWord(saveFileDialog.FileName);
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
                    bus_khachhang.XuatExcel(saveFileDialog.FileName);
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
