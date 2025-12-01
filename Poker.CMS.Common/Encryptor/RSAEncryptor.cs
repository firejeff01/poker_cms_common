using System.Security.Cryptography;
using System.Text;

namespace Poker.CMS.Common.Encryptor
{
    public class RSAEncryptor
    {
        /// <summary>
        /// 用公開金鑰 (PEM格式) 加密字串
        /// </summary>
        /// <param name="plainText">要加密的明文字串</param>
        /// <param name="publicKeyPem">RSA 公鑰 (PEM格式)</param>
        /// <returns>Base64編碼的加密字串</returns>
        public static string Encrypt(string plainText, string publicKeyPem)
        {
            using var rsa = RSA.Create();

            // 載入 PEM 格式的公開金鑰
            rsa.ImportFromPem(publicKeyPem.ToCharArray());

            var data = Encoding.UTF8.GetBytes(plainText);
            var encryptedData = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);

            return Convert.ToBase64String(encryptedData);
        }

        /// <summary>
        /// 用私鑰 (PEM格式) 解密字串
        /// </summary>
        /// <param name="cipherText">Base64編碼的加密字串</param>
        /// <param name="privateKeyPem">RSA 私鑰 (PEM格式)</param>
        /// <returns>解密後的明文字串</returns>
        public static string Decrypt(string cipherText, string privateKeyPem)
        {
            using var rsa = RSA.Create();

            // 載入 PEM 格式的私鑰
            rsa.ImportFromPem(privateKeyPem.ToCharArray());

            var encryptedData = Convert.FromBase64String(cipherText);
            var decryptedData = rsa.Decrypt(encryptedData, RSAEncryptionPadding.Pkcs1);

            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}