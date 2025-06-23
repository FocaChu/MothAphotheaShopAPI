using Microsoft.AspNetCore.Mvc;
using MothAphotheaShopAPI.Controllers;

namespace MothAphotheaShopAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextureController : GenericController<Texture, TextureDTO>
    {
        public TextureController(IGenericService<Texture, TextureDTO> service)
            : base(service)
        {
        }
    }
}
