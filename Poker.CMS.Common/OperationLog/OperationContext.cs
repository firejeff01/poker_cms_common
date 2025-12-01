namespace Poker.CMS.Common.OperationLog
{
    public class OperationContext : IOperationContext
    {
        public OperationContext()
        {
        }

        public string? BeforeData { get; set; }

        public string? AfterData { get; set; }

        public int? LoginUserId { get; set; }

        public string? LoginUserName { get; set; }
    }
}