using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Models.DTOs;
using WebApi.Services;

namespace WebApi.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ILogger _logger;

    public ProductController(IProductService productService, 
        ILogger<ProductController> logger)
    {
        _productService = productService;
        _logger = logger;
    }
    
    /// <summary>
    /// Get all products
    /// </summary>
    [HttpGet("products")]
    public ActionResult<IQueryable<Product>> GetProducts() =>
        Ok(_productService.GetProducts());

    /// <summary>
    /// Get a product by ID
    /// </summary>
    [HttpGet("products/{id:guid}")]
    public async Task<ActionResult<Product>> GetProduct(Guid id)
    {
        var product = await _productService.GetProduct(id);

        if (product == null)
            return BadRequest(product);

        return Ok(product);
    }

    /// <summary>
    /// Add a product
    /// </summary>
    [HttpPost("product/add")]
    public async Task<ActionResult<Product>> AddProduct([FromBody]ProductDto productDto)
    {
        var product = await _productService.AddProduct(productDto);

        if (product != null) 
            return Ok(product);
        
        _logger.Log(LogLevel.Error, "Something went wrong, product didn't create");
        return BadRequest(product);
    }

    /// <summary>
    /// Edit a product
    /// </summary>
    [HttpPost("product/edit/{id:guid}")]
    public async Task<ActionResult<Product>> EditProduct(Guid id, [FromBody]ProductDto productDto)
    {
        var product = await _productService.EditProduct(id, productDto);

        if (product != null) 
            return Ok(product);
        
        _logger.Log(LogLevel.Error, "Something went wrong, product didn't find");
        return BadRequest(product);
    }

    /// <summary>
    /// Delete a product
    /// </summary>
    [HttpPost("product/delete/{id:guid}")]
    public async Task<ActionResult<string>> DeleteProduct(Guid id)
    {
        var product = await _productService.DeleteProduct(id);

        if (product != "Product doesn't exist") 
            return Ok(product);
        
        _logger.Log(LogLevel.Error, "Something went wrong, product didn't find");
        return BadRequest(product);
    }

    /// <summary>
    /// Get a product with categories
    /// </summary>
    [HttpGet("product/{id:guid}/categories")]
    public ActionResult<List<Product>> GetProductWithCategories(Guid id)
    {
        var products = _productService.GetWithItems(id);

        if (products != null) 
            return Ok(products);
        
        _logger.Log(LogLevel.Error, "Something went wrong, products and categories didn't find");
        return BadRequest(products);
    }
}