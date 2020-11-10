using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromForm] ProductDetails form)
        {
            if (form.Name == null || form.Price == 0)
            {
                return BadRequest();
            }

            Product newProduct = new Product()
            {
                Name = form.Name,
                Price = form.Price
            };

            await _productService.CreateProductAsync(newProduct);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            Product product = await _productService.GetProductByIdAsync(id);

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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct([FromForm] ProductDetails form, int id)
        {
            Product product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            if (form.Name == null)
            {
                return BadRequest();
            }

            // This check only here to work with swagger calls,
            // where price is sent with value other than 0.
            // Postman tests send 0 so don't want to update price to 0.
            if (form.Price != 0) product.Price = form.Price;

            product.Name = form.Name;

            await _productService.UpdateProductAsync(product);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            Product product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteProductByIdAsync(id);

            return Ok();
        }
    }
}