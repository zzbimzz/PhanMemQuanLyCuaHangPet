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
    public class BUS_HoaDonNhap_CTHDNhap
    {
        DAL_HoaDonNhap_CTHDNhap dal_hdn_cthdn = new DAL_HoaDonNhap_CTHDNhap();


        public DataTable GetHoaDonNhap()
        {
            return dal_hdn_cthdn.GetHoaDonNhap();
        }


        public void AddHoaDonNhap(HoaDonNhap hdn, ChiTietHoaDonNhap cthdn)
        {
            dal_hdn_cthdn.AddHoaDonNhap(hdn, cthdn);
        }


        public void UpdateHoaDonNhap(HoaDonNhap hdn, ChiTietHoaDonNhap cthdn)
        {
            dal_hdn_cthdn.UpdateHoaDonNhap(hdn, cthdn);
        }

        public void DeleteHoaDonNhap(int MaHDN)
        {
            dal_hdn_cthdn.DeleteHoaDonNhap(MaHDN);
        }

        public DataTable SearchHoaDonNhap(string keyword)
        {
            return dal_hdn_cthdn.SP_Search_HoaDonNhap(keyword);
        }


        public void KetXuatWord(string exportPath, int MaHDN)
        {

            WordHelper.ExportToWord(dal_hdn_cthdn.LayHoaDonNhap(MaHDN), "Template\\HoaDonNhap_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath, int MaHDN)
        {

            ExcelHelper.WriteExcelFile(filePath, "Template\\HoaDonNhap_Template.xlsx", dal_hdn_cthdn.LayHoaDonNhap(MaHDN));
        }

    }
}
