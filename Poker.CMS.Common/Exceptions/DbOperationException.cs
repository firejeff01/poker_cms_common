namespace Poker.CMS.Common.Exceptions
{
    /// <summary>
    /// 操作 DB 異常 (會發 Telegram)
    /// </summary>
    /// <seealso cref="Exception" />
    public class DbOperationException : Exception
    {
        public DbOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
