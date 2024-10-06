using Logic.Models.Entities;
using System.Linq.Expressions;

namespace Logic.Interfaces;

public interface IEntityRepository<TModel> where TModel : class, IEntity
{
    Task AddAsync(TModel model);
    Task AddRangeAsync(IEnumerable<TModel> models);
    Task DeleteAsync(int id);
    Task<IEnumerable<TModel>> FindAllAsync();
    Task<IEnumerable<TModel>> FindAllAsync(Expression<Func<TModel, bool>> predicate);
    Task<TModel> FindByIdAsync(int id);
    void Update(TModel model);
    void UpdateRange(IEnumerable<TModel> models);
}