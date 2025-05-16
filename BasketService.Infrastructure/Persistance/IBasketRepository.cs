using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketService.Domain.Entities;

namespace BasketService.Infrastructure.Persistance
{
    public interface IBasketRepository
    {
        Task<Basket?> GetByIdAsync(string basketId);
        Task CreateAsync(Basket basket);
        Task UpdateAsync(Basket basket);
        Task DeleteAsync(string basketId);
    }

}
