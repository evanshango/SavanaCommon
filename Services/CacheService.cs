using System.Text.Json;
using StackExchange.Redis;
using Treasures.Common.Interfaces;

namespace Treasures.Common.Services;

public class CacheService<T> : ICacheService<T> where T : class {
    private readonly IDatabase _database;

    public CacheService(IConnectionMultiplexer redis) => _database = redis.GetDatabase();

    public async Task<T?> GetItem(string id) {
        var data = await _database.StringGetAsync(key: id);
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        return !data.IsNullOrEmpty ? JsonSerializer.Deserialize<T>(json: $"{data}", options) : null;
    }

    public async Task<T?> UpsertItem(string id, int timeSpan, T entity) {
        var created = await _database.StringSetAsync(
            key: id, value: JsonSerializer.Serialize(entity), expiry: TimeSpan.FromDays(timeSpan)
        );
        return !created ? null : await GetItem(id);
    }

    public async Task<bool> DeleteItem(string id) => await _database.KeyDeleteAsync(key: id);
}