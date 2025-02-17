using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemoteConfig.Application.Models.User;
using RemoteConfig.Application.Services;

namespace RemoteConfig.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(CreateUserModel createUserModel)
        {
            var response = await _userService.Register(createUserModel);
            return Ok(response);
        }
    }
}