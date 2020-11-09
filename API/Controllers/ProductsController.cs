using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _repository;

        public ProductsController(IProductService repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetProducts()
        {
            IReadOnlyList<Product> products = await _repository.GetProductsAsync();

            if (products.Count < 1)
            {
                return NotFound();
            }

            List<ProductDTO> productsDto = products.Select(product => new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.ToString("0.00")
            }).ToList();

            return Ok(productsDto);
        }
    }
}