using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketService.Application.DTOs;

namespace BasketService.Infrastructure.ProductService
{
    public interface IProductServiceClient
    {
        Task<ProductDto?> GetProductByIdAsync(string productId);
    }

}
