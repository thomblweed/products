using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task CreateProductAsync(string name, decimal price);
        Task<Product> GetProductByIdAsync(int productId);
        Task<Product> UpdateProductByIdAsync(int productId);
        Task<Product> DeleteProductByIdAsync(int productId);
    }
}