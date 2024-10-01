
using api.Domain;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product customer);
    Task UpdateAsync(Product customer);
    Task DeleteAsync(Guid id);
}
