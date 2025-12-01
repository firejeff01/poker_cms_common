using MongoDB.Bson;
using MongoDB.Driver;
using Poker.CMS.Common.DTOs;
using System.Diagnostics;
using Poker.CMS.Common.Startup.Interface;
using Poker.CMS.Common.Interface;

namespace Poker.CMS.Common.Startup.Service
{
    public class FtpHealthChecker : IExternalServiceChecker
    {

        private readonly IFtpHealthChecker _ftpChecker;

        public FtpHealthChecker(IFtpHealthChecker ftpChecker) => _ftpChecker = ftpChecker;
        public string ServiceType => "FTP";

        public async Task<ExternalServiceStatus> CheckConnection()
        {
            try
            {
                var sw = Stopwatch.StartNew();
                bool ok = await _ftpChecker.CheckConnectionAsync();
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
