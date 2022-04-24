using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class DatabaseSeed
{
    // Since its a single product, we can seed the DB. But doing this via API using a Admin Panel
    // seems better
    public static void SeedProduct(this ShopDbContext dbContext)
    {
        var latestProduct = dbContext
            .Products
            .Include(product => product.Metric)
            .OrderByDescending(product => product.Id)
            .FirstOrDefault();
        
        if (latestProduct == null)
        {
            dbContext.Products.Add(new Product
            {
                Description = "Action Figure - Naruto",
                SalePrice = 12.99d,
                Metric = new Metric
                {
                    Score = 5,
                    GrossValue = 0,
                    NetValue = 0,
                    TotalSales = 0
                }
            });
        }
        else
        {
            if (latestProduct.SalePrice != 12.99)
                latestProduct.SalePrice = 12.99;

            if (!latestProduct.Description.Equals("Action Figure - Naruto"))
                latestProduct.Description = "Action Figure - Naruto";

            if (latestProduct.Metric == null)
            {
                latestProduct.Metric = new Metric
                {
                    Score = 5,
                    GrossValue = 0,
                    NetValue = 0,
                    TotalSales = 0
                };
            }
        }
        
        dbContext.SaveChanges();
    }
    
}