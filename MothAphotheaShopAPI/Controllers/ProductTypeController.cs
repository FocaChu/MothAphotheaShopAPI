using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MothAphotheaShopAPI.Controllers;

namespace MothAphotheaShopAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : GenericController<ProductType, ProductTypeDTO>
    {
        public ProductTypeController(IGenericService<ProductType, ProductTypeDTO> service)
            : base(service)
        {
        }
    }
}
