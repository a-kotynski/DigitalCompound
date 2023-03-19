using DigitalCompoundCore.Entities;
using DigitalCompoundCore.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DigitalCompoundInfrastructure.Data;

public class ProductRepository : IProductRepository
{
    private readonly DigitalCompoundDbContext _dbContext;
    public ProductRepository(DigitalCompoundDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        return product;
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        var products = await _dbContext.Products.ToListAsync();
        return products;
    }
}
