using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.Configuration.Entity;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(customer => customer.Id);
        
        builder.Property(customer => customer.Description).HasMaxLength(200);
        
        builder.Property(customer => customer.Description).HasMaxLength(20);
        
        builder.HasOne(review => review.Customer)
            .WithOne(customer => customer.Review)
            .HasForeignKey<Customer>(fr => fr.ReviewForeignId);
    }
}