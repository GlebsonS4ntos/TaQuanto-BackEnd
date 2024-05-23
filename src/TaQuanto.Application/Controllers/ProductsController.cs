using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaQuanto.Domain.Entities;
using TaQuanto.Domain.Pagination;
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
        public async Task<IActionResult> GetAllProductsAsync([FromQuery] ProductParameters parameters)
        {
            var products = await _service.GetAllProductsAsync(parameters);

            var metadata = new
            {
                page_size = products.PageSize,
                page_current = products.PageCurrent,
                total_page = products.TotalPage,
                total_count = products.TotalCount,
                has_next_page = products.HasNextPage,
                has_previous_page = products.HasPreviousPage,
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(products);
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
