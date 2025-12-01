using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Poker.CMS.Common.Middlewares;

namespace Poker.CMS.Common.Extensions
{
    public static class ClientIpExtensions
    {
        /// <summary>
        /// 註冊 Client IP Middleware
        /// </summary>
        public static IApplicationBuilder UseClientIpLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HttpContextIpMiddleware>();
        }

        /// <summary>
        /// 取得當前請求的 Client IP
        /// </summary>
        public static string? GetClientIp(this HttpContext context)
        {
            return context.Items.TryGetValue("ClientIp", out var ip) ? ip?.ToString() : null;
        }
    }
}
