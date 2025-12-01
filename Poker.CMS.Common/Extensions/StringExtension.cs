using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Poker.CMS.Common.Extensions
{
    public static class StringExtension
    {
        public static string GetMd5Hash(this string input)
        {
            // Create an instance of the MD5CryptoServiceProvider class
            using (MD5 md5 = MD5.Create())
            {
                // Compute the hash of the input string
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        // 轉成蛇形命名法, GoldCause => gold_cause
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string result = Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2");
            return result.ToLower();
        }
    }
}