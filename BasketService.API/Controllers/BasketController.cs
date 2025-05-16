using BasketService.Application.Commands.CreateBasket;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.API.Controllers
{
    [ApiController]
    [Route("api/baskets")]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Guid userId)
        {
            var basketId = await _mediator.Send(new CreateBasketCommand(userId));
            return Ok(basketId);
        }

        [HttpPost("{id}/items")]
        public async Task<IActionResult> AddItem(Guid id, [FromBody] AddItemRequest request)
        {
            await _mediator.Send(new AddProductToBasketCommand(request.UserId, id, request.ProductId, request.Quantity));
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, [FromQuery] Guid userId)
        {
            var basket = await _mediator.Send(new GetBasketQuery(id, userId));
            return Ok(basket);
        }

        // Finalization, removal itd. analogicznie
    }

}
