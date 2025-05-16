using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Queries
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, BasketDto>
    {
        private readonly IBasketRepository _repo;

        public GetBasketQueryHandler(IBasketRepository repo)
        {
            _repo = repo;
        }

        public async Task<BasketDto> Handle(GetBasketQuery request, CancellationToken ct)
        {
            var basket = await _repo.GetByIdAsync(request.BasketId);
            if (basket == null || basket.UserId != request.UserId)
                throw new Exception("Basket not found or unauthorized");

            return new BasketDto
            {
                BasketId = basket.Id,
                Total = basket.Items.Sum(i => i.Price * i.Quantity),
                Items = basket.Items
            };
        }
    }

}
