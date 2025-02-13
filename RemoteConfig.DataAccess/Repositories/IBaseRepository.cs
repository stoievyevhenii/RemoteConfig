using RemoteConfig.Core.Common;

using System.Linq.Expressions;

namespace RemoteConfig.DataAccess.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);

        Task<List<TEntity>> GetAllAsync();

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities);
    }
}