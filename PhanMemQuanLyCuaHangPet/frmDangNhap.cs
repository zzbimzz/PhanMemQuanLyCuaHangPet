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

namespace PhanMemQuanLyCuaHangPet
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        BUS_TaiKhoan bus_taikhoan = new BUS_TaiKhoan();
        public static string tenTaiKhoan;
        public static string matKhau;


        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            tenTaiKhoan = txbTaikhoan.Text;
            matKhau = txbMatKhau.Text;

            if (tenTaiKhoan != "" || matKhau != "")
            {

                if (bus_taikhoan.kiemTraTK(tenTaiKhoan, matKhau))
                {
                    frmMain frmMain = new frmMain();
                    frmMain.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Tài khoản mật khẩu không chính xác. Yêu cầu nhập lại!");
                }

            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!");
            }
        }


    }
}
