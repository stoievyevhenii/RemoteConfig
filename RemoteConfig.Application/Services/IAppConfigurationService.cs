using RemoteConfig.Application.Models.AppConfiguration;
using RemoteConfig.Application.Models.Project;
using RemoteConfig.Core.Entities;

namespace RemoteConfig.Application.Services
{
    public interface IAppConfigurationService
    {
        Task<AppConfiguration> AddAsync(CreateAppConfigurationRequest createAppConfigurationRequest);

        Task<bool> DeleteAsync(Guid projectId);

        Task<List<AppConfigurationResponseDto>> GetAllRecordsInProjectAsync(Guid companyId);

        Task<AppConfigurationResponseDto> GetAsync(Guid appConfigurationGuid);

        Task<AppConfiguration> UpdateAsync(Guid id, UpdateAppConfigurationRequest updateAppConfigurationRequest);
    }
}