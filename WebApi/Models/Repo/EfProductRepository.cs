using Microsoft.EntityFrameworkCore;

namespace WebApi.Models.Repo;

public class EfProductRepository : IStoreRepository<Product>
{
    private readonly StoreDbContext _context;

    public EfProductRepository(StoreDbContext context)
    {
        _context = context;
    }

    IQueryable<Product> IStoreRepository<Product>.GetAll => _context.Products;

    public async Task<Product?> GetItem(Guid id) => 
        await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Product?> AddItem(Product? item)
    {
        if (item == null)
            return null;

        _context.Add(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task<Product?> EditItem(Guid id, Product item)
    {
        var product =  await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        
        if (product == null)
            return null;

        _context.Products.Update(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task<string?> DeleteItem(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product == null)
            return "Product doesn't exist";

        _context.Remove(product);
        await _context.SaveChangesAsync();

        return $"{product.Name} was successfully deleted";
    }

    public IEnumerable<object> GetWithItems(Guid id) =>
        (from product in _context.Products
            join category in _context.Categories
                on product.Id equals category.ProductId
            where product.Id == id
            select new
            {
                ProductName = product.Name,
                CategoryName = category.Name
            }).AsEnumerable();
}