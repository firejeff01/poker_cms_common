using Poker.CMS.Common.Encryptor;
using Poker.CMS.Common.Test.Helpers;
using System.Text;

namespace Poker.CMS.Common.Test.Encryptor
{
    [TestClass]
    public class TestRSAEncryptor
    {
        [TestMethod]
        public void Test()
        {
            string basePath = AppContext.BaseDirectory; // 專案的執行目錄
            string publicKeyPath = Path.Combine(basePath, "secrets", "public_key.pem");
            string privateKeyPath = Path.Combine(basePath, "secrets", "private_key.pem");

            if (!File.Exists(publicKeyPath) || !File.Exists(privateKeyPath))
            {
                throw new FileNotFoundException("Public or Private key file not found under Secrets folder.");
            }

            string publicKeyXml = File.ReadAllText(publicKeyPath, Encoding.UTF8);
            string privateKeyXml = File.ReadAllText(privateKeyPath, Encoding.UTF8);

            string plainText = "MySuperSecretPassword";

            var encryptedText = RSAEncryptor.Encrypt(plainText, publicKeyXml);

            var decrytedText = RSAEncryptor.Decrypt(encryptedText, privateKeyXml);

            Assert.AreEqual(plainText, decrytedText);
        }
    }
}
