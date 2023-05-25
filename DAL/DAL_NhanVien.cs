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

        public bool AddNhanVien(NhanVien nhanvien)
        {
            string query = $"SP_Add_NhanVien @MaNV , @TenNV , @ChucVu , @DiaChi , @SoDienThoai  ";
            return    DataProvider.Instance.
                ExecuteNonQuery(query, new object[]
                {
                    nhanvien.MaNV,
                    nhanvien.TenNV,
                    nhanvien.ChucVu,
                    nhanvien.DiaChi,
                    nhanvien.SoDienThoai,

                }) > 0;
        }

        public bool UpdateNhanVien(NhanVien nhanvien)
        {
            string query = $"SP_Update_NhanVien @MaNV , @TenNV , @ChucVu , @DiaChi , @SoDienThoai  ";
            return    DataProvider.Instance.
                ExecuteNonQuery(query, new object[]
                {
                    nhanvien.MaNV,
                    nhanvien.TenNV,
                    nhanvien.ChucVu,
                    nhanvien.DiaChi,
                    nhanvien.SoDienThoai,
                }) > 0;
        }

        public bool DeleteNhanVien(int MaNV)
        {
            string query = $"SP_Delete_NhanVien @MaNV ";
            return    DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaNV } ) >0;
        }

        public DataTable SearchNhanVien(string keyword)
        {
            string query = "SP_Search_NhanVien @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
