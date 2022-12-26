namespace Treasures.Common.Interfaces;

public interface ICacheService<T> {
    Task<T?> GetItem(string id);
    Task<T?> UpsertItem(string id, int timeSpan, T entity);
    Task<bool> DeleteItem(string id);
}