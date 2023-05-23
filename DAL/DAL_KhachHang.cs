using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_KhachHang
    {
        public DataTable GetKhachHang()
        {
            string query = "SP_hienthi_Khachang";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void AddKhachHang(KhachHang khachHang)
        {
            string query = $"SP_Add_Khachhang @MaKH , @TenKH , @DiaChi , @SoDienThoai  ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    khachHang.MaKH,
                    khachHang.TenKH,
                    khachHang.DiaChi,
                    khachHang.SoDienThoai,

                });
        }

        public void SP_Update_Khachhang(KhachHang khachHang)
        {
            string query = $"SP_Update_Khachhang @MaKH , @TenKH , @DiaChi , @SoDienThoai ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    khachHang.MaKH,
                    khachHang.TenKH,
                    khachHang.DiaChi,
                    khachHang.SoDienThoai,
                });
        }

        public void SP_Delete_Khachhang(int MaKH)
        {
            string query = $"SP_Delete_Khachhang @MaKH ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { MaKH });
        }

        public DataTable SP_Search_KhachHang(string keyword)
        {
            string query = "SP_Search_KhachHang @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
