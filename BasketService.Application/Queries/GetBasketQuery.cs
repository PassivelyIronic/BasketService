using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Queries
{
    public record GetBasketQuery(Guid BasketId, Guid UserId) : IRequest<BasketDto>;

}
