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
                Id = 0,
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

        public Task<Product> GetProductByIdAsync(int productId)
        {
            throw new System.NotImplementedException();
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