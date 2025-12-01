using System.Security.Cryptography;
using System.Text;

namespace Poker.CMS.Common.Encryptor
{
    public class AES256CBCEncryptor
    {
        /// <summary>
        /// Encrypts the AES 256 CBC by text.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="secretKey">The secret key. 長度必須剛好32個字元</param>
        /// <returns></returns>
        public static string EncryptAES256CBCByText(string data, string secretKey)
        {
            // 生成適用於 AES-256 的密鑰
            byte[] key = Encoding.UTF8.GetBytes(secretKey);
            byte[] iv = new byte[16];

            RandomNumberGenerator.Fill(iv);

            // 使用 Aes 進行加密，並且使用 PKCS7 填充方式
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(data);
                        }
                        byte[] encrypted = msEncrypt.ToArray();
                        string code = Convert.ToBase64String(iv.Concat(encrypted).ToArray());

                        return code; // 僅返回需要的數據
                    }
                }
            }
        }

        /// <summary>
        /// Decrypts the AES 256 CBC.
        /// </summary>
        /// <param name="encryptContent">Content of encrypt.</param>
        /// <param name="secretKey">The secret key. 長度必須剛好32個字元</param>
        /// <returns></returns>
        public static string DecryptAES256CBC(string encryptContent, string secretKey)
        {
            // 先將 Base64 轉回 byte 陣列
            byte[] fullCipher = Convert.FromBase64String(encryptContent);

            // AES-256 需要 32 字節的金鑰
            byte[] key = Encoding.UTF8.GetBytes(secretKey);

            // 提取 IV（前 16 字節）
            byte[] iv = fullCipher.Take(16).ToArray();

            // 提取加密內容（去掉 IV 的部分）
            byte[] cipherText = fullCipher.Skip(16).ToArray();

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }


    }
}