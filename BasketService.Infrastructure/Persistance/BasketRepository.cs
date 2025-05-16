using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Infrastructure.Persistance
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IMongoCollection<Basket> _collection;

        public BasketRepository(IConfiguration config)
        {
            var client = new MongoClient(config["Mongo:Connection"]);
            var db = client.GetDatabase("BasketDb");
            _collection = db.GetCollection<Basket>("Baskets");
        }

        public async Task CreateAsync(Basket basket) => await _collection.InsertOneAsync(basket);

        public async Task<Basket> GetByIdAsync(Guid basketId) =>
            await _collection.Find(x => x.Id == basketId).FirstOrDefaultAsync();

        public async Task UpdateAsync(Basket basket) =>
            await _collection.ReplaceOneAsync(x => x.Id == basket.Id, basket);
    }

}
