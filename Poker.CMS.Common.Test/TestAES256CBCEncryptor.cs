using Poker.CMS.Common.Encryptor;

namespace Poker.CMS.Common.Test
{
    [TestClass]
    public sealed class TestAES256CBCEncryptor
    {
        /// <summary>
        /// The secret key 長度必須剛好32個字元
        /// </summary>
        private const string _secretKey = "12345678901234567890123456789012";

        [TestMethod]
        public void TestDecryptAES256CBC()
        {
            var content = @"Hello, World!";
            var encrypted = AES256CBCEncryptor.EncryptAES256CBCByText(content, _secretKey);
            var decrypted = AES256CBCEncryptor.DecryptAES256CBC(encrypted, _secretKey);
            Assert.AreEqual(content, decrypted);
        }
    }
}