using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserService.Utilities;

namespace TestProject
{
    [TestClass]
    public class HashingTest
    {
        [TestMethod]
        public void TestCorrectHash()
        {
            UserService.Utilities.Pbkdf2Utility pbkdf2Utility = new UserService.Utilities.Pbkdf2Utility();

            string hash1 = Pbkdf2Utility.HashPassword("testinput");

            bool result = Pbkdf2Utility.ValidatePassword("testinput", hash1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestWrongtHash()
        {
            UserService.Utilities.Pbkdf2Utility pbkdf2Utility = new UserService.Utilities.Pbkdf2Utility();

            string hash1 = Pbkdf2Utility.HashPassword("testinput");

            bool result = Pbkdf2Utility.ValidatePassword("testinput", hash1);

            Assert.IsTrue(result);
        }
    }
}
