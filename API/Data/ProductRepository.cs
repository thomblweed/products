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

        public Task<Product> CreateProductAsync()
        {
            throw new System.NotImplementedException();
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
            return await _context.Products.ToListAsync();
        }

        public Task<Product> UpdateProductByIdAsync(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}