using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Entity;

public class MetricsConfiguration : IEntityTypeConfiguration<Metric>
{
    public void Configure(EntityTypeBuilder<Metric> builder)
    {
        builder
            .HasKey(product => product.Id);

        builder.Property(prop => prop.Score).IsRequired();
        
        builder.Property(prop => prop.GrossValue).IsRequired();

        builder.Property(prop => prop.NetValue).IsRequired();
        
        builder.Property(prop => prop.TotalSales).IsRequired();
        
        
    }
}