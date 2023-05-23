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


        public DataTable GetTaiKhoanDangNhap(string tenTaiKhoan, string matKhau)
        {
            return dal_taikhoan.GetTaiKhoan(tenTaiKhoan, matKhau);
        }

        public bool kiemTraTK(string tenTaiKhoan, string matKhau)
        {
            return dal_taikhoan.GetTaiKhoan(tenTaiKhoan, matKhau).Rows.Count > 0;
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

        public List<TaiKhoan> GetAll(DataTable tbtaikhoan)
        {
            List<TaiKhoan> listTK = new List<TaiKhoan>();
            foreach (DataRow row in tbtaikhoan.Rows)
            {
                TaiKhoan tk = new TaiKhoan()
                {
                    MaTK = int.Parse(row["MaTK"].ToString()),
                    TenTaiKhoan = row["TenTaiKhoan"].ToString(),
                    MatKhau = row["MatKhau"].ToString(),
                    MaNV = int.Parse(row["MaNV"].ToString()),

                };
                listTK.Add(tk);
            }
            return listTK;
        }


        public void KetXuatWord(string exportPath)
        {
            List<TaiKhoan> tklist = GetAll(dal_taikhoan.GetTaiKhoan());
            List<object> objectList = new List<object>();
            foreach (TaiKhoan tk in tklist)
            {
                objectList.Add((object)tk);
            }

            //WordHelper.ExportToWord(objectList, "Template\\TaiKhoan_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\TaiKhoan_Template.xlsx", dal_taikhoan.GetTaiKhoan());
        }
    }
}
