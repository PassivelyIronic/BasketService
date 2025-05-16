using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Commands.AddProduct
{
    public record AddProductToBasketCommand(Guid UserId, Guid BasketId, string ProductId, int Quantity) : IRequest;

}
