using BUS;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest3
    {
        /*        [TestMethod]
                public void TestThemNhanVien_ThanhCong()
                {
                    BUS_NhanVien bus_nv = new BUS_NhanVien();

                    NhanVien nv = new NhanVien()
                    {
                        MaNV = 24,
                        TenNV = "tung ttaii111",
                        ChucVu = "Nhân Viên",
                        DiaChi = "hung yen",
                        SoDienThoai = "0000111222",
                    };
                    bool result = bus_nv.AddNhanVien(nv);
                    Assert.IsTrue(result);
                }*/


        /*        [TestMethod]
                public void TestThemNhanVien_thatbai_trungma()
                {
                    BUS_NhanVien bus_nv = new BUS_NhanVien();

                    NhanVien nv = new NhanVien()
                    {
                        MaNV = 17,
                        TenNV = "laptop",
                        ChucVu = "Nhân Viên",
                        DiaChi = "ca mau",
                        SoDienThoai = "553",
                    };
                    bool result = bus_nv.AddNhanVien(nv);
                    Assert.IsFalse(result);
                }*/



        /*        [TestMethod]
                public void TestSuaNhanVien_ThanhCong()
                {
                    BUS_NhanVien bus_nv = new BUS_NhanVien();

                    NhanVien nv = new NhanVien()
                    {
                        MaNV = 16,
                        TenNV = "do tien linh phong",
                        ChucVu = "Nhân Viên",
                        DiaChi = "hung yen",
                        SoDienThoai = "17355",
                    };
                    bool result = bus_nv.EditNhanVien(nv);
                    Assert.IsTrue(result);
                }*/


        /*        [TestMethod]
                public void TestSuaNhanVien_thatbai()
                {
                    BUS_NhanVien bus_nv = new BUS_NhanVien();

                    NhanVien nv = new NhanVien()
                    {
                        MaNV = 99,
                        TenNV = "do tien tai",
                        ChucVu = "Nhân Viên",
                        DiaChi = "hung yen",
                        SoDienThoai = "555",
                    };
                    bool result = bus_nv.EditNhanVien(nv);
                    Assert.IsFalse(result);
                }*/


        /*[TestMethod]
        public void TestXoaNhanVien_ThanhCong()
        {
            BUS_NhanVien bus_nv = new BUS_NhanVien();
            int MaNV = 3;

            bool result = bus_nv.DeleteNhanVien(MaNV);
            Assert.AreEqual(result, true);
        }*/


/*        [TestMethod]
        public void TestXoaNhanVien_Thatbai_khongcoma()
        {
            BUS_NhanVien bus_nv = new BUS_NhanVien();
            int MaNV = 99;

            bool result = bus_nv.DeleteNhanVien(MaNV);
            Assert.IsFalse(result);
        }*/
    }
}
