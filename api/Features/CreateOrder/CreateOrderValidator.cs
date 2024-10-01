using FluentValidation;

namespace api.Features.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator() 
        { 
            RuleFor(x => x.Client).NotEmpty();
            RuleForEach(x => x.Items).SetValidator(new OrderItemValidator());
        }
    }

    public class OrderItemValidator: AbstractValidator<OrderItemDto> 
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Count).GreaterThan(0);
        }
    }
}
