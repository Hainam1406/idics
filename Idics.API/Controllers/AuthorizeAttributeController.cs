using Idics.BUS;
using Idics.DAL;
using Idics.MOD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Idics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeAttributeController : ControllerBase
    {
        private readonly ILogger<AuthorizeAttributeController> _logger;
        public AuthorizeAttributeController (ILogger<AuthorizeAttributeController> logger)
        {
            _logger = logger;       
        }

        //[HttpGet]
        //[Route("PhanQuyen")]
        //public IActionResult PhanQuyen(int id_GroupUser)
        //{
        //    if (id_GroupUser == null) return BadRequest();
        //    var Result = new AuthorizeAttributeBUS().PhanQuyen(id_GroupUser);
        //    if (Result != null) return Ok(Result);
        //    else return NotFound();
        //}

        [HttpGet]
        [Route("PhanQuyen")]
        public IActionResult PhanQuyen()
        {
            var Result = new AuthorizeAttributeBUS().PhanQuyen();
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}
