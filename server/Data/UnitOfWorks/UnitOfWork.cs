using Microsoft.EntityFrameworkCore.Storage;
using Data.Repositories;
using Data.Contexts;
using Logic.Interfaces.OutputInterfaces;

namespace Data.UnitOfWorks;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    protected readonly AppDbContext _dbContext;
    private IDbContextTransaction _transaction;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        ProductRepository = new ProductRepository(dbContext);
    }

    public IProductRepository ProductRepository { get; private set; }

    public void BeginTransaction()
    {
        _transaction = _dbContext.Database.BeginTransaction();
    }

    public void Commit()
    {
        _transaction.Commit();
    }

    public void Rollback()
    {
        _transaction.Rollback();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            _dbContext.Dispose();
            _transaction?.Dispose();
        }

        _disposed = true;
    }
}
