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

        public void AddTaiKhoan(KhoHang kh)
        {
            dal_khohang.AddKhoHang(kh);
        }
        public void UpdateTaiKhoan(KhoHang kh)
        {
            dal_khohang.UpdateKhoHang(kh);
        }

        public void DeleteTaiKhoan(int MaKho)
        {
            dal_khohang.DeleteKhoHang(MaKho);
        }


        public DataTable SearchTaiKhoan(string keyword)
        {
            return dal_khohang.SearchKhoHang(keyword);
        }

        public List<KhoHang> GetAll(DataTable tbkhohang)
        {
            List<KhoHang> listkho = new List<KhoHang>();
            foreach (DataRow row in tbkhohang.Rows)
            {
                KhoHang kh = new KhoHang()
                {
                    MaKho = int.Parse(row["MaKho"].ToString()),
                    MaSP = int.Parse(row["MaSP"].ToString()),
                    SoLuongTon = int.Parse(row["SoLuongTon"].ToString()),

                };
                listkho.Add(kh);
            }
            return listkho;
        }


        public void KetXuatWord(string exportPath)
        {
            List<KhoHang> listkh = GetAll(dal_khohang.GetKhoHang());
            List<object> objectList = new List<object>();
            foreach (KhoHang tk in listkh)
            {
                objectList.Add((object)tk);
            }

            WordHelper.ExportToWord(objectList, "Template\\KhoHang_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\KhoHang_Template.xlsx", dal_khohang.GetKhoHang());
        }
    }
}
