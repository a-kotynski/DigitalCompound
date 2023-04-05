using System.Linq.Expressions;

namespace DigitalCompoundCore.Specifications;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria {get; }
    List<Expression<Func<T, object>>> Includes {get; }
}
