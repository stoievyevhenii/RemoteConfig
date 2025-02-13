using Microsoft.AspNetCore.Mvc;

using RemoteConfig.Shared.Models.User;
using RemoteConfig.Shared.Models;
using RemoteConfig.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace RemoteConfig.Api.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            return Ok(ApiResult<LoginResponseModel>.Success(await _authService.LoginAsync(loginRequest)));
        }
    }
}