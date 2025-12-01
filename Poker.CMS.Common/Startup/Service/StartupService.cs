using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Poker.CMS.Common.DTOs;
using Poker.CMS.Common.Interface;
using Poker.CMS.Common.Startup.Interface;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace Poker.CMS.Assistant.Api.Startup
{
    public class StartupService : IHostedService
    {
        private readonly IConfiguration _config;
        private readonly IHostApplicationLifetime _lifetime;
        private readonly IHostEnvironment _env;
        private readonly INotifier _notifier;
        private readonly IEnumerable<IDatabaseHealthChecker> _dbCheckers;
        private readonly IEnumerable<IExternalServiceChecker>? _externalChecker;

        public StartupService(
            IConfiguration config,
            IHostApplicationLifetime lifetime,
            IHostEnvironment env,
            INotifier notifier,
            IEnumerable<IDatabaseHealthChecker> dbCheckers,
            IEnumerable<IExternalServiceChecker>? externalChecker = null)
        {
            _config = config;
            _lifetime = lifetime;
            _env = env;
            _notifier = notifier;
            _dbCheckers = dbCheckers;
            _externalChecker = externalChecker;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _lifetime.ApplicationStarted.Register(async () =>
            {
                CheckServiceAlive();
                var dbStatus = CheckAllDatabaseStatus();

                Dictionary<string, ExternalServiceStatus>? externalStatus = null;
                if (_externalChecker != null)
                {
                    externalStatus = await CheckAllServiceAsync();
                }

                var msg = GetStartupMessage(dbStatus, externalStatus);

                var enable = bool.TryParse(_config["Telegram:Enable"], out var isEnabled) && isEnabled;
                if (enable)
                    await _notifier.SendAsync(msg);
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private Dictionary<string, DatabaseStatus> CheckAllDatabaseStatus()
        {
            var result = new Dictionary<string, DatabaseStatus>();
            var dbSections = _config.GetSection("ConnectionStrings").GetChildren();

            foreach (var dbGroup in dbSections)
            {
                foreach (var conn in dbGroup.GetChildren())
                {
                    var connValue = conn.Value;
                    var checker = _dbCheckers.FirstOrDefault(c =>
                         dbGroup.Key.Equals(c.DbType, StringComparison.OrdinalIgnoreCase));

                    result[$"{dbGroup.Key}.{conn.Key}"] = checker?.Check(connValue)
                        ?? new DatabaseStatus { Check = "Failed: No checker registered" };
                }
            }

            return result;
        }

        private async Task<Dictionary<string, ExternalServiceStatus>> CheckAllServiceAsync()
        {
            var result = new Dictionary<string, ExternalServiceStatus>();
            var externalServiceSections = _config.GetSection("ExternalServices").GetChildren();

            foreach (var externalService in externalServiceSections)
            {
                var checker = _externalChecker.FirstOrDefault(c =>
                         externalService.Key.Equals(c.ServiceType, StringComparison.OrdinalIgnoreCase));

                if (checker != null)
                {
                    result[externalService.Key] = await checker.CheckConnection();
                }
                else
                {
                    result[externalService.Key] = new ExternalServiceStatus
                    {
                        Check = "Failed: No checker registered",
                        SpendTime = "0ms"
                    };
                }
            }

            return result;
        }

        private string GetStartupMessage(
            Dictionary<string, DatabaseStatus> dbStatus,
            Dictionary<string, ExternalServiceStatus> externalStatus)
        {
            var assembly = Assembly.GetEntryAssembly();
            var version = assembly?
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion ?? "Unknown";

            var hasDbFailed = dbStatus.Values.Any(d => d.Check.StartsWith("Failed"));
            var hasExternalFailed = externalStatus?.Values.Any(d => d.Check.StartsWith("Failed")) ?? false;

            var startup = new StartupInfo
            {
                EnvironmentName = _env.EnvironmentName,
                ProjectName = assembly?.GetName().Name ?? "Unknown Project",
                StartupTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff"),
                Version = version,
                Listening = _config["Kestrel:Endpoints:Http:Url"] ?? "Unknown",
                DB = dbStatus,
                Status = (!hasDbFailed && !hasExternalFailed) ? "OK" : "Failed"
            };

            var statusSign = startup.Status == "OK" ? "✅" : "❌";

            var sb = new StringBuilder();
            sb.AppendLine($"{statusSign} {startup.ProjectName} startup test {startup.Status} {statusSign}")
              .AppendLine($"[{startup.EnvironmentName}][{startup.ProjectName}][Information]")
              .AppendLine("{")
              .AppendLine($"    Version: {startup.Version}")
              .AppendLine($"    StartupTime: {startup.StartupTime}")
              .AppendLine($"    Listening: {startup.Listening}")
              .AppendLine($"    DB:");
            foreach (var db in startup.DB)
            {
                sb.AppendLine($"       {db.Key}: {{ Check: {db.Value.Check}, SpendTime: {db.Value.SpendTime} }},");
            }
            sb.Length--; // remove last comma
            sb.AppendLine("    }");

            if (externalStatus != null)
            {
                sb.AppendLine($"    ExternalService:");
                foreach (var ext in externalStatus)
                {
                    sb.AppendLine($"       {ext.Key}: {{ Check: {ext.Value.Check}, SpendTime: {ext.Value.SpendTime} }},");
                }
                sb.Length--; // remove last comma
                sb.AppendLine("    }");
            }
            
            sb.AppendLine("}");

            return sb.ToString();
        }

        /// <summary>
        /// Checks if the application is listening correctly on the configured endpoint.
        /// </summary>
        private void CheckServiceAlive()
        {
            var url = _config["Kestrel:Endpoints:Http:Url"];
            CheckConnectivity(url ?? "http://localhost:5000");
        }

        /// <summary>
        /// Checks basic TCP connectivity to the application's configured host:port.
        /// </summary>
        private static void CheckConnectivity(string url)
        {
            var uri = new Uri(url);
            using var client = new TcpClient();
            string host = uri.Host == "0.0.0.0" ? "localhost" : uri.Host;
            client.Connect(host, uri.Port);
        }
    }
}