using RemoteConfig.Application.Models.Company;
using RemoteConfig.Core.Entities;

namespace RemoteConfig.Application.Services
{
    public interface ICompanyService
    {
        Task<Company> AddAsync(CreateCompanyRequest createCompanyRequest);

        Task<bool> DeleteAsync(Guid companyId);

        Task<List<Company>> GetAllAsync();

        Task<Company> GetAsync(Guid id);

        Task<Company> GetAsync(string companyName);

        Task<Company> UpdateAsync(Guid id, UpdateCompanyRequest updateCompany);
    }
}