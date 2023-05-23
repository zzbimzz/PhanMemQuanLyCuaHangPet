using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDonNhap
    {
        public int MaHDN { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }



        public ChiTietHoaDonNhap() { }



        public ChiTietHoaDonNhap(int maHDN, int maSP, int soLuong, float donGia)
        {
            MaHDN = maHDN;
            MaSP = maSP;
            SoLuong = soLuong;
            DonGia = donGia;
        }
   
    }



    
}
