using DigitalCompoundCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalCompoundInfrastructure.Data;

public class DigitalCompoundDbContext : DbContext
{
    public DigitalCompoundDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
}