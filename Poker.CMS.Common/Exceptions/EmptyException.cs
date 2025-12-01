namespace Poker.CMS.Common.Exceptions
{
    /// <summary>
    /// 可預期的查無資料例外 (不會發 Telegram)
    /// </summary>
    public class EmptyException : Exception
    {
        public EmptyException()
        {
        }

        public EmptyException(string message)
            : base(message)
        {
        }

        public EmptyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
