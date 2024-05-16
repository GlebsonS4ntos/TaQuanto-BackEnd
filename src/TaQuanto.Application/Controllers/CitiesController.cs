using Microsoft.AspNetCore.Mvc;
using TaQuanto.Service.Interfaces;

namespace TaQuanto.Application.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly IServiceCity _service;

        public CitiesController(IServiceCity service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCitiesAsync()
        {
            return Ok(await _service.GetAllCityAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCityByIdAsync([FromRoute] Guid id)
        {
            return Ok( await  _service.GetCityByIdAsync(id));
        }
    }
}
