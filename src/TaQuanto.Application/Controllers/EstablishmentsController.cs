using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaQuanto.Domain.Pagination;
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
        public async Task<IActionResult> GetAllEstablishmentsAsync([FromQuery] EstablishmentParameters parameters)
        {
            var establishments = await _service.GetAllEstablishmentAsync(parameters);

            var metadata = new
            {
                page_size = establishments.PageSize,
                page_current = establishments.PageCurrent,
                total_page = establishments.TotalPage,
                total_count = establishments.TotalCount,
                has_next_page = establishments.HasNextPage,
                has_previous_page = establishments.HasPreviousPage,
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(establishments);
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
