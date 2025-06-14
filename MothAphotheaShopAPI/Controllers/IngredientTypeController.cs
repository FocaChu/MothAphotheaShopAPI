using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MothAphotheaShopAPI.Controllers;

namespace MothAphotheaShopAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientTypeController : GenericController<IngredientType, IngredientTypeDTO>
    {
        public IngredientTypeController(IGenericService<IngredientType, IngredientTypeDTO> service)
            : base(service)
        {
        }
    }
}
