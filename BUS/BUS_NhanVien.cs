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

        public void AddNhanVien(NhanVien nhanvien)
        {
            dal_nhanvien.AddNhanVien(nhanvien);
        }
        public void EditNhanVien(NhanVien nhanvien)
        {
            dal_nhanvien.UpdateNhanVien(nhanvien);
        }

        public void DeleteNhanVien(int MaNV)
        {
            dal_nhanvien.DeleteNhanVien(MaNV);
        }


        public DataTable SearchNhanVien(string keyword)
        {
            return dal_nhanvien.SearchNhanVien(keyword);
        }

        public List<NhanVien> GetAll(DataTable tbnhanvien)
        {
            List<NhanVien> listKH = new List<NhanVien>();
            foreach (DataRow row in tbnhanvien.Rows)
            {
                NhanVien nv = new NhanVien()
                {
                    MaNV = (int)row["MaNV"],
                    TenNV = row["TenNV"].ToString(),
                    ChucVu = row["ChucVu"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),

                };
                listKH.Add(nv);
            }
            return listKH;
        }


        public void KetXuatWord(string exportPath)
        {
            List<NhanVien> nhanvienlist = GetAll(dal_nhanvien.GetNhanVien());
            List<object> objectList = new List<object>();
            foreach (NhanVien pT in nhanvienlist)
            {
                objectList.Add((object)pT);
            }

            //WordHelper.ExportToWord(objectList, "Template\\NhanVien_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath)
        {
            List<NhanVien> nhanvienlist = GetAll(dal_nhanvien.GetNhanVien());
            List<object> objectList = new List<object>();
            foreach (NhanVien pT in nhanvienlist)
            {
                objectList.Add((object)pT);
            }
            ExcelHelper.WriteExcelFile(filePath, "Template\\NhanVien_Template.xlsx", dal_nhanvien.GetNhanVien());
        }

    }
}
