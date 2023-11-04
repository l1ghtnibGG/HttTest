using AutoMapper;
using WebApi.Models;
using WebApi.Models.DTOs;
using WebApi.Models.Repo;

namespace WebApi.Services;

public class ProductService : IProductService
{
    private readonly IStoreRepository<Product> _productContext;
    private readonly IMapper _mapper;

    public ProductService(IStoreRepository<Product> productContext,  IMapper mapper)
    {
        _productContext = productContext;
        _mapper = mapper;
    }

    public IQueryable<Product> GetProducts() => _productContext.GetAll;
    
    public async Task<Product?> GetProduct(Guid id) => await _productContext.GetItem(id);

    public async Task<Product?> AddProduct(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);

        return await _productContext.AddItem(product);
    }

    public async Task<Product?> EditProduct(Guid id, ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);

        return await _productContext.EditItem(id, product);
    }

    public async Task<string?> DeleteProduct(Guid id) => await _productContext.DeleteItem(id);

    public IEnumerable<object> GetWithItems(Guid id) => _productContext.GetWithItems(id);
}