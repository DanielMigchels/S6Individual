using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Shared.Jwt;

namespace TestProject
{
    [TestClass]
    public class JwtTest
    {
        [TestMethod]
        public void TestCorrectUser()
        {
            User user = new User()
            {
                Id = 400,
                Username = "test",
                Password = "test"
            };

            string jwt = JwtUtility.GenerateJwt(user);

            int? userId = JwtUtility.ReadJwt(jwt);

            Assert.AreEqual(400, userId);
        }

        [TestMethod]
        public void TestWrongUser()
        {
            User user = new User()
            {
                Id = 837,
                Username = "test",
                Password = "test"
            };

            string jwt = JwtUtility.GenerateJwt(user);

            int? userId = JwtUtility.ReadJwt(jwt);

            Assert.AreNotEqual(400, userId);
        }
    }
}
