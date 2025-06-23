using Microsoft.AspNetCore.Mvc;
using MothAphotheaShopAPI.Controllers;

namespace MothAphotheaShopAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class AromaController : GenericController<Aroma, AromaDTO>
    {
        public AromaController(IGenericService<Aroma, AromaDTO> service)
            : base(service)
        {
        }
    }
}
