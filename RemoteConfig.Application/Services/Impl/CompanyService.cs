using RemoteConfig.Application.Models.Company;
using RemoteConfig.Core.Entities;
using RemoteConfig.DataAccess.Repositories;

namespace RemoteConfig.Application.Services.Impl
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> AddRecord(CreateCompanyRequest createCompanyRequest)
        {
            var company = new Company
            {
                Name = createCompanyRequest.Name,
            };

            return await _companyRepository.AddAsync(company);
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _companyRepository.GetAllAsync();
        }
    }
}