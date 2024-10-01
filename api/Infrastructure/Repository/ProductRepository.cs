
using api.Domain;
using api.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task UpdateAsync(Product customer)
    {
        _context.Products.Update(customer);
    }

    public async Task DeleteAsync(Guid id)
    {
        var customer = await _context.Products.FindAsync(id);
        if (customer != null)
        {
            _context.Products.Remove(customer);
        }
    }
}
