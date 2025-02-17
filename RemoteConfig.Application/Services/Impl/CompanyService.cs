using RemoteConfig.Application.Models.Company;
using RemoteConfig.Core.Entities;
using RemoteConfig.Core.Exceptions;
using RemoteConfig.DataAccess.Repositories;
using RemoteConfig.Shared.Services;

namespace RemoteConfig.Application.Services.Impl
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly string _userId;

        public CompanyService(ICompanyRepository companyRepository, IClaimService claimService)
        {
            _companyRepository = companyRepository;
            _userId = claimService.GetUserId();
        }

        public async Task<Company> AddAsync(CreateCompanyRequest createCompanyRequest)
        {
            var company = new Company
            {
                Name = createCompanyRequest.Name,
                Owner = new Guid(_userId),
                NormalizedName = createCompanyRequest.Name.ToUpper()
            };

            var anyExist = await _companyRepository
                .GetFirstOrDefaultAsync(x => x.NormalizedName == company.NormalizedName
                    && x.Owner == Guid.Parse(_userId)) != null;

            if (anyExist)
            {
                throw new DublicateRecordException("Company already exist");
            }

            return await _companyRepository.AddAsync(company);
        }

        public async Task<bool> DeleteAsync(Guid companyId)
        {
            var company = await _companyRepository
                .GetFirstOrDefaultAsync(x => x.Id == companyId)
                    ?? throw new RecordNotFoundException("Company not found");

            await _companyRepository.DeleteAsync(company);
            return true;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _companyRepository.GetAsync(r => r.Owner == Guid.Parse(_userId));
        }

        public async Task<Company> GetAsync(Guid id)
        {
            return await _companyRepository
                .GetFirstAsync(r => r.Id == id && r.Owner == Guid.Parse(_userId))
                    ?? throw new RecordNotFoundException("Company not found");
        }

        public async Task<Company> GetAsync(string companyName)
        {
            return await _companyRepository
                .GetFirstAsync(r => r.NormalizedName == companyName.ToUpper() && r.Owner == Guid.Parse(_userId))
                    ?? throw new RecordNotFoundException("Company not found");
        }

        public async Task<Company> UpdateAsync(Guid id, UpdateCompanyRequest updateCompany)
        {
            var record = await _companyRepository.GetFirstAsync(x => x.Id == id);

            if (record.NormalizedName == updateCompany.Name.ToUpper())
            {
                return record;
            }

            record.Name = updateCompany.Name;
            record.NormalizedName = updateCompany.Name.ToUpper();

            await _companyRepository.UpdateAsync(record);

            return record;
        }
    }
}