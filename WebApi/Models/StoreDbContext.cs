using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> opt):
        base (opt) {}
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}