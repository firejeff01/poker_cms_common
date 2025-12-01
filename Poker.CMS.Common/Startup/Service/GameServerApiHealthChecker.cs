using Poker.CMS.Common.DTOs;
using Poker.CMS.Common.Interface;
using System.Diagnostics;
using Poker.CMS.Common.Startup.Interface;

namespace Poker.CMS.Common.Startup.Service
{
    public class GameServerApiHealthChecker : IExternalServiceChecker
    {
        private readonly IGameServerApiHealthChecker _gameServerChecker;

        public GameServerApiHealthChecker(IGameServerApiHealthChecker gameServerChecker) => _gameServerChecker = gameServerChecker;
        public string ServiceType => "GameServer";

        public async Task<ExternalServiceStatus> CheckConnection()
        {
            try
            {
                var sw = Stopwatch.StartNew();
                bool ok = await _gameServerChecker.CheckExternalApiAsync();
                sw.Stop();

                return new ExternalServiceStatus
                {
                    Check = ok ? "OK" : "Failed",
                    SpendTime = $"{sw.ElapsedMilliseconds}ms"
                };
            }
            catch (Exception ex)
            {
                return new ExternalServiceStatus
                {
                    Check = $"Failed: {ex.Message}",
                    SpendTime = "0ms"
                };
            }
        }
    }
}
