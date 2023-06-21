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
    public class TransactionEntityController : ControllerBase
    {
        private readonly ILogger<TransactionEntityController> _logger;
        public TransactionEntityController(ILogger<TransactionEntityController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("DanhSach")]
        [ClaimRequirement("Admin", "1")]
        public IActionResult DanhSach([FromQuery] BasePagingParams p)
        {
            var TotalRow = 0;
            if (p == null) return BadRequest();
            var Result = new TransactionEntityBUS().DanhSach(p, ref TotalRow);
            Result.TotalRow = TotalRow;
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpPost]
        [Route("ThemMoi")]
        public IActionResult ThemMoi([FromBody] ADDTransactionEntityMOD item)
        {
            int Iduser = -1;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Iduser = Utils.ConvertToInt32(identity.FindFirst("user_id").Value, 0);
            item.id_user = Iduser;
            if (item == null) return BadRequest();
            var Result = new TransactionEntityBUS().ThemMoi(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search(string Time1, string Time2)
        {
            //if (Time == null) return BadRequest();
            var Result = new TransactionEntityBUS().Search(Time1, Time2);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpDelete]
        [Route("Xoa")]
        public IActionResult Xoa(int id_giaodich)
        {
            if (id_giaodich == null || id_giaodich < 1) return BadRequest();
            var Result = new TransactionEntityBUS().Xoa(id_giaodich);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}
