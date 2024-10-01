using api.Domain;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(Guid id);
    Task<List<Order>> GetAllAsync();
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(Guid id);
}
