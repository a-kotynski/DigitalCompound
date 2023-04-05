using System.Runtime.CompilerServices;
using DigitalCompoundCore.Entities;
using DigitalCompoundCore.Intefaces;
using DigitalCompoundCore.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalCompoundInfrastructure.Data;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DigitalCompoundDbContext _dbContext;
    public GenericRepository(DigitalCompoundDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var single = await _dbContext.Set<T>().FindAsync(id);
        return single;
    }
    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        var all = await _dbContext.Set<T>().ToListAsync();
        return all;
    }

    public async Task<T> GetEntityWithSpecification(ISpecification<T> specification)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync();
    }
    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
    {
        return await ApplySpecification(specification).ToListAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> specification)
    {
        var apply = SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), specification);
        return apply;
    }
}
