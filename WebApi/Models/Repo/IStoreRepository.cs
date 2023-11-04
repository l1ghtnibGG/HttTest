namespace WebApi.Models.Repo;

public interface IStoreRepository<T> where T : class    
{
    public IQueryable<T> GetAll { get; }

    public Task<T?> GetItem(Guid id);

    public Task<T?> AddItem(T item);

    public Task<T?> EditItem(Guid id, T item);

    public Task<string?> DeleteItem(Guid id);

    public IEnumerable<object> GetWithItems(Guid id);
}