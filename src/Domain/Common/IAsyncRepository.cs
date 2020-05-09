using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaDanse.Domain.Common
{
    public interface IAsyncRepository<TKey, TEntity> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<List<TEntity>> ListAllAsync();
        Task<List<TEntity>> ListBySpecAsync(ISpecification<TEntity> spec);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}