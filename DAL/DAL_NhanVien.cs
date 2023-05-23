using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_NhanVien
    {

        public DataTable GetNhanVien()
        {
            string query = "SP_hienthi_NhanVien";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void AddNhanVien(NhanVien nhanvien)
        {
            string query = $"SP_Add_NhanVien @MaNV , @TenNV , @ChucVu , @DiaChi , @SoDienThoai  ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    nhanvien.MaNV,
                    nhanvien.TenNV,
                    nhanvien.ChucVu,
                    nhanvien.DiaChi,
                    nhanvien.SoDienThoai,

                });
        }

        public void UpdateNhanVien(NhanVien nhanvien)
        {
            string query = $"SP_Update_NhanVien @MaNV , @TenNV , @ChucVu , @DiaChi , @SoDienThoai  ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    nhanvien.MaNV,
                    nhanvien.TenNV,
                    nhanvien.ChucVu,
                    nhanvien.DiaChi,
                    nhanvien.SoDienThoai,
                });
        }

        public void DeleteNhanVien(int MaNV)
        {
            string query = $"SP_Delete_NhanVien @MaNV ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { MaNV });
        }

        public DataTable SearchNhanVien(string keyword)
        {
            string query = "SP_Search_NhanVien @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
