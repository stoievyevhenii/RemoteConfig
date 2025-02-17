using Microsoft.AspNetCore.Mvc;

using RemoteConfig.Application.Models.AppConfiguration;
using RemoteConfig.Application.Services;
using RemoteConfig.Core.Entities;
using RemoteConfig.Shared.Models;

namespace RemoteConfig.Api.Controllers
{
    public class AppConfigurationsController : BaseController
    {
        private readonly IAppConfigurationService _appConfigurationService;

        public AppConfigurationsController(IAppConfigurationService appConfigurationService)
        {
            _appConfigurationService = appConfigurationService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(ApiResult<bool>
                .Success(await _appConfigurationService.DeleteAsync(Guid.Parse(id))));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(ApiResult<AppConfigurationResponseDto>
                .Success(await _appConfigurationService.GetAsync(Guid.Parse(id))));
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetAppConfigurationRequest getAppConfigurationRequest)
        {
            return Ok(ApiResult<IEnumerable<AppConfigurationResponseDto>>
                .Success(await _appConfigurationService.GetAllRecordsInProjectAsync(Guid.Parse(getAppConfigurationRequest.ProjectId))));
        }

        [HttpGet("external")]
        public async Task<IActionResult> Get([FromQuery] AppConfigurationExternalRequest externalRequest)
        {
            return Ok(ApiResult<AppConfigurationExternalResponse>
                .Success(await _appConfigurationService.GetAsync(externalRequest)));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAppConfigurationRequest createAppConfigurationRequest)
        {
            return Ok(ApiResult<AppConfiguration>
                .Success(await _appConfigurationService.AddAsync(createAppConfigurationRequest)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, UpdateAppConfigurationRequest updateAppConfigurationRequest)
        {
            return Ok(ApiResult<AppConfiguration>
                .Success(await _appConfigurationService.UpdateAsync(Guid.Parse(id), updateAppConfigurationRequest)));
        }
    }
}