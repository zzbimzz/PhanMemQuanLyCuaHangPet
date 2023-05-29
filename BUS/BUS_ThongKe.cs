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
    public class BUS_ThongKe
    {
        DAL_ThongKe dal_thongke = new DAL_ThongKe();
        DAL_HoaDon_CTietHoaDon dal_hd_cthd = new DAL_HoaDon_CTietHoaDon();


        /*        public List<HoaDon> LayDanhSachHoaDon()
                {
                    return dal_thongke.LayDanhSachHoaDon();
                }

                // Phương thức lấy danh sách chi tiết hóa đơn dựa trên mã hóa đơn
                public List<CtietHoaDon> LayChiTietHoaDon(int MaHD)
                {
                    return dal_thongke.LayChiTietHoaDon(MaHD);
                }*/

/*        public DataTable GetHoaDon()
        {
            return dal_thongke.GetHoaDon();
        }*/
        public float LayTongTienSanPhamDaBan(DateTime ngayLap)
        {
            return dal_thongke.LayTongTienSanPhamDaBanTheoNgay(ngayLap);
        }

        public float LayTongTienSanPhamDaBanTheoThang(DateTime ngayLap)
            
        {
            return dal_thongke.LayTongTienSanPhamDaBanTheoThang(ngayLap);
        }


        public float LayTongTienSanPhamDaBanTheoNam(DateTime ngayLap)

        {
            return dal_thongke.LayTongTienSanPhamDaBanTheoNam(ngayLap);
        }

        public DataTable TaoBangHoaDon(int ngay, int thang, int nam)
        {
            // Tạo DataTable và thêm cột
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Ngay");
            dataTable.Columns.Add("Thang");
            dataTable.Columns.Add("Nam");
            dataTable.Columns.Add("ThanhTien");

            dataTable.Rows.Add("Tiền Ngày", ngay, null, null);
            dataTable.Rows.Add("Tiền Tháng", null, thang, null);
            dataTable.Rows.Add("Tiền Năm", null, null, nam);

            return dataTable;
        }

        public void KetXuatWord(string exportPath, List<int> gia)
        {
            WordHelper.ExportToWord(TaoBangHoaDon(gia[0], gia[1], gia[2]), "Template\\ThongKe_Template.docx", exportPath);
        }

        public void XuatExcel(string filePath)
        {

            
        }

    }
}
