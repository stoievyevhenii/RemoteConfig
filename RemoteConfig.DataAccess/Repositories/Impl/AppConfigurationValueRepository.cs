using RemoteConfig.Core.Entities;
using RemoteConfig.DataAccess.Persistence;

namespace RemoteConfig.DataAccess.Repositories.Impl
{
    public class AppConfigurationValueRepository : BaseRepository<AppConfigurationValue>, IAppConfigurationValueRepository
    {
        public AppConfigurationValueRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<bool> DeleteRangeAsync(List<AppConfigurationValue> entities)
        {
            DbSet.RemoveRange(entities);
            await Context.SaveChangesAsync();

            return true;
        }
    }
}