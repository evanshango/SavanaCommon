using System.Linq.Expressions;
using Treasures.Common.Interfaces;

namespace Treasures.Common.Services;

public class SpecificationService<T> : ISpecification<T> {
    public Expression<Func<T, bool>>? Criteria { get; }
    public List<Expression<Func<T, object>>> Includes { get; } = new();
    public List<string> IncludeStrings { get; } = new();
    public Expression<Func<T, object>>? OrderByAsc { get; private set; }
    public Expression<Func<T, object>>? OrderByDesc { get; private set; }
    public Expression<Func<T, object>>? GroupBy { get; private set; }

    public SpecificationService() { }

    public SpecificationService(Expression<Func<T, bool>> criteria) => Criteria = criteria;

    protected void AddInclude(Expression<Func<T, object>> includeExpression) => Includes.Add(includeExpression);

    protected void AddInclude(string includeString) => IncludeStrings.Add(includeString);

    protected void AddOrderByAsc(Expression<Func<T, object>> orderByAsc) => OrderByAsc = orderByAsc;

    protected void AddOrderByDesc(Expression<Func<T, object>> orderByDesc) => OrderByDesc = orderByDesc;

    protected void ApplyGroupBy(Expression<Func<T, object>> groupBy) => GroupBy = groupBy;
}