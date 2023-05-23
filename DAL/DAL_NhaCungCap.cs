using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_NhaCungCap
    {
        public DataTable GetNhaCungCap()
        {
            string query = "SP_hienthi_NhaCungCap";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void AddNhaCungCap(NhaCungCap ncc)
        {
            string query = $"SP_Add_NhaCungCap @MaNCC , @TenNCC , @DiaChi , @SoDienThoai  ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    ncc.MaNCC,
                    ncc.TenNCC,
                    ncc.DiaChi,
                    ncc.SoDienThoai,

                });
        }

        public void UpdateNhaCungCap(NhaCungCap ncc)
        {
            string query = $"SP_Update_NhaCungCap @MaNCC , @TenNCC , @DiaChi , @SoDienThoai ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    ncc.MaNCC,
                    ncc.TenNCC,
                    ncc.DiaChi,
                    ncc.SoDienThoai,
                });
        }

        public void DeleteNhaCungCap(int MaNCC)
        {
            string query = $"SP_Delete_NhaCungCap @MaNCC ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { MaNCC });
        }

        public DataTable SearchNhaCungCap(string keyword)
        {
            string query = "SP_Search_NhaCungCap @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
