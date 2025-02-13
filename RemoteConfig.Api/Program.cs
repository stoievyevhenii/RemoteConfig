using RemoteConfig.Api;
using RemoteConfig.Api.CachePolicy;
using RemoteConfig.Api.Middlewares.Impl.CacheEvict;
using RemoteConfig.Api.Middlewares.Impl.ExceptionHandling;
using RemoteConfig.Application;
using RemoteConfig.DataAccess;
using RemoteConfig.DataAccess.Persistence;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services
    .AddApplication(builder.Environment, builder.Configuration)
    .AddDataAccess(builder.Configuration);

builder.Services.AddJwt(builder.Configuration);

builder.Services
    .AddOutputCache(options => options
    .AddPolicy("DefaultCache", policy => policy.AddPolicy<DefaultCachePolicy>()
    .Tag("DefaultCachePolicy_Tag")));

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

using var scope = app.Services.CreateScope();
await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

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

await app.RunAsync();

namespace RemoteConfig.Api
{
    public partial class Program
    { }
}