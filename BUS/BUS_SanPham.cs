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
    public class BUS_SanPham
    {
        DAL_SanPham dal_sanpham = new DAL_SanPham();

        public DataTable GetSanPham()
        {
            return dal_sanpham.GetSanPham();
        }

        public void AddSanPham(SanPham sanpham)
        {
            dal_sanpham.AddSanPham(sanpham);
        }
        public void UpdateSanPham(SanPham sanpham)
        {
            dal_sanpham.UpdateSanPham(sanpham);
        }

        public void DeleteSanPham(int MaSP)
        {
            dal_sanpham.DeleteSanPham(MaSP);
        }


        public DataTable SearchSanPham(string keyword)
        {
            return dal_sanpham.SearchSanPham(keyword);
        }



        public void KetXuatWord(string exportPath)
        {

            WordHelper.ExportToWord(dal_sanpham.GetSanPham(), "Template\\SanPham_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\SanPham_Template.xlsx", dal_sanpham.GetSanPham());
        }
    }
}
