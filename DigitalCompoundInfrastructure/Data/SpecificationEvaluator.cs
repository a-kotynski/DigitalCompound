using DigitalCompoundCore.Entities;
using DigitalCompoundCore.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DigitalCompoundInfrastructure.Data;

public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
    {
        var query = inputQuery;
        
        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }

        query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
        return query;
    }
}
