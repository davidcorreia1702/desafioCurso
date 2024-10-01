using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Features.CreateOrder
{
    public class CreateOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            if(result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
