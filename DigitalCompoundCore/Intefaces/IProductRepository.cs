using DigitalCompoundCore.Entities;

namespace DigitalCompoundCore.Intefaces;

public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(int id);
    Task<IReadOnlyList<Product>> GetProductsAsync();
}
