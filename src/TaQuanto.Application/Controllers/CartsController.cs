using Microsoft.AspNetCore.Mvc;
using TaQuanto.Service.Dtos.Cart;
using TaQuanto.Service.Interfaces;

namespace TaQuanto.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly IServiceCart _serviceCart;

        public CartsController(IServiceCart serviceCart)
        {
            _serviceCart = serviceCart;
        }

        [HttpGet("{id:guid}", Name = "ObterCart")]
        public async Task<IActionResult> GetCartByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _serviceCart.GetCartByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartAsync([FromBody] CreateOrUpdateCartDto dto)
        {
            var cart = await _serviceCart.CreateCartAsync(dto);
            return new CreatedAtRouteResult("ObterCart", new { id = cart.Id }, cart);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategoryAsync([FromRoute] Guid id, [FromBody] CreateOrUpdateCartDto dto)
        {
            await _serviceCart.UpdateCartAsync(dto, id);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteCartAsync([FromRoute] Guid id)
        {
            await _serviceCart.DeleteCartByIdAsync(id);
            return NoContent();
        }
    }
}
