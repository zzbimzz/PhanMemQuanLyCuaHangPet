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

        public List<SanPham> GetAll(DataTable tbsanpham)
        {
            List<SanPham> listSP = new List<SanPham>();
            foreach (DataRow row in tbsanpham.Rows)
            {
                SanPham sp = new SanPham()
                {
                    MaSP = int.Parse(row["MaSP"].ToString()),
                    TenSP = row["TenSP"].ToString(),
                    GiaTien = float.Parse(row["GiaTien"].ToString()),
                    SoLuong = int.Parse(row["SoLuong"].ToString()),

                };
                listSP.Add(sp);
            }
            return listSP;
        }


        public void KetXuatWord(string exportPath)
        {
            List<SanPham> sanphamlist = GetAll(dal_sanpham.GetSanPham());
            List<object> objectList = new List<object>();
            foreach (SanPham pT in sanphamlist)
            {
                objectList.Add((object)pT);
            }

            //WordHelper.ExportToWord(objectList, "Template\\SanPham_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\SanPham_Template.xlsx", dal_sanpham.GetSanPham());
        }
    }
}
