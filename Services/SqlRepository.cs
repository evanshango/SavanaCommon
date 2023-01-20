using Microsoft.EntityFrameworkCore;
using Treasures.Common.Helpers;
using Treasures.Common.Interfaces;

namespace Treasures.Common.Services;

public class SqlRepository<T> : ISqlRepository<T> where T : class {
    private readonly DbContext _context;

    public SqlRepository(DbContext context) => _context = context;

    public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
    
    public async Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T> sp) => await ApplySpecification(sp).ToListAsync();

    /// <summary>
    /// Returns random items based on the count and specification given
    /// </summary>
    /// <param name="spec"></param>
    /// <param name="count"></param>
    /// <returns><list type="T"></list></returns>
    public IReadOnlyList<T> GetRandomAsync(ISpecification<T> spec, int count) {
        return ApplySpecification(spec).AsEnumerable().OrderBy(_ => Guid.NewGuid()).Take(count).ToList();
    }

    /// <summary>
    /// Find By Id (string)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<T?> GetByIdAsync(string id) => await _context.Set<T>().FindAsync(id);

    /// <summary>
    /// Find By Id (int)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

    public async Task<T?> GetEntityWithSpec(ISpecification<T> sp) => await ApplySpecification(sp).FirstOrDefaultAsync();

    public async Task<PagedList<T>> GetPagedAsync(ISpecification<T> sp, int page, int size) => await PagedList<T>
        .ToPagedList(query: ApplySpecification(sp), pageNumber: page, pageSize: size);

    public async Task<int> CountAsync(ISpecification<T> spec) => await ApplySpecification(spec).CountAsync();

    public T AddAsync(T entity) => _context.Set<T>().Add(entity).Entity;

    public T UpdateAsync(T entity) {
        var res = _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return res.Entity;
    }

    public T DeleteAsync(T entity) => _context.Set<T>().Remove(entity).Entity;

    private IQueryable<T> ApplySpecification(ISpecification<T> spec) => SpecificationEvaluator<T>.GetQuery(
        _context.Set<T>().AsQueryable(), spec
    );
}