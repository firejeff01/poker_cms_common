namespace Poker.CMS.Common.Exceptions
{
    /// <summary>
    /// 登入失敗、帳號不存在或密碼錯誤等例外
    /// HTTP Status Code 401。
    /// </summary>
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message)
            : base(message)
        {
        }
    }
}
