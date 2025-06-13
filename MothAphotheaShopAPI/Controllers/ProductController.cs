using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MothAphotheaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Db _context;
        private readonly IMapper _mapper;

        public ProductController(Db context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
