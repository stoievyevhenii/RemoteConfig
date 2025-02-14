using RemoteConfig.Core.Entities;
using RemoteConfig.DataAccess.Persistence;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RemoteConfig.DataAccess.Repositories.Impl
{
    public class AppConfigurationRepository : BaseRepository<AppConfiguration>, IAppConfigurationRepository
    {
        public AppConfigurationRepository(DatabaseContext context) : base(context)
        {
        }

        public new async Task<List<AppConfiguration>> GetAsync(Expression<Func<AppConfiguration, bool>> predicate)
        {
            return await DbSet
                .Where(predicate)
                .Include(x => x.Project)
                .Include(r => r.Values)
                .ToListAsync();
        }

        public new async Task<AppConfiguration> GetFirstOrDefaultAsync(Expression<Func<AppConfiguration, bool>> predicate)
        {
            return await DbSet
                .Where(predicate)
                .Include(x => x.Project)
                .Include(r => r.Values)
                .FirstOrDefaultAsync();
        }
    }
}