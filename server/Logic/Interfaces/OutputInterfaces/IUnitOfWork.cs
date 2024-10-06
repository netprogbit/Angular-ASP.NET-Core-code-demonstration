namespace Logic.Interfaces.OutputInterfaces;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }

    void BeginTransaction();
    void Commit();
    void Dispose();
    void Rollback();
    Task SaveAsync();
}
