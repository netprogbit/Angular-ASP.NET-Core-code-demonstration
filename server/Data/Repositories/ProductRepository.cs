using Data.Contexts;
using Logic.Interfaces.OutputInterfaces;
using Logic.Models.Entities;

namespace Data.Repositories;

public class ProductRepository : EntityRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext dbContext)
        : base(dbContext)
    { }

    public async Task<IEnumerable<Product>> FindByNameAsync(string name)
    {
        return await FindAllAsync(p => p.Name == name);
    }
}
