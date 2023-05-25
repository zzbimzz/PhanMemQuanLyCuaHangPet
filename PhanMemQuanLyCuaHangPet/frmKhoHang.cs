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
    public partial class frmKhoHang : Form
    {
        public frmKhoHang()
        {
            InitializeComponent();
        }

        BUS_KhoHang bus_khohang = new BUS_KhoHang();

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int MaKho = int.Parse(txbMaKho.Text.Trim());

                int MaSP = int.Parse(cmbMaSP.SelectedValue.ToString());
                int SoLuongTon = int.Parse(txbSoLuongTon.Text.Trim());
                KhoHang kh = new KhoHang(MaKho, MaSP, SoLuongTon);
                bus_khohang.AddKhoHang(kh);
                MessageBox.Show("Thêm thông tin kho hàng thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmKhoHang_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int MaKho = int.Parse(txbMaKho.Text.Trim());

                int MaSP = int.Parse(cmbMaSP.SelectedValue.ToString());
                int SoLuongTon = int.Parse(txbSoLuongTon.Text.Trim());
                KhoHang kh = new KhoHang(MaKho, MaSP, SoLuongTon);
                bus_khohang.UpdateKhoHang(kh);
                MessageBox.Show("Sửa thông tin kho hàng thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmKhoHang_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int MaNV = int.Parse(txbMaKho.Text);
                bus_khohang.DeleteKhoHang(MaNV);
                frmKhoHang_Load(sender, e);
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
            saveFileDialog.Title = "Lưu thông tin Kho Hàng";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                bus_khohang.KetXuatWord(saveFileDialog.FileName);
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
            saveFileDialog.Title = "Lưu thông tin khách hàng";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bus_khohang.XuatExcel(saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }

        private void txbTimKhachHang_TextChanged(object sender, EventArgs e)
        {
            string keyWord = txbTimhang.Text;
            dgvKhoHang.DataSource = bus_khohang.SearchKhoHang(keyWord);
        }

        private void dgvKhoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaKho.Text = dgvKhoHang[0, dgvKhoHang.CurrentCell.RowIndex].Value.ToString();
            cmbMaSP.Text = dgvKhoHang[1, dgvKhoHang.CurrentCell.RowIndex].Value.ToString();
            txbSoLuongTon.Text = dgvKhoHang[2, dgvKhoHang.CurrentCell.RowIndex].Value.ToString();

        }

        private void frmKhoHang_Load(object sender, EventArgs e)
        {
            BUS_SanPham bus_sanpham = new BUS_SanPham();
            dgvKhoHang.DataSource = bus_khohang.GetKhoHang();
            cmbMaSP.DataSource = bus_sanpham.GetSanPham();
            cmbMaSP.ValueMember = "MaSP";
            cmbMaSP.DisplayMember = "TenSP";
        }

        private void ResetForm()
        {
            txbMaKho.Text = "";
            cmbMaSP.SelectedIndex = 0;
            txbSoLuongTon.Text = "";
        }

        void Reset()
        {
            txbMaKho.Clear();
            cmbMaSP.SelectedIndex = 0;
            txbSoLuongTon.Clear();


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
