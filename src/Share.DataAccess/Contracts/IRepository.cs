using System.Linq.Expressions;
using Share.Domain.Commons;

namespace Share.DataAccess.Contracts;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    ValueTask CreateAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void Destroy(TEntity entity);
    ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>>? expression = null, string[]? includes = null);
    IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>>? expression = null, string[]? includes = null);
}