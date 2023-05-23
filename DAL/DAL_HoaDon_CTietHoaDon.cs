﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_HoaDon_CTietHoaDon
    {
        public DataTable GetHoaDon()
        {
            string query = "SP_hienthi_HoaDon";
            return DataProvider.Instance.ExecuteQuery(query);
        }


        public DataTable LayHoaDon(int MaHD)
        {
            string query = "SP_lay_HoaDon @MaHD";
            return    DataProvider.Instance.ExecuteQuery(query, new object[] { MaHD });

        }

        public void AddHoaDon(HoaDon hd , CtietHoaDon cthd)
        {
            string query = $"SP_add_HoaDon @MaHD  ,  @NgayLap , @TongTien ,  @MaKH ,     @MaNV , @MaSP  , @SoLuong ,  @DonGia   ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    hd.MaHD,
                    hd.NgayLap,
                    hd.TongTien,
                    hd.MaKH,
                    hd.MaNV,
                    cthd.MaSP,
                    cthd.SoLuong,
                    cthd.DonGia

                });
        }

        public void UpdateHoaDon(HoaDon hd, CtietHoaDon cthd)
        {
            string query = $"SP_Update_Khachhang @MaHD  ,  @NgayLap , @TongTien ,  @MaKH ,     @MaNV , @MaSP  , @SoLuong ,  @DonGia ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    hd.MaHD,
                    hd.NgayLap,
                    hd.TongTien,
                    hd.MaKH,
                    hd.MaNV,
                    cthd.MaSP,
                    cthd.SoLuong,
                    cthd.DonGia,
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
