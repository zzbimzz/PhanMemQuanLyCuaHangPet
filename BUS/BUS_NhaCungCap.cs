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
    public class BUS_NhaCungCap
    {
        DAL_NhaCungCap dal_nhacungcap = new DAL_NhaCungCap();
        public DataTable GetNhaCungCap()
        {
            return dal_nhacungcap.GetNhaCungCap();
        }

        public void AddNhaCungCap(NhaCungCap ncc)
        {
            dal_nhacungcap.AddNhaCungCap(ncc);
        }
        public void EditNhaCungCap(NhaCungCap ncc)
        {
            dal_nhacungcap.UpdateNhaCungCap(ncc);
        }

        public void DeleteNhaCungCap(int MaNCC)
        {
            dal_nhacungcap.DeleteNhaCungCap(MaNCC);
        }


        public DataTable SearchNhaCungCap(string keyword)
        {
            return dal_nhacungcap.SearchNhaCungCap(keyword);
        }


        public void KetXuatWord(string exportPath)
        {


            WordHelper.ExportToWord(dal_nhacungcap.GetNhaCungCap(), "Template\\NhaCungCap_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath)
        {

            ExcelHelper.WriteExcelFile(filePath, "Template\\NhaCungCap_Template.xlsx", dal_nhacungcap.GetNhaCungCap());
        }
    }
}
