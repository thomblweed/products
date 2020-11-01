using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] Product form)
        {
            await _repository.CreateProductAsync(form.Name, form.Price);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            Product product = await _repository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            ProductDTO productDTO = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.ToString("0.00")
            };

            return Ok(productDTO);
        }
    }
}