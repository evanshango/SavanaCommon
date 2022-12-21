using Microsoft.EntityFrameworkCore;
using Treasures.Common.Interfaces;

namespace Treasures.Common.Services;

public class SpecificationEvaluator<TEntity> where TEntity : class {
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec) {
        var query = inputQuery;

        if (spec.Criteria != null) query = query.Where(spec.Criteria);

        if (spec.OrderByAsc != null) query = query.OrderBy(spec.OrderByAsc);

        if (spec.OrderByDesc != null) query = query.OrderByDescending(spec.OrderByDesc);

        if (spec.GroupBy != null) query = query.GroupBy(spec.GroupBy).SelectMany(x => x);

        query = spec.Includes.Aggregate(query, (curr, inc) => curr.Include(inc));

        // Include any string-based include statements
        query = spec.IncludeStrings.Aggregate(query, (curr, inc) => curr.Include(inc));

        return query;
    }
}