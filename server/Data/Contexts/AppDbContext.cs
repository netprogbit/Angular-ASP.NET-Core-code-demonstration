using Logic.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>().HasData(
              new Product[]
              {
                new Product { Id=1, Name="Monitor", Description="M: 1201", Price=500000},
                new Product { Id=2, Name="Smartphone", Description="S: 1301", Price=300000},
                new Product { Id=3, Name="Tablet", Description="T: 1401", Price=400000},
              });        
    }
}
