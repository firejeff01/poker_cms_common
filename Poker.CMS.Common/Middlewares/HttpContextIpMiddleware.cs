using Microsoft.AspNetCore.Http;
using NLog;

namespace Poker.CMS.Common.Middlewares
{
    public class HttpContextIpMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpContextIpMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            // 單純把 IP 塞到 HttpContext.Items，暫存用
            context.Items["ClientIp"] = ip;

            // 存入 NLog MDLC
            using (ScopeContext.PushProperty("client-ip", ip))
            {
                await _next(context);
            }
        }
    }
}
