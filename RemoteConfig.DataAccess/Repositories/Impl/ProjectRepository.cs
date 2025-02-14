using RemoteConfig.Core.Entities;
using RemoteConfig.DataAccess.Persistence;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RemoteConfig.Core.Exceptions;

namespace RemoteConfig.DataAccess.Repositories.Impl
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DatabaseContext context) : base(context)
        {
        }

        public new async Task<Project> GetFirstOrDefaultAsync(Expression<Func<Project, bool>> predicate)
        {
            return await DbSet
                .Where(predicate)
                .Include(x => x.Company)
                .FirstOrDefaultAsync() ?? throw new ResourceNotFoundException(typeof(Project));
        }
    }
}