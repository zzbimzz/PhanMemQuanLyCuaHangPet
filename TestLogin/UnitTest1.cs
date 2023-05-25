using BUS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestLogin
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogin_NhapDung()
        {
            // Arrange
            BUS_TaiKhoan loginForm = new BUS_TaiKhoan();
            string username = "thuan";
            string password = "123";

            // Act
            bool result = loginForm.kiemTraTK(username, password);

            // Assert
            Assert.AreEqual(result, true);
        }

    }
}
