using DigitalCompoundCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalCompoundInfrastructure.Data;

public class DigitalCompoundDbContext : DbContext
{
    public DigitalCompoundDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; } // new table
    public DbSet<ProductType> ProductTypes { get; set; } // new table
}