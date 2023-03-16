using DigitalCompoundAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalCompoundAPI.Data;

public class DigitalCompoundDbContext : DbContext
{
    public DigitalCompoundDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
}