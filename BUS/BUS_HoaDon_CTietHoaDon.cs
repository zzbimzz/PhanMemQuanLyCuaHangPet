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
    public class BUS_HoaDon_CTietHoaDon
    {
        DAL_HoaDon_CTietHoaDon dal_hoadon_ctiethoadon = new DAL_HoaDon_CTietHoaDon();


        public DataTable GetHoaDon()
        {
            return dal_hoadon_ctiethoadon.GetHoaDon();
        }

        
        public void AddHoaDon(HoaDon hd, CtietHoaDon cthd)
        {
            dal_hoadon_ctiethoadon.AddHoaDon(hd,cthd);
        }

        public void UpdateHoaDon(HoaDon hd, CtietHoaDon cthd)
        {
            dal_hoadon_ctiethoadon.UpdateHoaDon(hd, cthd);
        }

        public void KetXuatWord(string exportPath , int MaHD )
        {

            WordHelper.ExportToWord(dal_hoadon_ctiethoadon.LayHoaDon(MaHD), "Template\\HoaDon_Template.docx", exportPath );

        }
    }
}
