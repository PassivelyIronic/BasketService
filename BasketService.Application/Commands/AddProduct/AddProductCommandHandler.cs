using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Commands.AddProduct
{
    public class AddProductToBasketCommandHandler : IRequestHandler<AddProductToBasketCommand>
    {
        private readonly IBasketRepository _repo;
        private readonly IProductServiceClient _productService;

        public AddProductToBasketCommandHandler(IBasketRepository repo, IProductServiceClient productService)
        {
            _repo = repo;
            _productService = productService;
        }

        public async Task<Unit> Handle(AddProductToBasketCommand request, CancellationToken ct)
        {
            var basket = await _repo.GetByIdAsync(request.BasketId);
            if (basket == null || basket.UserId != request.UserId)
                throw new Exception("Basket not found or user mismatch");

            var product = await _productService.GetProductByIdAsync(request.ProductId);

            var item = basket.Items.FirstOrDefault(i => i.ProductId == request.ProductId);
            if (item != null)
                item.Quantity += request.Quantity;
            else
                basket.Items.Add(new BasketItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = request.Quantity
                });

            await _repo.UpdateAsync(basket);
            return Unit.Value;
        }
    }

}
