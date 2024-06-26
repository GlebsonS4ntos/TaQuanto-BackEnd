﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TaQuanto.Domain.Pagination;
using TaQuanto.Service.Dtos.Category;
using TaQuanto.Service.Interfaces;

namespace TaQuanto.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceCategory _service;

        public CategoriesController(IServiceCategory service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync([FromQuery] CategoryParameters parameters)
        {
            var categories = await _service.GetAllCategoriesAsync(parameters);
            return Ok(categories);
        }

        [HttpGet("{id:guid}", Name = "ObterCategoria")]
        public async Task<IActionResult> GetCategoryByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _service.GetCategoryByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromForm] CreateOrUpdateCategoryDto dto)
        {
            var categoryDto = await _service.CreateCategoryAsync(dto);
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategoryAsync([FromRoute] Guid id, [FromForm] CreateOrUpdateCategoryDto dto)
        {
            await _service.UpdateCategoryAsync(dto, id);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] Guid id)
        {
            await _service.DeleteCategoryByIdAsync(id);
            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PatchCategoryAsync([FromRoute] Guid id, [FromBody] JsonPatchDocument<CreateOrUpdateCategoryDto> patchCategory)
        {
            await _service.UpdatePatchCategoryAsync(patchCategory, id);
            return NoContent();
        }
    }
}
