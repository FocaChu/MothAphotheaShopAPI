using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MothAphotheaShopAPI.Controllers;

namespace MothAphotheaShopAPI
{
    [Route("api/[controller]")]
    public class ActiveCompoundController : GenericController<ActiveCompound, ActiveCompoundDTO>
    {
        public ActiveCompoundController(IGenericService<ActiveCompound, ActiveCompoundDTO> service)
            : base(service)
        {
        }
    }

}
