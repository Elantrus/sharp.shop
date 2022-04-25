using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Entity;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasKey(product => product.Id);

        builder.Property(prop => prop.Description)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(prop => prop.SalePrice)
            .HasPrecision(2)
            .IsRequired();
        
        builder.Property(prop => prop.ProductCost)
            .HasPrecision(2)
            .IsRequired();

        builder.HasOne(product => product.Metric)
            .WithOne(metric => metric.Product)
            .HasForeignKey<Metric>(fr => fr.ProductForeignId);
    }
}