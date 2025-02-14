using RemoteConfig.Application.Models.Project;
using RemoteConfig.Core.Entities;

namespace RemoteConfig.Application.Services
{
    public interface IProjectService
    {
        Task<Project> AddAsync(CreateProjectRequest createProjectRequest);

        Task<bool> DeleteAsync(Guid projectId);

        Task<List<Project>> GetAllRecordsInCompanyAsync(Guid companyId);

        Task<Project> GetAsync(Guid projectId);

        Task<Project> UpdateAsync(Guid id, UpdateProjectRequest updateProject);
    }
}