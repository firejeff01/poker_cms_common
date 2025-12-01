namespace Poker.CMS.Common.Exceptions
{
    /// <summary>
    /// 權限不足、功能限制等例外
    /// HTTP Status Code 403。
    /// </summary>
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message)
            : base(message)
        {
        }
    }
}
