using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Models.DTOs;
using WebApi.Services;

namespace WebApi.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly ILogger _logger;

    public CategoryController(ICategoryService categoryService, 
        ILogger<CategoryController> logger)
    {
        _categoryService = categoryService;
        _logger = logger;
    }
    
    /// <summary>
    /// Get all categories
    /// </summary>
    [HttpGet("categories")]
    public ActionResult<IQueryable<Category>> GetCategories() =>
        Ok(_categoryService.GetCategories());

    /// <summary>
    /// Get a category by id
    /// </summary>
    [HttpGet("categories/{id:guid}")]
    public async Task<ActionResult<Category>> GetCategory(Guid id)
    {
        var category = await _categoryService.GetCategory(id);

        if (category == null)
            return BadRequest(category);

        return Ok(category);
    }

    /// <summary>
    /// Add a category
    /// </summary>
    [HttpPost("category/add")]
    public async Task<ActionResult<Category>> AddCategory([FromBody]CategoryDto categoryDto)
    {
        var category = await _categoryService.AddCategory(categoryDto);

        if (category != null) 
            return Ok(category);
        
        _logger.Log(LogLevel.Error, "Something went wrong, category didn't create");
        return BadRequest(category);
    }

    /// <summary>
    /// Edit a category
    /// </summary>
    [HttpPost("category/edit/{id:guid}")]
    public async Task<ActionResult<Category>> EditCategory(Guid id, [FromBody]CategoryDto categoryDto)
    {
        var category = await _categoryService.EditCategory(id, categoryDto);

        if (category != null) 
            return Ok(category);
        
        _logger.Log(LogLevel.Error, "Something went wrong, category didn't find");
        return BadRequest(category);
    }

    /// <summary>
    /// Delete a category
    /// </summary>
    [HttpPost("category/delete/{id:guid}")]
    public async Task<ActionResult<string>> DeleteCategory(Guid id)
    {
        var category = await _categoryService.DeleteCategory(id);

        if (category != "Category doesn't exist") 
            return Ok(category);
        
        _logger.Log(LogLevel.Error, "Something went wrong, category didn't find");
        return BadRequest(category);
    }

    /// <summary>
    /// Get a category with products
    /// </summary>
    [HttpGet("category/{id:guid}/products")]
    public ActionResult<List<Category>> GetCategoryWithCategories(Guid id)
    {
        var category = _categoryService.GetWithItems(id);

        if (category != null) 
            return Ok(category);
        
        _logger.Log(LogLevel.Error, "Something went wrong, category didn't find");
        return BadRequest(category);
    }
}