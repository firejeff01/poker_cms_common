using Microsoft.Extensions.DependencyInjection;
using Poker.CMS.Assistant.Api.Startup;

namespace Poker.CMS.Common.Startup.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStartupHealthCheck(this IServiceCollection services)
        {
            services.AddHostedService<StartupService>();
            return services;
        }
    }
}
