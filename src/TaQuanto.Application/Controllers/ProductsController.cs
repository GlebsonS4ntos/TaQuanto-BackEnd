using Microsoft.AspNetCore.Mvc;
using TaQuanto.Service.Dtos.Product;
using TaQuanto.Service.Interfaces;

namespace TaQuanto.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceProduct _service;

        public ProductsController(IServiceProduct service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            return Ok(await _service.GetAllProductsAsync());
        }

        [HttpGet("{id:guid}", Name = "ObterProduto")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _service.GetProductByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateOrUpdateProductDto dto)
        {
            var productDto = await _service.CreateProdutoAsync(dto);
            return new CreatedAtRouteResult("ObterProduto", new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProductAsync([FromRoute] Guid id, [FromForm] CreateOrUpdateProductDto dto)
        {
            await _service.UpdateProdutoAsync(dto, id);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] Guid id)
        {
            await _service.DeleteProductByIdAsync(id);
            return NoContent();
        }
    }
}
