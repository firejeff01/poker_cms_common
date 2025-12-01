using Poker.CMS.Common.DTOs;

namespace Poker.CMS.Common.Startup.Interface
{
    public interface IDatabaseHealthChecker
    {
        string DbType { get; }
        DatabaseStatus Check(string connectionString);
    }
}
