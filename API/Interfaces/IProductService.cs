using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using MongoDB.Driver;

namespace API.Interfaces
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task CreateProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int productId);
        Task<ReplaceOneResult> UpdateProductAsync(Product productIn);
        Task<DeleteResult> DeleteProductByIdAsync(int productId);
    }
}