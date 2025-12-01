namespace Poker.CMS.Common.OperationLog
{
    public interface IOperationLogRepository
    {
        Task InsertAsync(OperationLog log);
    }
}