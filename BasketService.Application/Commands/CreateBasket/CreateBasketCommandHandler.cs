using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Commands.CreateBasket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, Guid>
    {
        private readonly IBasketRepository _repo;

        public CreateBasketCommandHandler(IBasketRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateBasketCommand request, CancellationToken ct)
        {
            var basket = new Basket { Id = Guid.NewGuid(), UserId = request.UserId };
            await _repo.CreateAsync(basket);
            return basket.Id;
        }
    }

}
