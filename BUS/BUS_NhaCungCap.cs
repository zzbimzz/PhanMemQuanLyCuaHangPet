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

        public List<NhaCungCap> GetAll(DataTable tbnhacungcap)
        {
            List<NhaCungCap> listncc = new List<NhaCungCap>();
            foreach (DataRow row in tbnhacungcap.Rows)
            {
                NhaCungCap ncc = new NhaCungCap()
                {
                    MaNCC = (int)row["MaNCC"],
                    TenNCC = row["TenNCC"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),

                };
                listncc.Add(ncc);
            }
            return listncc;
        }

        public void KetXuatWord(string exportPath)
        {
            List<NhaCungCap> ncclist = GetAll(dal_nhacungcap.GetNhaCungCap());
            List<object> objectList = new List<object>();
            foreach (NhaCungCap ncc in ncclist)
            {
                objectList.Add((object)ncc);
            }

            //WordHelper.ExportToWord(objectList, "Template\\NhaCungCap_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath)
        {
            List<NhaCungCap> ncclist = GetAll(dal_nhacungcap.GetNhaCungCap());
            List<object> objectList = new List<object>();
            foreach (NhaCungCap ncc in ncclist)
            {
                objectList.Add((object)ncc);
            }
            ExcelHelper.WriteExcelFile(filePath, "Template\\NhaCungCap_Template.xlsx", dal_nhacungcap.GetNhaCungCap());
        }
    }
}
