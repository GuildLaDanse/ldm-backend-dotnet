using System.Collections.Generic;

namespace LaDanse.Common.Domain
{
    public interface IRepository<TKey, TEntity> where TEntity : BaseEntity<TKey>
    {
        TEntity GetById(TKey id);
        TEntity GetSingleBySpec(ISpecification<TEntity> spec);
        IEnumerable<TEntity> ListAll();
        IEnumerable<TEntity> ListBySpec(ISpecification<TEntity> spec);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}