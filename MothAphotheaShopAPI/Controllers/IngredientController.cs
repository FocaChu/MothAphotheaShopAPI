using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MothAphotheaShopAPI.Controllers;

namespace MothAphotheaShopAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ingredients = await _service.GetAllAsync();

            if (ingredients == null || !ingredients.Any())
                return NotFound("No ingredients found.");

            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ingredient = await _service.GetByIdAsync(id);

            if (ingredient == null) return NotFound($"Ingredient with ID {id} not found.");

            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IngredientCreateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ingredient = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = ingredient.Id }, ingredient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] IngredientCreateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);

            if (updated == null) return NotFound($"Ingredient with ID {id} not found.");

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted) return NotFound($"Ingredient with ID {id} not found.");

            return NoContent();
        }
    }
}
