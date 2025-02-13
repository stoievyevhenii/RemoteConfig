using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using RemoteConfig.DataAccess.Identity;

using WeightSaver.DataAccess.Identity;

namespace RemoteConfig.DataAccess.Persistence;

public static class AutomatedMigration
{
    public static async Task MigrateAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<DatabaseContext>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var configService = services.GetRequiredService<IConfiguration>();

        await context.Database.MigrateAsync();

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    }
}