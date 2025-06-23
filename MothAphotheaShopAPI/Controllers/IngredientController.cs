using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetById(Guid id)
        {
            var ingredient = await _service.GetByIdAsync(id);

            if (ingredient == null) return NotFound($"Ingredient with ID {id} not found.");

            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IngredientInsertDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ingredient = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = ingredient.Id }, ingredient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] IngredientInsertDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);

            if (updated == null)
                return NotFound($"Ingredient with ID {id} not found.");

            return Ok(updated);
        }

        [HttpPatch("{id}/simple")]
        public async Task<IActionResult> UpdateSimple(Guid id, IngredientInsertDTO dto)
        {
            var updatedIngredient = await _service.UpdateSimpleAsync(id, dto);
            if (updatedIngredient == null)
                return NotFound($"Ingredient with ID {id} not found.");

            return Ok(updatedIngredient);
        }

        [HttpPatch("{id}/aromas")]
        public async Task<IActionResult> UpdateAromas(Guid id, List<Guid> aromaIds)
        {
            var updatedIngredient = await _service.UpdateAromasAsync(id, aromaIds);
            if (updatedIngredient == null)
                return NotFound($"Ingredient with ID {id} not found.");

            return Ok(updatedIngredient);
        }

        [HttpPatch("{id}/textures")]
        public async Task<IActionResult> UpdateTextures(Guid id, List<Guid> textureIds)
        {
            var updatedIngredient = await _service.UpdateTexturesAsync(id, textureIds);
            if (updatedIngredient == null)
                return NotFound($"Ingredient with ID {id} not found.");

            return Ok(updatedIngredient);
        }

        [HttpPatch("{id}/effects")]
        public async Task<IActionResult> UpdateEffects(Guid id, List<Guid> effectIds)
        {
            var updatedIngredient = await _service.UpdateEffectsAsync(id, effectIds);
            if (updatedIngredient == null)
                return NotFound($"Ingredient with ID {id} not found.");

            return Ok(updatedIngredient);
        }

        [HttpPatch("{id}/flavors")]
        public async Task<IActionResult> UpdateFlavors(Guid id, List<Guid> contraindicationsIds)
        {
            var updatedIngredient = await _service.UpdateFlavorNotesAsync(id, contraindicationsIds);
            if (updatedIngredient == null)
                return NotFound($"Ingredient with ID {id} not found.");

            return Ok(updatedIngredient);
        }

        [HttpPatch("{id}/contraindications")]
        public async Task<IActionResult> UpdateContraindications(Guid id, List<Guid> contraindicationsIds)
        {
            var updatedIngredient = await _service.UpdateContraindicationsAsync(id, contraindicationsIds);
            if (updatedIngredient == null)
                return NotFound($"Ingredient with ID {id} not found.");

            return Ok(updatedIngredient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted) return NotFound($"Ingredient with ID {id} not found.");

            return NoContent();
        }
    }
}
