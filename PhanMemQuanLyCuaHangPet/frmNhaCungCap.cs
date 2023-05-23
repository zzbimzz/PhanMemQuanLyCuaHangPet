using BUS;
using DTO;
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
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        BUS_NhaCungCap bus_nhacungcap = new BUS_NhaCungCap();

        private void txbTimNCC_TextChanged(object sender, EventArgs e)
        {
            string keyWord = txbTimNCC.Text;
            dgvNhaCungCap.DataSource = bus_nhacungcap.SearchNhaCungCap(keyWord);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int MaNCC = int.Parse(txbMaNCC.Text.Trim());
                string TenNCC = txbTenNCC.Text.Trim();
                string DiaChi = txbDiaChi.Text.Trim();
                string SoDienThoai = txbSDT.Text.Trim();
                NhaCungCap ncc = new NhaCungCap(MaNCC, TenNCC, DiaChi, SoDienThoai);
                bus_nhacungcap.AddNhaCungCap(ncc);
                MessageBox.Show("Thêm thông tin sản phẩm thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmNhaCungCap_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int MaNCC = int.Parse(txbMaNCC.Text.Trim());
                string TenNCC = txbTenNCC.Text.Trim();
                string DiaChi = txbDiaChi.Text.Trim();
                string SoDienThoai = txbSDT.Text.Trim();
                NhaCungCap ncc = new NhaCungCap(MaNCC, TenNCC, DiaChi, SoDienThoai);
                bus_nhacungcap.EditNhaCungCap(ncc);
                MessageBox.Show("Sửa thông tin sản phẩm thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmNhaCungCap_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int MaNCC = int.Parse(txbMaNCC.Text);
                bus_nhacungcap.DeleteNhaCungCap(MaNCC);
                frmNhaCungCap_Load(sender, e);
                Reset();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            dgvNhaCungCap.DataSource = bus_nhacungcap.GetNhaCungCap();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaNCC.Text = dgvNhaCungCap[0, dgvNhaCungCap.CurrentCell.RowIndex].Value.ToString();
            txbTenNCC.Text = dgvNhaCungCap[1, dgvNhaCungCap.CurrentCell.RowIndex].Value.ToString();
            txbDiaChi.Text = dgvNhaCungCap[2, dgvNhaCungCap.CurrentCell.RowIndex].Value.ToString();
            txbSDT.Text = dgvNhaCungCap[3, dgvNhaCungCap.CurrentCell.RowIndex].Value.ToString();
        }

        private void ResetForm()
        {
            txbMaNCC.Text = "";
            txbTenNCC.Text = "";
            txbDiaChi.Text = "";
            txbSDT.Text = "";


        }

        void Reset()
        {
            txbMaNCC.Clear();
            txbTenNCC.Clear();
            txbDiaChi.Clear();
            txbSDT.Clear();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin nhà cung cấp";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bus_nhacungcap.KetXuatWord(saveFileDialog.FileName);
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
            saveFileDialog.Title = "Lưu thông tin nhà cung cấp";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bus_nhacungcap.XuatExcel(saveFileDialog.FileName);
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
