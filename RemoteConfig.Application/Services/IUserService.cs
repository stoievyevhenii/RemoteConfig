using RemoteConfig.Application.Models.User;
using RemoteConfig.DataAccess.Identity;

namespace RemoteConfig.Application.Services
{
    public interface IUserService
    {
        Task<CreateUserResponseModel> Register(CreateUserModel createUserModel);
    }
}