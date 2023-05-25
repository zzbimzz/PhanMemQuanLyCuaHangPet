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

        public bool AddKhachHang(KhachHang khachHang)
        {
            string query = $"SP_Add_Khachhang @MaKH , @TenKH , @DiaChi , @SoDienThoai  ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { khachHang.MaKH, khachHang.TenKH, khachHang.DiaChi, khachHang.SoDienThoai }) > 0;
        }

        public bool SP_Update_Khachhang(KhachHang khachHang)
        {
            string query = $"SP_Update_Khachhang @MaKH , @TenKH , @DiaChi , @SoDienThoai ";
            return    DataProvider.Instance.
                ExecuteNonQuery(query, new object[]
                {
                    khachHang.MaKH,
                    khachHang.TenKH,
                    khachHang.DiaChi,
                    khachHang.SoDienThoai,
                }) > 0;
            
        }

        public bool SP_Delete_Khachhang(int MaKH)
        {
            string query = $"SP_Delete_Khachhang @MaKH ";
            return  DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaKH }) >0 ;
        }

        public DataTable SP_Search_KhachHang(string keyword)
        {
            string query = "SP_Search_KhachHang @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
