using DigitalCompoundCore.Entities;
using DigitalCompoundCore.Intefaces;
using Microsoft.EntityFrameworkCore;

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
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
}
