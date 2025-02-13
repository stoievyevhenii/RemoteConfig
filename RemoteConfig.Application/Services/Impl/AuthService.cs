using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using RemoteConfig.Application.Helpers;
using RemoteConfig.Core.Exceptions;
using RemoteConfig.DataAccess.Identity;
using RemoteConfig.Shared.Models.User;

namespace RemoteConfig.Application.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<LoginResponseModel> LoginAsync(LoginRequest loginUserModel)
        {
            var user = await _userManager.Users
             .FirstOrDefaultAsync(u => u.UserName == loginUserModel.Username)
                ?? throw new NotFoundException("Username or password is incorrect");

            var signInResult = await _signInManager
                .PasswordSignInAsync(user, loginUserModel.Password, false, false);

            if (!signInResult.Succeeded)
                throw new BadRequestException("Username or password is incorrect");

            return new LoginResponseModel
            {
                Username = user.UserName,
                Token = JwtHelper.GenerateToken(user, _configuration),
                UserType = user.Role,
                Fullname = user.FullName
            };
        }
    }
}