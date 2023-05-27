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

        public int GetSoLuongSanPham(int maSP) // số lượng sản phẩm
        {
            string query = $"SELECT SoLuong FROM SanPham WHERE MaSP = {maSP}";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                int soLuong = Convert.ToInt32(data.Rows[0]["SoLuong"]);
                return soLuong;
            }

            return 0; // Hoặc giá trị mặc định nếu không tìm thấy sản phẩm có mã tương ứng
        }


        public void CapNhatSoLuongSanPham(int maSP, int soLuong) // cập nhật số lượng sau khi bán
        {
            if (soLuong >= 0)
            {
                string query = $"UPDATE SanPham SET SoLuong = SoLuong - {soLuong} WHERE MaSP = {maSP}";
                DataProvider.Instance.ExecuteNonQuery(query);
            }

        }

        public float GetTienSanPham(string tensp) // giá tiền sản phẩm
        {
            string query = $"SELECT GiaTien FROM SanPham WHERE TenSP = N'{tensp}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                float giaTien = Convert.ToSingle(data.Rows[0]["GiaTien"]);
                return giaTien;
            }

            return 0; // Hoặc giá trị mặc định nếu không tìm thấy sản phẩm có tên tương ứng
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
