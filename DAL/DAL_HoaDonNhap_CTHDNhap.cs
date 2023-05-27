using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_HoaDonNhap_CTHDNhap
    {


        public DataTable GetHoaDonNhap()
        {
            string query = "SP_hienthi_HoaDonNhap";
            return DataProvider.Instance.ExecuteQuery(query);
        }







        public DataTable LayHoaDonNhap(int MaHDN)
        {
            string query = "SP_lay_HoaDonNhap @MaHDN";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { MaHDN });

        }

        public void AddHoaDonNhap(HoaDonNhap hdn, ChiTietHoaDonNhap cthdn)
        {
            string query = $"SP_add_HoaDonNhap @MaHDN  ,  @NgayNhap , @TongTien ,  @MaNCC ,     @MaNV , @MaSP  , @SoLuong ,  @DonGia   ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    hdn.MaHDN,
                    hdn.NgayNhap,
                    hdn.TongTien,
                    hdn.MaNCC,
                    hdn.MaNV,
                    cthdn.MaSP,
                    cthdn.SoLuong,
                    cthdn.DonGia

                });
        }


        public void UpdateHoaDonNhap(HoaDonNhap hdn, ChiTietHoaDonNhap cthdn)
        {
            string query = $"SP_Update_HoaDonNhap @MaHDN  ,  @NgayNhap , @TongTien ,  @MaNCC ,     @MaNV , @MaSP  , @SoLuong ,  @DonGia ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    hdn.MaHDN,
                    hdn.NgayNhap,
                    hdn.TongTien,
                    hdn.MaNCC,
                    hdn.MaNV,
                    cthdn.MaSP,
                    cthdn.SoLuong,
                    cthdn.DonGia
                });
        }

        public void DeleteHoaDonNhap(int MaHDN)
        {
            string query = $"SP_Delete_HoaDonNhap @MaHDN ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { MaHDN });
        }

        public DataTable SP_Search_HoaDonNhap(string keyword)
        {
            string query = "SP_Search_HoaDonNhap @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }

    }
}
