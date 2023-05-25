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
    public class BUS_NhanVien
    {
        DAL_NhanVien dal_nhanvien = new DAL_NhanVien();

        public DataTable GetNhanVien()
        {
            return dal_nhanvien.GetNhanVien();
        }

        public bool AddNhanVien(NhanVien nhanvien)
        {
            try
            {
                return    dal_nhanvien.AddNhanVien(nhanvien);
            }
            catch  { return false; }
        }
        public bool EditNhanVien(NhanVien nhanvien)
        {
            return dal_nhanvien.UpdateNhanVien(nhanvien);
        }

        public bool DeleteNhanVien(int MaNV)
        {
            return dal_nhanvien.DeleteNhanVien(MaNV);
        }


        public DataTable SearchNhanVien(string keyword)
        {
            return dal_nhanvien.SearchNhanVien(keyword);
        }


        public void KetXuatWord(string exportPath)
        {


            WordHelper.ExportToWord(dal_nhanvien.GetNhanVien(), "Template\\NhanVien_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath)
        {

            ExcelHelper.WriteExcelFile(filePath, "Template\\NhanVien_Template.xlsx", dal_nhanvien.GetNhanVien());
        }

    }
}
