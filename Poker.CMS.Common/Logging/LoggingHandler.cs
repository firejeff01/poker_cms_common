using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Poker.CMS.Common.Logging
{
    public class LoggingHandler : DelegatingHandler
    {
        private readonly ILogger<LoggingHandler> _logger;

        public LoggingHandler(ILogger<LoggingHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // 記錄 Request
            _logger.LogInformation("[http]Sending request: {Method} {Url}", request.Method, request.RequestUri);

            if (request.Content != null)
            {
                var requestContent = await request.Content.ReadAsStringAsync();
                _logger.LogInformation("[http]Request Content: {Content}", requestContent);
            }

            var stopwatch = Stopwatch.StartNew();
            var response = await base.SendAsync(request, cancellationToken);
            stopwatch.Stop();

            // 記錄 Response
            _logger.LogInformation("[http]Received response: {StatusCode} in {ElapsedMilliseconds} ms", response.StatusCode, stopwatch.ElapsedMilliseconds);

            if (response.Content != null)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("[http]Response Content: {Content}", responseContent);
            }

            return response;
        }
    }
}

