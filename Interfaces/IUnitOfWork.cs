namespace Treasures.Common.Interfaces;

public interface IUnitOfWork : IDisposable {
    ISqlRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> Complete();
}