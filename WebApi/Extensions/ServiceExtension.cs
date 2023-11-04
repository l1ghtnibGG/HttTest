using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Repo;
using WebApi.Services;

namespace WebApi.Extensions;

public static class ServiceExtension
{
    public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("StoreAPI");

        services.AddDbContext<StoreDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
    }
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IStoreRepository<Category>, EfCategoryRepository>();
        services.AddScoped<IStoreRepository<Product>, EfProductRepository>();

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
    }
}