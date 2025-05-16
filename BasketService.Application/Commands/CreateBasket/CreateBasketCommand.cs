using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Commands.CreateBasket
{
    public record CreateBasketCommand(Guid UserId) : IRequest<Guid>;

}
