using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MothAphotheaShopAPI.Controllers;

namespace MothAphotheaShopAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContraindicationController : GenericController<Contraindication, ContraindicationDTO>
    {
        public ContraindicationController(IGenericService<Contraindication, ContraindicationDTO> service)
            : base(service)
        {
        }
    }
}
