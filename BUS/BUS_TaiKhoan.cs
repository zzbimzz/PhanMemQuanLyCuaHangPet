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
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan dal_taikhoan = new DAL_TaiKhoan();


/*        public DataTable GetTaiKhoanDangNhap(string tenTaiKhoan, string matKhau)
        {
            return dal_taikhoan.GetTaiKhoan1(tenTaiKhoan, matKhau);
        }*/


        public bool kiemTraTK(string tenTaiKhoan1, string matKhau1)
        {
            return dal_taikhoan.GetTaiKhoan1(tenTaiKhoan1, matKhau1).Rows.Count > 0;
        }

        public DataTable GetTaiKhoanNhanVien(string tentaikhoan, string matkhau)
        {
            return dal_taikhoan.GetTaiKhoanNhanVien(tentaikhoan, matkhau);
        }


        public DataTable GetTaiKhoan()
        {
            return dal_taikhoan.GetTaiKhoan();
        }

        public void AddTaiKhoan(TaiKhoan tk)
        {
            dal_taikhoan.AddTaiKhoan(tk);
        }
        public void UpdateTaiKhoan(TaiKhoan tk)
        {
            dal_taikhoan.UpdateTaiKhoan(tk);
        }

        public void DeleteTaiKhoan(int MaTK)
        {
            dal_taikhoan.DeleteTaiKhoan(MaTK);
        }


        public DataTable SearchTaiKhoan(string keyword)
        {
            return dal_taikhoan.SearchTaiKhoan(keyword);
        }


        public void KetXuatWord(string exportPath)
        {


            WordHelper.ExportToWord(dal_taikhoan.GetTaiKhoan(), "Template\\TaiKhoan_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\TaiKhoan_Template.xlsx", dal_taikhoan.GetTaiKhoan());
        }
    }
}
