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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(ApiResult<IEnumerable<Company>>.Success(await _companyService.GetAllAsync()));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCompanyRequest createCompanyRequest)
        {
            return Ok(ApiResult<Company>.Success(await _companyService.AddRecord(createCompanyRequest)));
        }
    }
}