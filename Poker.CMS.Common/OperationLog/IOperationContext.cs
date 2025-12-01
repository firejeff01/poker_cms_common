namespace Poker.CMS.Common.OperationLog
{
    public interface IOperationContext
    {
        string? BeforeData { get; set; }

        string? AfterData { get; set; }

        int? LoginUserId { get; set; }

        string? LoginUserName { get; set; }
    }
}