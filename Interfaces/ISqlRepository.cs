using Treasures.Common.Helpers;

namespace Treasures.Common.Interfaces;

public interface ISqlRepository<T> where T : class {
    Task<IReadOnlyList<T>> GetAllAsync();
    IReadOnlyList<T> GetRandomAsync(ISpecification<T> spec, int count);
    Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T> spec);
    Task<T?> GetByIdAsync(string id);
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetEntityWithSpec(ISpecification<T> spec);
    Task<PagedList<T>> GetPagedAsync(ISpecification<T> spec, int page, int size);
    Task<int> CountAsync(ISpecification<T> spec);
    T AddAsync(T entity);
    T UpdateAsync(T entity);
    T DeleteAsync(T entity);
}