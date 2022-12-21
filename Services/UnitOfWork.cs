using System.Collections;
using Microsoft.EntityFrameworkCore;
using Treasures.Common.Interfaces;

namespace Treasures.Common.Services;

public class UnitOfWork : IUnitOfWork {
    private readonly DbContext _context;
    private Hashtable? _repositories;

    public UnitOfWork(DbContext context) => _context = context;

    public ISqlRepository<TEntity> Repository<TEntity>() where TEntity : class {
        _repositories ??= new Hashtable();
        var type = typeof(TEntity).Name;

        if (_repositories.ContainsKey(type)) return (ISqlRepository<TEntity>)_repositories[type]!;

        var repositoryType = typeof(SqlRepository<>);
        var repoInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
        _repositories.Add(type, repoInstance);

        return (ISqlRepository<TEntity>)_repositories[type]!;
    }

    public async Task<int> Complete() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}