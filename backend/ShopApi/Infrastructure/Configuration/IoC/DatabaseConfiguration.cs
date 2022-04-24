using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration.IoC;

public static class DatabaseConfiguration
{
    public static void AddDatabase(this IServiceCollection services)
    {
        var cn = Environment.GetEnvironmentVariable("SHOPAPI_DB");

        if (string.IsNullOrWhiteSpace(cn))
            cn = ".\\SQLEXPRESS; Database=sharp.shop;User Id=sharp;Password=sharp;";

        services.AddDbContext<ShopDbContext>(options =>
        {
            options.UseSqlServer(cn);
        });
    }
}