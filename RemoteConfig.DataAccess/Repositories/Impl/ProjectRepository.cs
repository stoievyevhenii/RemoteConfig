using RemoteConfig.Core.Entities;
using RemoteConfig.DataAccess.Persistence;

namespace RemoteConfig.DataAccess.Repositories.Impl
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DatabaseContext context) : base(context)
        {
        }
    }
}