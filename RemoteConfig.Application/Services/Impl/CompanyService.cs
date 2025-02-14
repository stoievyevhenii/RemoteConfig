using RemoteConfig.Application.Models.Company;
using RemoteConfig.Core.Entities;
using RemoteConfig.Core.Exceptions;
using RemoteConfig.DataAccess.Repositories;
using RemoteConfig.Shared.Services;

namespace RemoteConfig.Application.Services.Impl
{
    public class CompanyService : ICompanyService
    {
        private readonly IClaimService _claimService;
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository, IClaimService claimService)
        {
            _claimService = claimService;
            _companyRepository = companyRepository;
        }

        public async Task<Company> AddRecord(CreateCompanyRequest createCompanyRequest)
        {
            var userId = _claimService.GetUserId();

            var company = new Company
            {
                Name = createCompanyRequest.Name,
                Owner = new Guid(userId),
                NormalizedName = createCompanyRequest.Name.ToUpper()
            };

            var anyExist = await _companyRepository
                .GetFirstOrDefaultAsync(x => x.NormalizedName == company.NormalizedName
                    && x.Owner == Guid.Parse(userId));

            if (anyExist is not null)
            {
                throw new DublicateRecordException("Company already exist");
            }

            return await _companyRepository.AddAsync(company);
        }

        public async Task<bool> Delete(Guid companyId)
        {
            var company = await _companyRepository
                .GetFirstOrDefaultAsync(x => x.Id == companyId)
                    ?? throw new RecordNotFoundException("Company not found");

            await _companyRepository.DeleteAsync(company);
            return true;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<Company> Update(Guid id, UpdateCompanyRequest updateCompany)
        {
            var record = await _companyRepository.GetFirstOrDefaultAsync(x => x.Id == id)
                ?? throw new RecordNotFoundException("Company not found");

            if (record.Name != updateCompany.Name)
            {
                record.Name = updateCompany.Name;
                record.NormalizedName = updateCompany.Name.ToUpper();
            }

            await _companyRepository.UpdateAsync(record);

            return record;
        }
    }
}