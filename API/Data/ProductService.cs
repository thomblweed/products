using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using MongoDB.Driver;

namespace API.Data
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IProductsStoreDatabaseSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.ProductsCollectionName);
        }

        public async Task CreateProductAsync(Product product)
        {
            await _products.InsertOneAsync(product);
        }

        public async Task<DeleteResult> DeleteProductByIdAsync(int productId)
        {
            return await _products.DeleteOneAsync(product => product.Id == productId);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            Product product = await _products.Find(product =>
                product.Id == productId).FirstOrDefaultAsync();

            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            List<Product> products = await _products.Find(product => true).ToListAsync();

            return products;
        }

        public async Task<ReplaceOneResult> UpdateProductAsync(Product productIn)
        {
            return await _products.ReplaceOneAsync(product =>
                product.Id == productIn.Id, productIn);
        }
    }
}