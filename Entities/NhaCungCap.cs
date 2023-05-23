using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCap
    {
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }




        public NhaCungCap()
        {
        }


        public NhaCungCap(int MaNCC, string TenNCC, string DiaChi, string SoDienThoai)
        {
            this.MaNCC = MaNCC;
            this.TenNCC = TenNCC;
            this.DiaChi = DiaChi;
            this.SoDienThoai = SoDienThoai;

        }
    }
}
