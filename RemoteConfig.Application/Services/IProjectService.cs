using RemoteConfig.Application.Models.Project;
using RemoteConfig.Core.Entities;

namespace RemoteConfig.Application.Services
{
    public interface IProjectService
    {
        Task<Project> AddRecord(CreateProjectRequest createProjectRequest);

        Task<bool> Delete(Guid projectId);

        Task<List<Project>> GetAllRecordsInCompanyAsync(Guid companyId);

        Task<Project> Update(Guid id, UpdateProjectRequest updateProject);
    }
}