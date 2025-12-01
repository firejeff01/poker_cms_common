namespace Poker.CMS.Common.Exceptions
{
    /// <summary>
    /// 前端輸入錯誤的例外 (不會發 Telegram)
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
