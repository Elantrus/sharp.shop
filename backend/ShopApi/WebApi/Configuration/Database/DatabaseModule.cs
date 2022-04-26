using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Configuration.Database;

public static class DatabaseModule
{
    public static void MigrateAndSeed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetService<ShopDbContext>();

            if (dbContext == null) throw new NullReferenceException();
            
            if(!app.Environment.IsDevelopment())
                dbContext.Database.Migrate();
            
            dbContext.SeedProduct();
        }
    }
    
    public static void AddDatabase(this IServiceCollection services, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            services.AddDbContext<ShopDbContext>(options =>
            {
                options.UseInMemoryDatabase("sharp.shop");
            });
        }
        else
        {
            var cn = Environment.GetEnvironmentVariable("SHOPAPI_DB");

            if (string.IsNullOrWhiteSpace(cn))
                cn = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=sharp.shop;User=sharp;Password=sharp";
            
            services.AddDbContext<ShopDbContext>(options =>
            {
                options.UseSqlServer(cn);
            });
        }
        
    }
}