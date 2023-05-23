using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhoHang
    {
        public int MaKho { get; set; }
        public int MaSP { get; set; }
        public int SoLuongTon { get; set; }


        public KhoHang()
        {

        }

        public KhoHang(int MaKho, int MaSP, int SoLuongTon)
        {
            this.MaKho = MaKho;
            this.MaSP = MaSP;
            this.SoLuongTon = SoLuongTon;
        }

    }


}
