using WebApi.Models;
using WebApi.Models.DTOs;

namespace WebApi.Services;

public interface ICategoryService
{
    public IQueryable<Category> GetCategories();

    public Task<Category?> GetCategory(Guid id);

    public Task<Category?> AddCategory(CategoryDto categoryDto);

    public Task<Category?> EditCategory(Guid id, CategoryDto Category);

    public Task<string?> DeleteCategory(Guid id);

    public IEnumerable<object> GetWithItems(Guid id);
}