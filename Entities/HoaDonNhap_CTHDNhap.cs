using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonNhap
    {
        public int MaHDN { get; set; }
        public DateTime NgayNhap { get; set; }
        public float TongTien { get; set; }
        public int MaNCC { get; set; }
        public int MaNV { get; set; }


        public HoaDonNhap() { }

        public HoaDonNhap(int maHDN, DateTime ngayNhap, float tongTien, int maNCC, int maNV)
        {
            MaHDN = maHDN;
            NgayNhap = ngayNhap;
            TongTien = tongTien;
            MaNCC = maNCC;
            MaNV = maNV;
        }
    }

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
