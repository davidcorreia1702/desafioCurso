namespace api.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _context = context;
            Orders = orderRepository;
            Products = productRepository;
        }

        public IOrderRepository Orders { get; }
        public IProductRepository Products { get; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
