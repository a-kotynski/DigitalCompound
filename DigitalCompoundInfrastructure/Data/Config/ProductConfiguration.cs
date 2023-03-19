using DigitalCompoundCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalCompoundInfrastructure.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        builder.Property(p => p.PictureUrl).IsRequired();
        builder.HasOne(brand => brand.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
        builder.HasOne(type => type.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
    }
}
