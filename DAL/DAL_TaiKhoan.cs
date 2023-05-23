using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_TaiKhoan
    {

        public DataTable GetTaiKhoan(string tenTaiKhoan, string matKhau)
        {
            string query = $"select * from TaiKhoan where TenTaiKhoan = '{tenTaiKhoan}' and MatKhau = '{matKhau}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }


        public DataTable GetTaiKhoanNhanVien (string tentaikhoan, string matkhau)
        {
            string query = $"select T.TenTaiKhoan, N.ChucVu from TaiKhoan T inner join NhanVien N on T.MaNV = N.MaNV Where TenTaiKhoan = '{tentaikhoan}' and MatKhau = '{matkhau}'  ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }



        public DataTable GetTaiKhoan()
        {
            string query = "SP_hienthi_TaiKhoan";
            return DataProvider.Instance.ExecuteQuery(query);
        }


        public void AddTaiKhoan(TaiKhoan tk)
        {
            string query = $"SP_Add_TaiKhoan @MaTK , @TenTaiKhoan , @MatKhau , @MaNV  ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    tk.MaTK,
                    tk.TenTaiKhoan,
                    tk.MatKhau,
                    tk.MaNV,

                });
        }

        public void UpdateTaiKhoan(TaiKhoan tk)
        {
            string query = $"SP_Update_TaiKhoan @MaTK , @TenTaiKhoan , @MatKhau , @MaNV ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    tk.MaTK,
                    tk.TenTaiKhoan,
                    tk.MatKhau,
                    tk.MaNV,
                });
        }

        public void DeleteTaiKhoan(int MaTK)
        {
            string query = $"SP_Delete_TaiKhoan @MaTK ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { MaTK });
        }

        public DataTable SearchTaiKhoan(string keyword)
        {
            string query = "SP_Search_TaiKhoan @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }



    }
}
