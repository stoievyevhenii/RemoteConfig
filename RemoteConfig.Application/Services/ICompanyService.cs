using RemoteConfig.Application.Models.Company;
using RemoteConfig.Core.Entities;

namespace RemoteConfig.Application.Services
{
    public interface ICompanyService
    {
        Task<Company> AddRecord(CreateCompanyRequest createCompanyRequest);

        Task<List<Company>> GetAllAsync();
    }
}