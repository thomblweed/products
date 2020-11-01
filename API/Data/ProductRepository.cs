using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataStoreContext _context;

        public ProductRepository(DataStoreContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(string name, decimal price)
        {
            Product newProduct = new Product()
            {
                Name = name,
                Price = price
            };
            _context.Products.Add(newProduct);

            await _context.SaveChangesAsync();
        }

        public Task<Product> DeleteProductByIdAsync(int productId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            Product product = await _context.Products.SingleOrDefaultAsync(p => p.Id == productId);

            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            List<Product> products = await _context.Products.ToListAsync();

            return products;
        }

        public Task<Product> UpdateProductByIdAsync(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}