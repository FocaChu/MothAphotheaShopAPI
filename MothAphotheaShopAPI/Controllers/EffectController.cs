using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MothAphotheaShopAPI.Controllers;

namespace MothAphotheaShopAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class EffectController : GenericController<Effect, EffectDTO>
    {
        public EffectController(IGenericService<Effect, EffectDTO> service)
            : base(service)
        {
        }
    }
}
