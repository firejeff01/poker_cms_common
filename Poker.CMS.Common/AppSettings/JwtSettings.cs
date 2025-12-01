namespace Poker.CMS.Common.AppSettings
{
    public class JwtSettings
    {
        public string Issuer { get; set; }

        public string SignKey { get; set; }

        public int ExpirationInDays { get; set; }

    }
}
