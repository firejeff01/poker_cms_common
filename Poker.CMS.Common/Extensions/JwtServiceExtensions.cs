using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Poker.CMS.Common.AppSettings;
using System.Text;

namespace Poker.CMS.Common.Extensions
{
    public static class JwtServiceExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration cfg)
        {
            var jwt = cfg.GetSection("JwtSettings").Get<JwtSettings>();
            services.Configure<JwtSettings>(cfg.GetSection("JwtSettings"));

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.IncludeErrorDetails = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // 從 "sub" 取值並設定給 User.Identity.Name
                        NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                        // 從 "roles" 取值，並讓 [Authorize] 判斷角色
                        RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",

                        ValidateIssuer = true,
                        ValidIssuer = jwt.Issuer,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SignKey)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }
    }
}