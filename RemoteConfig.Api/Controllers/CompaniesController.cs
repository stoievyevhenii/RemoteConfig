using Microsoft.AspNetCore.Mvc;

using RemoteConfig.Application.Models.Company;
using RemoteConfig.Application.Services;
using RemoteConfig.Core.Entities;
using RemoteConfig.Shared.Models;

namespace RemoteConfig.Api.Controllers
{
    public class CompaniesController : BaseController
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(ApiResult<bool>.Success(await _companyService.DeleteAsync(Guid.Parse(id))));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(ApiResult<IEnumerable<Company>>.Success(await _companyService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(ApiResult<Company>.Success(await _companyService.GetAsync(Guid.Parse(id))));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCompanyRequest createCompanyRequest)
        {
            return Ok(ApiResult<Company>.Success(await _companyService.AddAsync(createCompanyRequest)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, UpdateCompanyRequest updateCompany)
        {
            return Ok(ApiResult<Company>.Success(await _companyService.UpdateAsync(Guid.Parse(id), updateCompany)));
        }
    }
}