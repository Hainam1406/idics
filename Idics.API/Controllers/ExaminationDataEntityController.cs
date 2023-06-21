using Idics.BUS;
using Idics.MOD;
using Idics.ULT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Idics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationDataEntityController : ControllerBase
    {
        private readonly ILogger<ExaminationDataEntityController> _logger;

        public ExaminationDataEntityController(ILogger<ExaminationDataEntityController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("DanhSach")]
        [ClaimRequirement("User", "1")]
        public IActionResult DanhSach()
        {
            int userId = -1;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            userId = Utils.ConvertToInt32(identity.FindFirst("user_id").Value, 0);
            if (userId == null) return BadRequest();
            CheckMOD checkMod = new CheckMOD();
            checkMod.User_id = userId;
            var Result = new ExaminationDataEntityBUS().DanhSach(checkMod);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpGet]
        [Route("ChiTiet")]
        [ClaimRequirement("User", "1")]
        public IActionResult ChiTiet(int id)
        {
            if (id == null) return BadRequest();
            var Result = new ExaminationDataEntityBUS().ChiTiet(id);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpPost]
        [Route("ThemMoi")]

        public IActionResult ThemMoi([FromBody] AddExaminationDataEntityMOD item)
        {
            int userId = -1;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            userId = Utils.ConvertToInt32(identity.FindFirst("user_id").Value, 0);
            item.User_id = userId;
            if (item == null) return BadRequest();
            var Result = new ExaminationDataEntityBUS().ThemMoi(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpPut]
        [Route("CapNhap")]
        [ClaimRequirement("User", "1")]
        public IActionResult CapNhat([FromBody] UpdateExaminationDataEntityMOD item)
        {
            if (item == null) return BadRequest();
            var Result = new ExaminationDataEntityBUS().CapNhap(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpDelete]
        [Route("Xoa")]
        public IActionResult Xoa(int id)
        {
            if (id == null || id < 1) return BadRequest();
            var Result = new ExaminationDataEntityBUS().Xoa(id);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}
