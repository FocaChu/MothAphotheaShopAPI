using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MothAphotheaShopAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly Db _context;
        private readonly IMapper _mapper;

        public ProductTypeController(Db context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
