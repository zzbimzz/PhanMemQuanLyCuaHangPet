using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO

{
    public class TaiKhoan
    {
        public int MaTK { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public int MaNV { get; set; }




        public TaiKhoan()
        {
        }



        public TaiKhoan(int MaTK, string TenTaiKhoan, string MatKhau, int MaNV)
        {
            this.MaTK = MaTK;
            this.TenTaiKhoan = TenTaiKhoan;
            this.MatKhau = MatKhau;
            this.MaNV = MaNV;
        }



    }

}
