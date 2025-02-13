using RemoteConfig.Shared.Models.User;

namespace RemoteConfig.Application.Services
{
    public interface IAuthService
    {
        Task<LoginResponseModel> LoginAsync(LoginRequest loginUserModel);
    }
}