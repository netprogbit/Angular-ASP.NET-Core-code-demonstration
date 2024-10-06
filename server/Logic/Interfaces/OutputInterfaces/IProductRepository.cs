using Logic.Models.Entities;

namespace Logic.Interfaces.OutputInterfaces;

public interface IProductRepository : IEntityRepository<Product>
{
    Task<IEnumerable<Product>> FindByNameAsync(string name);
}
