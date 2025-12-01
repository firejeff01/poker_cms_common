using Poker.CMS.Common.DTOs;

namespace Poker.CMS.Common.Startup.Interface
{
    public interface IExternalServiceChecker
    {
        string ServiceType { get; }
        Task<ExternalServiceStatus> CheckConnection();
    }
}
