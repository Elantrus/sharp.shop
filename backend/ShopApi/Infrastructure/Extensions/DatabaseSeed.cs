using Core.Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Extensions;

public static class DatabaseSeed
{
    // Since its a single product, we can seed the DB. But doing this via API using a Admin Panel
    // seems better
    public static void SeedProduct(this ShopDbContext dbContext)
    {
        if (!dbContext.Products.Any())
        {
            dbContext.Products.Add(new Product
            {
                Description = "Action Figure - Naruto"
            });
            dbContext.SaveChanges();
        }
    }
}