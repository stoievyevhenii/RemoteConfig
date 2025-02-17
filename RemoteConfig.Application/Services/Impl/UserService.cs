using Microsoft.AspNetCore.Identity;
using RemoteConfig.Application.Helpers;
using RemoteConfig.Application.Models.User;
using RemoteConfig.Core.Exceptions;
using RemoteConfig.DataAccess.Identity;
using RemoteConfig.Shared.StaticValues;

namespace RemoteConfig.Application.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<CreateUserResponseModel> Register(CreateUserModel createUserModel)
        {
            var newUser = new ApplicationUser
            {
                FullName = createUserModel.FullName,
                UserName = createUserModel.Username,
                AccessToken = RandomDataCreator.GeneratePassword(64)
            };

            if (!await _roleManager.RoleExistsAsync(UserRole.User))
            {
                throw new BadRequestException("Role does not exist");
            }

            var userCreationResponse = await _userManager.CreateAsync(newUser, createUserModel.Password);

            if (!userCreationResponse.Succeeded)
            {
                throw new BadRequestException(userCreationResponse.Errors.First().Description);
            }

            if (string.IsNullOrEmpty(newUser.UserName))
            {
                throw new BadRequestException("Username is empty");
            }

            await _userManager.AddToRoleAsync(newUser, UserRole.User);

            return new()
            {
                Id = Guid.Parse(newUser.Id)
            };
        }
    }
}