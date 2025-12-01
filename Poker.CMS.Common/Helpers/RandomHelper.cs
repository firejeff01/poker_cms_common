using System.Security.Cryptography;
using System.Text;

namespace Poker.CMS.Common.Helpers
{
    public static class RandomHelper
    {
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            StringBuilder result = new StringBuilder(length);
            byte[] randomBytes = new byte[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            foreach (var b in randomBytes)
            {
                result.Append(chars[b % chars.Length]);
            }

            return result.ToString();
        }
    }
}
