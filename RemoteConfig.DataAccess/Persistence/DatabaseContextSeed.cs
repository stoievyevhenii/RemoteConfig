using Microsoft.AspNetCore.Identity;

using RemoteConfig.DataAccess.Identity;
using RemoteConfig.Shared.StaticValues;

namespace RemoteConfig.DataAccess.Persistence
{
    public static class DatabaseContextSeed
    {
        public static async Task SeedUsersAsync(DatabaseContext context, UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    Role = UserRole.Admin,
                    FullName = "Standart Administrator"
                };

                await userManager.CreateAsync(user, "Admin123.?");
            }

            await context.SaveChangesAsync();
        }
    }
}