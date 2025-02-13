using RemoteConfig.Core.Entities;

namespace RemoteConfig.Application.Services
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAllAsync();
    }
}