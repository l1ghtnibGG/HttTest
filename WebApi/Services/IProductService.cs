using WebApi.Models;
using WebApi.Models.DTOs;

namespace WebApi.Services;

public interface IProductService
{
    public IQueryable<Product> GetProducts();

    public Task<Product?> GetProduct(Guid id);

    public Task<Product?> AddProduct(ProductDto product);

    public Task<Product?> EditProduct(Guid id, ProductDto product);

    public Task<string?> DeleteProduct(Guid id);

    public IEnumerable<object> GetWithItems(Guid id);
}