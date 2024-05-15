using Microsoft.AspNetCore.Mvc;
using TaQuanto.Service.Dtos.Establishment;
using TaQuanto.Service.Interfaces;

namespace TaQuanto.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstablishmentsController : ControllerBase
    {
        private readonly IServiceEstablishment _service;

        public EstablishmentsController(IServiceEstablishment service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEstablishmentsAsync()
        {
            return Ok(await _service.GetAllEstablishmentAsync());
        }

        [HttpGet("{id:guid}", Name = "ObterEstabelecimento")]
        public async Task<IActionResult> GetEstablishmentByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _service.GetEstablishmentByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstablishmentAsync([FromForm] CreateOrUpdateEstablishmentDto dto)
        {
            var categoryDto = await _service.CreateEstablishmentAsync(dto);
            return new CreatedAtRouteResult("ObterEstabelecimento", new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEstablishmentAsync([FromRoute] Guid id, [FromForm] CreateOrUpdateEstablishmentDto dto)
        {
            await _service.UpdateEstablishmentAsync(dto, id);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteEstablishmentAsync([FromRoute] Guid id)
        {
            await _service.DeleteEstablishmentAsync(id);
            return NoContent();
        }
    }
}
