using Microsoft.AspNetCore.Mvc;
using MothAphotheaShopAPI.Controllers;

namespace MothAphotheaShopAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlavorNoteController : GenericController<FlavorNote, FlavorNoteDTO>
    {
        public FlavorNoteController(IGenericService<FlavorNote, FlavorNoteDTO> service)
            : base(service)
        {
        }
    }
}
