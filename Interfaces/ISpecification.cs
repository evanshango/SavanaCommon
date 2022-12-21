using System.Linq.Expressions;

namespace Treasures.Common.Interfaces;

public interface ISpecification<T> {
    Expression<Func<T, bool>>? Criteria { get; } //Where criteria
    List<Expression<Func<T, object>>> Includes { get; } //List of include statements
    List<string> IncludeStrings { get; }
    Expression<Func<T, object>>? OrderByAsc { get; }
    Expression<Func<T, object>>? OrderByDesc { get; }
    Expression<Func<T, object>>? GroupBy { get; }
}