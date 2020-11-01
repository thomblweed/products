using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            IReadOnlyList<Product> products = await _repository.GetProductsAsync();

            if (products.Count < 1)
            {
                return NotFound();
            }

            List<ProductDto> productsDto = new List<ProductDto>();

            foreach (Product product in products)
            {
                productsDto.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price.ToString("0.00")
                });
            }

            return Ok(productsDto);
        }
    }
}