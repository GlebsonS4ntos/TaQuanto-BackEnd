using Microsoft.AspNetCore.Mvc;
using TaQuanto.Service.Interfaces;

namespace TaQuanto.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatesController : ControllerBase
    {
        private readonly IServiceState _service;

        public StatesController(IServiceState service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStatesAsync() 
        { 
            return Ok(await _service.GetAllStateAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetStateByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _service.GetStateByIdAsync(id));
        }
    }
}
