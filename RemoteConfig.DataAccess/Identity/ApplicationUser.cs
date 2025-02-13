using Microsoft.AspNetCore.Identity;

namespace RemoteConfig.DataAccess.Identity;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
}