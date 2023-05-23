using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhoHang
    {
        public DataTable GetKhoHang()
        {
            string query = "SP_hienthi_KhoHang";
            return DataProvider.Instance.ExecuteQuery(query);
        }


        public void AddKhoHang(KhoHang kh)
        {
            string query = $"SP_Update_KhoHang @MaKho , @SP , @SoLuongTon ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    kh.MaKho,
                    kh.MaSP,
                    kh.SoLuongTon,

                });
        }

        public void UpdateKhoHang(KhoHang kh)
        {
/*            string query = $"SP_Update_KhoHang @MaKho , @SP , @SoLuongTon ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    kh.MaKho,
                    kh.MaSP,
                    kh.SoLuongTon,
                });*/
        }

        public void DeleteKhoHang(int MaKho)
        {
/*            string query = $"SP_Delete_KhoHang @MaKho ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { MaKho });*/
        }

        public DataTable SearchKhoHang(string keyword)
        {
            string query = "SP_Search_KhoHang @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
