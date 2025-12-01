namespace Poker.CMS.Common.Helpers
{
    public class Encode
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64EncodeUrl(string planText)
        {
            var base64 = Base64Encode(planText);
            return base64.Replace("+", "-").Replace("/", "_").TrimEnd('=');
        }
    }
}
