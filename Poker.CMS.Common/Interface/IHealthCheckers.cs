namespace Poker.CMS.Common.Interface
{
    /// <summary>
    /// Interfaces for health check
    /// </summary>
    public interface IFtpHealthChecker
    {
        Task<bool> CheckConnectionAsync();
    }

    public interface IAwsHealthChecker
    {
        Task<bool> CheckConnectionAsync();
    }

    public interface IGameServerApiHealthChecker
    {
        Task<bool> CheckExternalApiAsync();
    }
}
