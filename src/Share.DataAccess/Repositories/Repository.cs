using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Share.DataAccess.Contexts;
using Share.DataAccess.Contracts;
using Share.Domain.Commons;

namespace Share.DataAccess.Repositories;

public class Repository<TEntity>: IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async ValueTask CreateAsync(TEntity entity)
    {
        entity.CreatedAt = DateTimeOffset.UtcNow;
        await _dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        entity.IsDeleted = true;
    }

    public void Destroy(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>>? expression = null, string[]? includes = null)
    {
        var entities = 
            expression == null ? _dbSet.AsQueryable() :  _dbSet.Where(expression).AsQueryable();
        
        if(includes != null)
            entities = includes.Aggregate(entities, (current, include) => current.Include(include));

        var result = await entities.FirstOrDefaultAsync();
        return result;
    }

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>>? expression = null, string[]? includes = null)
    {
        var entities = 
            expression == null ? _dbSet.AsQueryable() :  _dbSet.Where(expression).AsQueryable();
        
        if(includes != null)
            entities = includes.Aggregate(entities, (current, include) => current.Include(include));

        return entities;
    }
}