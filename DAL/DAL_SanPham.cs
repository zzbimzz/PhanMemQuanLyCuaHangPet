using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_SanPham
    {
        public DataTable GetSanPham()
        {
            string query = "SP_hienthi_SanPham";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public void AddSanPham(SanPham sanpham)
        {
            string query = $"SP_Add_SanPham @MaSP , @TenSP , @GiaTien , @SoLuong  ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    sanpham.MaSP,
                    sanpham.TenSP,
                    sanpham.GiaTien,
                    sanpham.SoLuong,

                });
        }

        public void UpdateSanPham(SanPham sanpham)
        {
            string query = $"SP_Update_SanPham @MaSP , @TenSP , @GiaTien , @SoLuong ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    sanpham.MaSP,
                    sanpham.TenSP,
                    sanpham.GiaTien,
                    sanpham.SoLuong,
                });
        }

        public void DeleteSanPham(int MaSP)
        {
            string query = $"SP_Delete_SanPham @MaSP ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { MaSP });
        }

        public DataTable SearchSanPham(string keyword)
        {
            string query = "SP_Search_SanPham @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
