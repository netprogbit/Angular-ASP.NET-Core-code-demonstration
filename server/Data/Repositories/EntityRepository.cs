using Data.Contexts;
using Logic.Interfaces;
using Logic.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity
{    
    private readonly DbSet<TEntity> _dbSet;

    protected readonly AppDbContext _dbContext;

    public EntityRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> FindAllAsync()
    {
        return await _dbSet.AsNoTracking().OrderBy(e => e.Id).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<TEntity> FindByIdAsync(int id)
    {
        return await _dbSet.SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddAsync(TEntity model)
    {
        await _dbSet.AddAsync(model);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> models)
    {
        await _dbSet.AddRangeAsync(models);
    }

    public void Update(TEntity model)
    {
        _dbSet.Update(model);
    }

    public void UpdateRange(IEnumerable<TEntity> models)
    {
        _dbSet.UpdateRange(models);
    }

    public async Task DeleteAsync(int id)
    {
        await _dbSet.Where(e => e.Id == id).ExecuteDeleteAsync();
    }
}
