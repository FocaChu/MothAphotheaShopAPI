using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MothAphotheaShopAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly PurchaseService _service;

        public PurchaseController(PurchaseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPurchases()
        {
            var purchases = await _service.GetAllAsync();

            return Ok(purchases);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchaseById(int id)
        {
            var purchase = await _service.GetByIdAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }

            return Ok(purchase);
        }
    }
}
