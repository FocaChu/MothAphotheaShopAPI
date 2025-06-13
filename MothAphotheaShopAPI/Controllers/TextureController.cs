using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MothAphotheaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextureController : ControllerBase
    {
        private readonly Db _context;
        private readonly IMapper _mapper;

        public TextureController(Db context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
