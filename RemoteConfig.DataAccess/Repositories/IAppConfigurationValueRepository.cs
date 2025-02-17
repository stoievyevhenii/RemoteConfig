using RemoteConfig.Core.Entities;

namespace RemoteConfig.DataAccess.Repositories
{
    public interface IAppConfigurationValueRepository : IBaseRepository<AppConfigurationValue>
    {
        Task<bool> DeleteRangeAsync(List<AppConfigurationValue> entities);
    }
}