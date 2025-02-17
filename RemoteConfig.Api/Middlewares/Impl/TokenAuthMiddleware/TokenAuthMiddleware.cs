using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RemoteConfig.DataAccess.Identity;

namespace RemoteConfig.Api.Middlewares.Impl.TokenAuthMiddleware
{
    public class TokenAuthMiddleware
    {
        private const string API_KEY_HEADER = "x-api-key";
        private readonly RequestDelegate _next;

        public TokenAuthMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            if (context.Request.Headers.TryGetValue(API_KEY_HEADER, out var extractedApiKey))
            {
                var user = await userManager.Users.FirstOrDefaultAsync(u => u.AccessToken == extractedApiKey.ToString());

                if (user != null)
                {
                    var identity = new ClaimsIdentity(
                    [
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.Role)
                    ],
                    CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);
                    _ = new AuthenticationTicket(principal, "ApiKey");

                    context.User = principal;

                    await signInManager.Context.SignInAsync(
                        IdentityConstants.ApplicationScheme, principal,
                        new AuthenticationProperties { IsPersistent = true }
                        );
                }
            }

            await _next(context);
        }
    }
}