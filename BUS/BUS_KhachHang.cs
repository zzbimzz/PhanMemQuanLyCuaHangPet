using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DocumentFormat.OpenXml.Bibliography;
using DTO;
using Novacode;


namespace BUS
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dal_khachhang = new DAL_KhachHang();

        public DataTable GetKhachHang()
        {
            return dal_khachhang.GetKhachHang();
        }

        public void AddKhachHang(KhachHang khachHang)
        {
            dal_khachhang.AddKhachHang(khachHang);
        }
        public void EditKhachHang(KhachHang khachHang)
        {
            dal_khachhang.SP_Update_Khachhang(khachHang);
        }

        public void DeleteKhachHang(int MaKH)
        {
            dal_khachhang.SP_Delete_Khachhang(MaKH);
        }


        public DataTable SearchKhachHang(string keyword)
        {
            return dal_khachhang.SP_Search_KhachHang(keyword);
        }

        public List<KhachHang> GetAll(DataTable tbkhachHang)
        {
            List<KhachHang> listKH = new List<KhachHang>();
            foreach (DataRow row in tbkhachHang.Rows)
            {
                KhachHang kH = new KhachHang()
                {
                    MaKH = (int)row["MaKH"],
                    TenKH = row["TenKH"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),

                };
                listKH.Add(kH);
            }
            return listKH;
        }

        public void KetXuatWord(string exportPath)
        {
            List<KhachHang> khachhanglist = GetAll(dal_khachhang.GetKhachHang());
            List<object> objectList = new List<object>();
            foreach (KhachHang pT in khachhanglist)
            {
                objectList.Add((object)pT);
            }

            WordHelper.ExportToWord(dal_khachhang.GetKhachHang(), "Template\\KhachHang_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath)
        {
            List<KhachHang> khachhanglist = GetAll(dal_khachhang.GetKhachHang());
            List<object> objectList = new List<object>();
            foreach (KhachHang pT in khachhanglist)
            {
                objectList.Add((object)pT);
            }
            ExcelHelper.WriteExcelFile(filePath, "Template\\KhachHang_Template.xlsx", dal_khachhang.GetKhachHang());
        }


    }
}
