using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Poker.CMS.Common.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Handling request: " + httpContext.Request.Method + " " + httpContext.Request.Path + System.Net.WebUtility.UrlDecode(httpContext.Request.QueryString.ToString()));
            _logger.LogInformation($"From IP {httpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty}");
            // Log request body if necessary
            httpContext.Request.EnableBuffering();
            var reader = new StreamReader(httpContext.Request.Body);
            var requestBody = await reader.ReadToEndAsync();
            httpContext.Request.Body.Position = 0;
            _logger.LogInformation("Request Body: " + requestBody);

            await _next(httpContext);

            _logger.LogInformation("Finished handling request.");
        }
    }

    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}