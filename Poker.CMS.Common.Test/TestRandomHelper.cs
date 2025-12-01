using Poker.CMS.Common.Encryptor;
using Poker.CMS.Common.Helpers;

namespace Poker.CMS.Common.Test
{
    [TestClass]
    public class TestRandomHelper
    {
        [TestMethod]
        public void Test()
        {
            var hash = new HashSet<string>();

            for (int i = 0; i < 1000; i++)
            {
                var str = RandomHelper.GenerateRandomString(32);
                Assert.IsFalse(hash.Contains(str));
                hash.Add(str);
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestDecryptAES256CBC()
        {
            var seckey = RandomHelper.GenerateRandomString(32);
            var content = "Hello World!";
            var encrypted = AES256CBCEncryptor.EncryptAES256CBCByText(content, seckey);
            var decrypted = AES256CBCEncryptor.DecryptAES256CBC(encrypted, seckey);
            Assert.AreEqual(content, decrypted);
        }
    }
}