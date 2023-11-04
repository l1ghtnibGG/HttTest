using AutoMapper;
using WebApi.Models;
using WebApi.Models.DTOs;
using WebApi.Models.Repo;

namespace WebApi.Services;

public class CategoryService : ICategoryService
{
    private readonly IStoreRepository<Category> _categoryContext;
    private readonly IMapper _mapper;

    public CategoryService(IStoreRepository<Category> categoryContext,  IMapper mapper)
    {
        _categoryContext = categoryContext;
        _mapper = mapper;
    }

    public IQueryable<Category> GetCategories() => _categoryContext.GetAll;
    
    public async Task<Category?> GetCategory(Guid id) => await _categoryContext.GetItem(id);

    public async Task<Category?> AddCategory(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);

        return await _categoryContext.AddItem(category);
    }

    public async Task<Category?> EditCategory(Guid id, CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);

        return await _categoryContext.EditItem(id, category);
    }

    public async Task<string?> DeleteCategory(Guid id) => await _categoryContext.DeleteItem(id);

    public IEnumerable<object> GetWithItems(Guid id) => _categoryContext.GetWithItems(id);
}