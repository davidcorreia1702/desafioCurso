using api.Domain;
using api.Infrastructure;
using api.Shared;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api.Features.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = new Order(request.Client);

                foreach (var item in request.Items)
                    order.AddItem(new ItemOrder(item.ProductId, item.Count, item.Price));

                await _unitOfWork.Orders.AddAsync(order);
                await _unitOfWork.CommitAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Erro ao criar pedido: {ex.Message}");
            }
        }
    }
}
