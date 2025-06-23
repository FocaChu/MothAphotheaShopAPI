using Microsoft.AspNetCore.Mvc;

namespace MothAphotheaShopAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();

            if(products == null || !products.Any())
                return NotFound("No products found.");

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null) 
                return NotFound(new { message = $"Product with ID {id} not found." });

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO dto)
        {
            var product = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);

            if (updated == null) 
                return NotFound($"Product with ID {id} not found.");

            return Ok(updated);
        }

        [HttpPatch("{id}/simple")]
        public async Task<IActionResult> UpdateSimple(Guid id, ProductDTO dto)
        {
            var updatedProduct = await _service.UpdateSimpleAsync(id, dto);
            if (updatedProduct == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(updatedProduct);
        }

        [HttpPatch("{id}/aromas")]
        public async Task<IActionResult> UpdateAromas(Guid id, List<Guid> aromaIds)
        {
            var updatedProduct = await _service.UpdateAromasAsync(id, aromaIds);
            if (updatedProduct == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(updatedProduct);
        }

        [HttpPatch("{id}/textures")]
        public async Task<IActionResult> UpdateTextures(Guid id, List<Guid> textureIds)
        {
            var updatedProduct = await _service.UpdateTexturesAsync(id, textureIds);
            if (updatedProduct == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(updatedProduct);
        }

        [HttpPatch("{id}/effects")]
        public async Task<IActionResult> UpdateEffects(Guid id, List<Guid> effectIds)
        {
            var updatedProduct = await _service.UpdateEffectsAsync(id, effectIds);
            if (updatedProduct == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(updatedProduct);
        }

        [HttpPatch("{id}/flavors")]
        public async Task<IActionResult> UpdateFlavors(Guid id, List<Guid> contraindicationsIds)
        {
            var updatedProduct = await _service.UpdateFlavorNotesAsync(id, contraindicationsIds);
            if (updatedProduct == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(updatedProduct);
        }

        [HttpPatch("{id}/contraindications")]
        public async Task<IActionResult> UpdateContraindications(Guid id, List<Guid> contraindicationsIds)
        {
            var updatedProduct = await _service.UpdateContraindicationsAsync(id, contraindicationsIds);
            if (updatedProduct == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted) 
                return NotFound($"Product with ID {id} not found.");

            return NoContent();
        }
    }
}
