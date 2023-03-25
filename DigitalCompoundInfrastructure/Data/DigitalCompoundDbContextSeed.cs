using System.Text.Json;
using DigitalCompoundCore.Entities;

namespace DigitalCompoundInfrastructure.Data;

public class DigitalCompoundDbContextSeed
{
    public static async Task SeedAsync(DigitalCompoundDbContext dbContext)
    {
        if (!dbContext.ProductBrands.Any())
        {
            var brandsData = File.ReadAllText("../DigitalCompoundInfrastructure/Data/SeedData/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            dbContext.ProductBrands.AddRange(brands);
        }

        if (!dbContext.ProductTypes.Any())
        {
            var typesData = File.ReadAllText("../DigitalCompoundInfrastructure/Data/SeedData/types.json");
            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
            dbContext.ProductTypes.AddRange(types);
        }

        if (!dbContext.Products.Any())
        {
            var productsData = File.ReadAllText("../DigitalCompoundInfrastructure/Data/SeedData/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            dbContext.Products.AddRange(products);
        }

        if (dbContext.ChangeTracker.HasChanges()) 
        {
            await dbContext.SaveChangesAsync();
        }
    }
}