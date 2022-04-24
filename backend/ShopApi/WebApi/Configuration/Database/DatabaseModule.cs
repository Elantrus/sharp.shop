using Core.Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static class DatabaseModule
{
    public static void MigrateAndSeed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetService<ShopDbContext>();

            if (dbContext == null) throw new NullReferenceException();
            
            dbContext.Database.Migrate();
            dbContext.SeedProduct();
        }
    }
}