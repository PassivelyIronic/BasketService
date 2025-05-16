using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Infrastructure.ProductService
{
    public class ProductServiceClient : IProductServiceClient
    {
        private readonly HttpClient _client;

        public ProductServiceClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<ProductDto> GetProductByIdAsync(string id)
        {
            var response = await _client.GetAsync($"/api/products/{id}");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
        }
    }

}
