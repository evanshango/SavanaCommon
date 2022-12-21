using Microsoft.EntityFrameworkCore;

namespace Treasures.Common.Helpers;

public class PagedList<T> : List<T> {
    public MetaData MetaData { get; set; }

    private PagedList(IEnumerable<T> items, int count, int pageNo, int pageSize) {
        MetaData = new MetaData {
            TotalCount = count, PageSize = pageSize, PageNo = pageNo,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };
        AddRange(items);
    }

    public static async Task<PagedList<T>> ToPagedList(IQueryable<T> query, int pageNumber, int pageSize) {
        var count = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}