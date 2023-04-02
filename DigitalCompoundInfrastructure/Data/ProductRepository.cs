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
    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        var products = await _dbContext
            .Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();

        return products;
    }
    public async Task<Product> GetProductByIdAsync(int id)
    {
        var product = await _dbContext
            .Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .SingleOrDefaultAsync(p => p.Id == id);

        return product;
    }

    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
        var productBrands = await _dbContext.ProductBrands.ToListAsync();
        return productBrands;
    }
    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
        var productTypes = await _dbContext.ProductTypes.ToListAsync();
        return productTypes;
    }
}
