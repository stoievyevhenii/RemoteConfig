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
            return Ok(ApiResult<bool>.Success(await _projectService.Delete(Guid.Parse(id))));
        }

        [HttpGet("{companyId}")]
        public async Task<IActionResult> Get(string companyId)
        {
            return Ok(ApiResult<IEnumerable<Project>>.Success(await _projectService.GetAllRecordsInCompanyAsync(Guid.Parse(companyId))));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProjectRequest createProjectRequest)
        {
            return Ok(ApiResult<Project>.Success(await _projectService.AddRecord(createProjectRequest)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, UpdateProjectRequest updateProject)
        {
            return Ok(ApiResult<Project>.Success(await _projectService.Update(Guid.Parse(id), updateProject: updateProject)));
        }
    }
}