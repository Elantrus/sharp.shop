using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Configuration.IoC;

public static class DatabaseConfiguration
{
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