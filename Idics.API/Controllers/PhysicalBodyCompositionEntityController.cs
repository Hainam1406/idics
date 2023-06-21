using Idics.BUS;
using Idics.MOD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Idics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicalBodyCompositionEntityController : ControllerBase
    {
        private readonly ILogger<PhysicalBodyCompositionEntityController> _logger;

        public PhysicalBodyCompositionEntityController(ILogger<PhysicalBodyCompositionEntityController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("DanhSach")]
        public IActionResult DanhSach([FromQuery] BasePagingParams p)
        {
            var TotalRow = 0;
            if (p == null) return BadRequest();
            var Result = new PhysicalBodyCompositionEntityBUS().DanhSach(p, ref TotalRow);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpPost]
        [Route("ThemMoi")]
        public IActionResult ThemMoi([FromQuery] AddPhysicalBodyCompositionEntityMOD item)
        {
            if (item == null) return BadRequest();
            var Result = new PhysicalBodyCompositionEntityBUS().ThemMoi(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpPut]
        [Route("CapNhap")]
        public IActionResult CapNhat([FromBody] UpdatePhysicalBodyCompositionEntityMOD item)
        {
            if (item == null) return BadRequest();
            var Result = new PhysicalBodyCompositionEntityBUS().CapNhap(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}
