using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using MongoDB.Driver;

namespace API.Data.Seed
{
    public class SeedProducts
    {
        private readonly IMongoCollection<Product> _products;

        public SeedProducts(IProductsStoreDatabaseSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.ProductsCollectionName);
        }

        public async Task SeedData()
        {
            List<Product> baseProducts = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Lavender heart",
                    Price = 9.25M
                },
                new Product
                {
                    Id = 2,
                    Name = "Personalised cufflinks",
                    Price = 45.00M
                },
                new Product
                {
                    Id = 3,
                    Name = "Kids T-shirt",
                    Price = 19.95M
                }
            };

            await _products.InsertManyAsync(baseProducts);
        }
    }
}