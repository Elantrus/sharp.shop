using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.Configuration.Entity;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(customer => customer.Id);
        
        builder.Property(customer => customer.Id).HasValueGenerator<SequentialGuidValueGenerator>();
        
        builder.HasOne(customer => customer.Review)
            .WithOne(review => review.Customer);
    }
}