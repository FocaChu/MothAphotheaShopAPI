using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MothAphotheaShopAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly Db _context;
        private readonly IMapper _mapper;

        public IngredientController(Db context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
