using BUS;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{
    [TestClass]
    public class LoginFormTests
    {


        [TestMethod]
        public void TestLogin_KhongNhapMatKhau()
        {
            // Arrange
            BUS_TaiKhoan loginForm = new BUS_TaiKhoan(); // TC1
            string username = "abc";
            string password = "";

            // Act
            bool result = loginForm.kiemTraTK(username, password);

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestLogin_KhongNhapTenTaiKhoan() //TC2
        {
            // Arrange
            BUS_TaiKhoan loginForm = new BUS_TaiKhoan();
            string username = "";
            string password = "abc";

            // Act
            bool result = loginForm.kiemTraTK(username, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestLogin_NhapSaiMatKhau() //TC4
        {
            // Arrange
            BUS_TaiKhoan loginForm = new BUS_TaiKhoan();
            string username = "ql01";
            string password = "abc";

            // Act
            bool result = loginForm.kiemTraTK(username, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestLogin_NhapSaiTaiKhoan() //TC5
        {
            // Arrange
            BUS_TaiKhoan loginForm = new BUS_TaiKhoan();
            string username = "abc";
            string password = "123";

            // Act
            bool result = loginForm.kiemTraTK(username, password);

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestLogin_KhongNhap() //TC3
        {
            // Arrange
            BUS_TaiKhoan loginForm = new BUS_TaiKhoan();
            string username = "";
            string password = "";

            // Act
            bool result = loginForm.kiemTraTK(username, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestLogin_NhapDung() //TC6
        {
            // Arrange
            BUS_TaiKhoan loginForm = new BUS_TaiKhoan();
            string username = "tai";
            string password = "123";

            // Act
            bool result = loginForm.kiemTraTK(username, password);

            // Assert
            Assert.AreEqual(result, true);
        }

    }
}