using RemoteConfig.Core.Entities;
using RemoteConfig.DataAccess.Persistence;

namespace RemoteConfig.DataAccess.Repositories.Impl
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(DatabaseContext context) : base(context)
        {
        }
    }
}