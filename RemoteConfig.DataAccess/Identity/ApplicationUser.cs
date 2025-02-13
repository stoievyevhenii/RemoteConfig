using Microsoft.AspNetCore.Identity;

using RemoteConfig.Shared.StaticValues;

namespace RemoteConfig.DataAccess.Identity;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
    public string Role { get; set; } = UserRole.User;
}