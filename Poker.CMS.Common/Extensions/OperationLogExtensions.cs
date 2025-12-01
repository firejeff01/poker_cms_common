using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Poker.CMS.Common.Middlewares;
using Poker.CMS.Common.OperationLog;

namespace Poker.CMS.Common.Extensions
{
    public static class OperationLogExtensions
    {
        public static IServiceCollection AddOperationLogging(this IServiceCollection services)
        {
            services.AddScoped<IOperationContext, OperationContext>();
            services.AddSingleton<OperationLogMiddleware>();
            return services;
        }

        public static IApplicationBuilder UseOperationLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<OperationLogMiddleware>();
        }
    }

}
