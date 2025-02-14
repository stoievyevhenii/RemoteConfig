using Microsoft.AspNetCore.Mvc;

using RemoteConfig.Application.Models.Company;
using RemoteConfig.Application.Models.Project;
using RemoteConfig.Application.Services;
using RemoteConfig.Core.Entities;
using RemoteConfig.Shared.Models;

namespace RemoteConfig.Api.Controllers
{
    public class ProjectsController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(ApiResult<bool>
                .Success(await _projectService.DeleteAsync(Guid.Parse(id))));
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetProjectRequest getProjectRequest)
        {
            return Ok(ApiResult<IEnumerable<Project>>
                .Success(await _projectService.GetAllRecordsInCompanyAsync(Guid.Parse(getProjectRequest.CompanyId))));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(ApiResult<Project>
                .Success(await _projectService.GetAsync(Guid.Parse(id))));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProjectRequest createProjectRequest)
        {
            return Ok(ApiResult<Project>
                .Success(await _projectService.AddAsync(createProjectRequest)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, UpdateProjectRequest updateProject)
        {
            return Ok(ApiResult<Project>
                .Success(await _projectService.UpdateAsync(Guid.Parse(id), updateProject)));
        }
    }
}