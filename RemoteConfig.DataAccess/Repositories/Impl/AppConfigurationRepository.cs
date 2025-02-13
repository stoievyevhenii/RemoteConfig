using RemoteConfig.Core.Entities;
using RemoteConfig.DataAccess.Persistence;

namespace RemoteConfig.DataAccess.Repositories.Impl
{
    public class AppConfigurationRepository : BaseRepository<AppConfiguration>, IAppConfigurationRepository
    {
        public AppConfigurationRepository(DatabaseContext context) : base(context)
        {
        }
    }
}