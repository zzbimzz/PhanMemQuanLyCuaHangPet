using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public class HoaDon
    {
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public float TongTien { get; set; }
        public int MaKH { get; set; }
        public int MaNV { get; set; }


        public HoaDon() { }

        public HoaDon(int maHD, DateTime ngayLap, float tongTien, int maKH, int maNV)
        {
            MaHD = maHD;
            NgayLap = ngayLap;
            TongTien = tongTien;
            MaKH = maKH;
            MaNV = maNV;
        }
        
    }

    public class CtietHoaDon
    {
        public int MaHD { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }


        public CtietHoaDon() { }

        public CtietHoaDon(int maHD, int maSP, int soLuong, float donGia)
        {
            MaHD = maHD;
            MaSP = maSP;
            SoLuong = soLuong;
            DonGia = donGia;
        }
    }
}
