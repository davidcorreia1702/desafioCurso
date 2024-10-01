using api.Shared;
using MediatR;

namespace api.Features.CreateOrder
{
    public class CreateOrderCommand : IRequest<Result>
    {
        public string Client { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
