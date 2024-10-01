namespace api.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        Task<int> CommitAsync();
    }
}
