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

        public bool AddKhachHang(KhachHang khachHang)
        {
            try
            {
                return dal_khachhang.AddKhachHang(khachHang);
            }
            catch { return false; }

        }
        public bool EditKhachHang(KhachHang khachHang)
        {
            return dal_khachhang.SP_Update_Khachhang(khachHang);
        }

        public bool DeleteKhachHang(int MaKH)
        {
            return dal_khachhang.SP_Delete_Khachhang(MaKH);
        }


        public DataTable SearchKhachHang(string keyword)
        {
            return dal_khachhang.SP_Search_KhachHang(keyword);
        }



        public void KetXuatWord(string exportPath)
        {


            WordHelper.ExportToWord(dal_khachhang.GetKhachHang(), "Template\\KhachHang_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath)
        {

            ExcelHelper.WriteExcelFile(filePath, "Template\\KhachHang_Template.xlsx", dal_khachhang.GetKhachHang());
        }


    }
}
