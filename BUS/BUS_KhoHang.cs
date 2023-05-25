using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public class BUS_KhoHang
    {
        DAL_KhoHang dal_khohang = new DAL_KhoHang();


        public DataTable GetKhoHang()
        {
            return dal_khohang.GetKhoHang();
        }

        public void AddKhoHang(KhoHang kh)
        {
            dal_khohang.AddKhoHang(kh);
        }
        public void UpdateKhoHang(KhoHang kh)
        {
            dal_khohang.UpdateKhoHang(kh);
        }

        public void DeleteKhoHang(int MaKho)
        {
            dal_khohang.DeleteKhoHang(MaKho);
        }


        public DataTable SearchKhoHang(string keyword)
        {
            return dal_khohang.SearchKhoHang(keyword);
        }

        public void KetXuatWord(string exportPath)
        {


            WordHelper.ExportToWord(dal_khohang.GetKhoHang(), "Template\\KhoHang_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\KhoHang_Template.xlsx", dal_khohang.GetKhoHang());
        }
    }
}
