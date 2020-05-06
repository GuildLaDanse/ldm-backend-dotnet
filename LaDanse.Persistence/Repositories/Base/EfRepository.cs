using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaDanse.Common.Domain;
using LaDanse.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Hermes.Persistence.Repositories.Base
{
    /// <summary>
    /// "There's some repetition here - couldn't we have some the sync methods call the async?"
    /// https://blogs.msdn.microsoft.com/pfxteam/2012/04/13/should-i-expose-synchronous-wrappers-for-asynchronous-methods/
    /// </summary>
    public class EfRepository<TKey, TEntity> : IRepository<TKey, TEntity>, IAsyncRepository<TKey, TEntity> where TEntity : BaseEntity<TKey>
    {
        protected readonly LaDanseDbContext DbContext;

        public EfRepository(LaDanseDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual TEntity GetById(TKey id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public TEntity GetSingleBySpec(ISpecification<TEntity> spec)
        {
            return ListBySpec(spec).FirstOrDefault();
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> ListAll()
        {
            return DbContext.Set<TEntity>().AsEnumerable();
        }

        public async Task<List<TEntity>> ListAllAsync()
        {
            return await DbContext.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> ListBySpec(ISpecification<TEntity> spec)
        {
            return _InternalListBySpec(spec).AsEnumerable();
        }
        public async Task<List<TEntity>> ListBySpecAsync(ISpecification<TEntity> spec)
        {
            return await _InternalListBySpec(spec).ToListAsync();
        }

        private IQueryable<TEntity> _InternalListBySpec(ISpecification<TEntity> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(DbContext.Set<TEntity>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the query using the specification's criteria expression
            return secondaryResult.Where(spec.Criteria);
        }

        public TEntity Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();

            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public void Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public void Remove(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();
        }
        public async Task DeleteAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}