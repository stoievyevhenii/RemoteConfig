using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using RemoteConfig.Application.Services;
using RemoteConfig.Application.Services.Impl;
using RemoteConfig.Shared.Services;
using RemoteConfig.Shared.Services.Impl;

namespace RemoteConfig.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IWebHostEnvironment env,
        IConfiguration configuration)
        {
            services.AddServices();
            return services;
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICompanyService, CompanyService>();
        }
    }
}