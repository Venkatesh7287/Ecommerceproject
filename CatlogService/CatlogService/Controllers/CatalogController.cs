using CatalogService.Model;
using CatalogService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var product = await _catalogService.GetAllProductAsync();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _catalogService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _catalogService.AddProductAsync(product);
            return Ok(new { message = "Product Created Successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            await _catalogService.UpdateProductAsync(product);
            return Ok(new { message = "Product Updated Successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _catalogService.DeleteProductAsync(id);
            return Ok(new { message = "Product Deleted Successfully" });
        }
    }
}
