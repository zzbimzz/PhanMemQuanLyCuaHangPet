using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string ChucVu { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }



        public NhanVien()
        {

        }


        public NhanVien(int MaNV, string TenNV, string ChucVu, string DiaChi, string SoDienThoai)
        {
            this.MaNV = MaNV;
            this.TenNV = TenNV;
            this.ChucVu = ChucVu;
            this.DiaChi = DiaChi;
            this.SoDienThoai = SoDienThoai;

        }
    }


}
