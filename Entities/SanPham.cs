using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public float GiaTien { get; set; }
        public int SoLuong { get; set; }




        public SanPham()
        {
        }


        public SanPham(int MaSP, string TenSP, float GiaTien, int SoLuong)
        {
            this.MaSP = MaSP;
            this.TenSP = TenSP;
            this.GiaTien = GiaTien;
            this.SoLuong = SoLuong;

        }
    }
}
