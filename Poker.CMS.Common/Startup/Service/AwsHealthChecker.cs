using Poker.CMS.Common.DTOs;
using Poker.CMS.Common.Interface;
using System.Diagnostics;
using Poker.CMS.Common.Startup.Interface;

namespace Poker.CMS.Common.Startup.Service
{
    public class AwsHealthChecker : IExternalServiceChecker
    {
        private readonly IAwsHealthChecker _awsChecker;

        public AwsHealthChecker(IAwsHealthChecker awsChecker) => _awsChecker = awsChecker;
        public string ServiceType => "AWS";

        public async Task<ExternalServiceStatus> CheckConnection()
        {
            try
            {
                var sw = Stopwatch.StartNew();
                bool ok = await _awsChecker.CheckConnectionAsync();
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
