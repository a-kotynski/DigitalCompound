using DigitalCompoundCore.Entities;
using DigitalCompoundCore.Intefaces;

namespace DigitalCompoundInfrastructure.Data;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    public Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> ListAllAsync()
    {
        throw new NotImplementedException();
    }
}
