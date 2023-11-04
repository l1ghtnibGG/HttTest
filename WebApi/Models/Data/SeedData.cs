using Microsoft.EntityFrameworkCore;

namespace WebApi.Models.Data;

public class SeedData
{
    public static void EnsureData(IApplicationBuilder app)
    {
        StoreDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        if (!context.Products.Any())
        {
            context.AddRange(
                new Product
                {
                    Name = "Banana",
                    Description = "Food, yellow, long",
                    Weight = 0.2,
                    Categories =
                    {
                        new Category
                        {
                            Name = "Fruit",
                            Description = "the seed-bearing structure in flowering " +
                                          "plants that is formed from the ovary after flowering."
                        },
                        new Category
                        {
                            Name = "Food",
                            Description = "Something to eat"
                        }
                    }
                },
                new Product
                {
                    Name = "Bike",
                    Description = "Mechanic vehicle with 2 wheels",
                    Weight = 200,
                    Categories =
                    {
                        new Category
                        {
                            Name = "Vehicle",
                            Description = "Something to move"
                        },
                        new Category
                        {
                            Name = "Mechanic",
                            Description = "Nonbio"
                        }
                    }
                },
                new Product
                {
                    Name = "Bed",
                    Description = "Place for rest",
                    Weight = 200,
                    Categories =
                    {
                        new Category
                        {
                            Name = "Furniture",
                            Description = "something made of wood or another material for helping people"
                        }
                    }
                });
            
            context.SaveChangesAsync();
        }
    }
}