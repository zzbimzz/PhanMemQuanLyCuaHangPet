using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_ThongKe
    {
        // Phương thức lấy danh sách hóa đơn từ cơ sở dữ liệu
        /*        public List<HoaDon> LayDanhSachHoaDon()
                {
                    List<HoaDon> danhSachHoaDon = new List<HoaDon>();

                    // Thực hiện truy vấn cơ sở dữ liệu để lấy danh sách hóa đơn
                    string query = "SELECT * FROM HoaDon";
                    DataTable data = DataProvider.Instance.ExecuteQuery(query);

                    foreach (DataRow row in data.Rows)
                    {
                        // Tạo đối tượng hóa đơn từ dữ liệu trong cơ sở dữ liệu
                        HoaDon hoaDon = new HoaDon();
                        hoaDon.MaHD = (int)row["MaHD"];
                        hoaDon.NgayLap = (DateTime)row["NgayLap"];
                        hoaDon.TongTien = (float)row["TongTien"];
                        hoaDon.MaKH = (int)row["MaKH"];
                        hoaDon.MaNV = (int)row["MaNV"];

                        // Thêm hóa đơn vào danh sách
                        danhSachHoaDon.Add(hoaDon);
                    }

                    return danhSachHoaDon;
                }

                // Phương thức lấy danh sách chi tiết hóa đơn dựa trên mã hóa đơn
                public List<CtietHoaDon> LayChiTietHoaDon(int MaHD)
                {
                    List<CtietHoaDon> danhSachChiTiet = new List<CtietHoaDon>();

                    // Thực hiện truy vấn cơ sở dữ liệu để lấy danh sách chi tiết hóa đơn
                    string query = $"SELECT * FROM ChiTietHoaDon WHERE MaHD = {MaHD}";
                    DataTable data = DataProvider.Instance.ExecuteQuery(query);

                    foreach (DataRow row in data.Rows)
                    {
                        // Tạo đối tượng chi tiết hóa đơn từ dữ liệu trong cơ sở dữ liệu
                        CtietHoaDon chiTiet = new CtietHoaDon();
                        chiTiet.MaHD = (int)row["MaHD"];
                        chiTiet.MaSP = (int)row["MaSP"];
                        chiTiet.SoLuong = (int)row["SoLuong"];
                        chiTiet.DonGia = (float)row["DonGia"];

                        // Thêm chi tiết hóa đơn vào danh sách
                        danhSachChiTiet.Add(chiTiet);
                    }

                    return danhSachChiTiet;
                }*/

/*        public DataTable GetHoaDon()
        {
            string query = "SP_hienthi_HoaDon";
            return DataProvider.Instance.ExecuteQuery(query);
        }*/


        public float LayTongTienSanPhamDaBanTheoNgay(DateTime ngayLap)
        {
            float tongTien = 0;

            // Thực hiện truy vấn cơ sở dữ liệu để lấy tổng tiền theo ngày lập hóa đơn
            string query = $"SP_LayTongTienSanPhamDaBanTheoNgay @NgayLap";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { ngayLap });

            // Kiểm tra và trích xuất giá trị tổng tiền
            if (data.Rows.Count > 0 && data.Rows[0][0] != DBNull.Value)
            {
                tongTien = Convert.ToSingle(data.Rows[0][0]);
            }

            return tongTien;
        }


        public float LayTongTienSanPhamDaBanTheoThang(DateTime ngayLap)
        {
            float tongTien = 0;

            // Trích xuất thông tin về tháng từ ngày lập hóa đơn
            int thang = ngayLap.Month;

            // Thực hiện truy vấn cơ sở dữ liệu để lấy tổng tiền theo tháng
            string query = $"SP_LayTongTienSanPhamDaBanTheoThang @NgayLap";
            DataTable data = DataProvider.Instance.ExecuteQuery(query ,new object[] {thang});

            // Kiểm tra và trích xuất giá trị tổng tiền
            if (data.Rows.Count > 0 && data.Rows[0][0] != DBNull.Value)
            {
                tongTien = Convert.ToSingle(data.Rows[0][0]);
            }

            return tongTien;
        }


        public float LayTongTienSanPhamDaBanTheoNam(DateTime ngayLap)
        {
            float tongTien = 0;

            // Trích xuất thông tin về năm từ ngày lập hóa đơn
            int nam = ngayLap.Year;

            // Thực hiện truy vấn cơ sở dữ liệu để lấy tổng tiền theo tháng
            string query = $"SP_LayTongTienSanPhamDaBanTheoNam @NgayLap";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] {nam});

            // Kiểm tra và trích xuất giá trị tổng tiền
            if (data.Rows.Count > 0 && data.Rows[0][0] != DBNull.Value)
            {
                tongTien = Convert.ToSingle(data.Rows[0][0]);
            }

            return tongTien;
        }



    }
}
