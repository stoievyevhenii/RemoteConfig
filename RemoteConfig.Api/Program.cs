using RemoteConfig.Api.CachePolicy;
using RemoteConfig.Api.Middlewares.Impl.CacheEvict;
using RemoteConfig.Api.Middlewares.Impl.ExceptionHandling;

using Scalar.AspNetCore;

namespace RemoteConfig.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddOpenApi();

            builder.Services.AddJwt(builder.Configuration);

            builder.Services
                .AddOutputCache(options => options
                .AddPolicy("DefaultCache", policy => policy.AddPolicy<DefaultCachePolicy>()
                .Tag("DefaultCachePolicy_Tag")));

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseCacheEvict();

            app.UseExceptionHandling();

            app.UseCors(corsPolicyBuilder => corsPolicyBuilder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}