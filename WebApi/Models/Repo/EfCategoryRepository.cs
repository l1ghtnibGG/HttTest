using Microsoft.EntityFrameworkCore;

namespace WebApi.Models.Repo;

public class EfCategoryRepository : IStoreRepository<Category>
{
    private readonly StoreDbContext _context;

    public EfCategoryRepository(StoreDbContext context)
    {
        _context = context;
    }

    IQueryable<Category> IStoreRepository<Category>.GetAll => _context.Categories;

    public async Task<Category?> GetItem(Guid id) =>
        await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Category?> AddItem(Category? item)
    {
        if (item == null)
            return null;

        _context.Add(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task<Category?> EditItem(Guid id, Category item)
    {
        var category =  await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        
        if (category == null)
            return null;

        _context.Categories.Update(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task<string?> DeleteItem(Guid id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

        if (category == null)
            return "Category doesn't exist";

        _context.Remove(category);
        await _context.SaveChangesAsync();

        return $"{category.Name} was successfully deleted";
    }

    public IEnumerable<object> GetWithItems(Guid id) =>
        (from product in _context.Products
            join category in _context.Categories
                on product.Id equals category.ProductId
            where category.Id == id
            select new
            {
                CategoryName = category.Name,
                ProductName = product.Name
            })
        .AsEnumerable();
}