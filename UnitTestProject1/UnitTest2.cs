using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BUS;
using System.Globalization;
using DTO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        /*        [TestMethod]
                public void TestaddKH_ThanhCong()
                {
                    BUS_KhachHang bUS_kh = new BUS_KhachHang();

                    KhachHang kh = new KhachHang()
                    {
                        MaKH = 18,
                        TenKH = "minh thuan",
                        DiaChi = "da nang",
                        SoDienThoai = "0929", 
                    };

                    bool result = bUS_kh.AddKhachHang(kh);
                    Assert.AreEqual(result, true);

                }*/

        /*[TestMethod]
        public void TestThemKhachHang_TrungMa()
        {
            BUS_KhachHang busKH = new BUS_KhachHang();

            KhachHang kh = new KhachHang()
            {
                MaKH = 18,
                TenKH = "dep trai",
                DiaChi = "hung yen",
                SoDienThoai = "555",
            };
            bool result = busKH.AddKhachHang(kh);
            Assert.IsFalse(result);
        }*/



        /*[TestMethod]
        public void TestSuaKhachHang_ThanhCong()
        {
            BUS_KhachHang busKH = new BUS_KhachHang();

            KhachHang kh = new KhachHang()
            {
                MaKH = 16,
                TenKH = "do tien tung",
                DiaChi = "hung yen",
                SoDienThoai = "753",
            };
            bool result = busKH.EditKhachHang(kh);
            Assert.IsTrue(result);
        }*/


        /*[TestMethod]
        public void TestSuaKhachHang_ThatBai()
        {
            BUS_KhachHang busKH = new BUS_KhachHang();

            KhachHang kh = new KhachHang()
            {
                MaKH = 100,
                TenKH = "do tien tai",
                DiaChi = "hung yen",
                SoDienThoai = "999",
            };
            bool result = busKH.EditKhachHang(kh);
            Assert.IsFalse(result);
        }*/


        /*[TestMethod]
        public void TestXoaKhachHang_ThanhCong()
        {
            BUS_KhachHang bus_KH = new BUS_KhachHang();
            int MaKH = 7;

            bool result = bus_KH.DeleteKhachHang(MaKH);
            Assert.AreEqual(result, true);
        }*/


        [TestMethod]
        public void TestXoaKhachHang_mahkhongtontai()
        {
            BUS_KhachHang bus_KH = new BUS_KhachHang();
            int MaKH = 100;

            bool result = bus_KH.DeleteKhachHang(MaKH);
            Assert.IsFalse(result);
        }

    }
}
