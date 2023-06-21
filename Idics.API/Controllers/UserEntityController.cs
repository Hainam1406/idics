using Idics.BUS;
using Idics.DAL;
using Idics.MOD;
using Idics.ULT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Data;

namespace Idics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEntityController : ControllerBase
    {
        private readonly ILogger<UserEntityController> _logger;

        public UserEntityController(ILogger<UserEntityController> logger)
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
            var Result = new UserEntityBUS().DanhSach(p, ref TotalRow);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpGet]
        [Route("ChiTiet")]
        public IActionResult ChiTiet(int Id_user)
        {
            if (Id_user == null) return BadRequest();
            var Result = new UserEntityBUS().ChiTiet(Id_user);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpPost]
        [Route("ThemMoi")]
        [ClaimRequirement("Admin", "15")]
        public IActionResult ThemMoi([FromBody] AddUserEntityMOD item)
        {
            if (item == null) return BadRequest();
            var Result = new UserEntityBUS().ThemMoi(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpPut]
        [Route("CapNhap")]
        [ClaimRequirement("Admin", "15")]
        public IActionResult CapNhat([FromBody] UpdateUserEntityMOD item)
        {
            if (item == null) return BadRequest();
            var Result = new UserEntityBUS().CapNhap(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpPut]
        [Route("CapNhapNguoiDung")]
        [ClaimRequirement("User", "5")]
        public IActionResult CapNhatUser([FromBody] UpdateUserEntityMOD item)
        {
            if (item == null) return BadRequest();
            var Result = new UserEntityBUS().CapNhap(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpDelete]
        [Route("Xoa")]
        [ClaimRequirement("Admin", "15")]
        public IActionResult Xoa(int Id_user)
        {
            if (Id_user == null || Id_user < 1) return BadRequest();
            var Result = new UserEntityBUS().Xoa(Id_user);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search([FromBody] string Email)
        {
            if (Email == null) return BadRequest();
            var Result = new UserEntityBUS().Search(Email);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpPost]
        [Route("SearchSex")]
        public IActionResult SearchSex([FromBody] string Sex)
        {
            if (Sex == null) return BadRequest();
            var Result = new UserEntityBUS().SearchSex(Sex);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpPost]
        [Route("ResetMatKhau")]
        public IActionResult ResetMatKhau(string Email, string Password)
        {
            if (Email == null) return BadRequest();
            var Result = new UserEntityBUS().ResetMatKhau(Email, Password);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpGet]
        [Route("Excel")]
        public IActionResult DanhSachEx()
        {

            var stream = new MemoryStream();
            using var package = new ExcelPackage(stream);

            var sheet = package.Workbook.Worksheets.Add("Loai");
            // cho data vao
            sheet.Cells.LoadFromCollection(new UserEntityDAL().ListUser(), true);
            package.Save();


            stream.Position = 0;
            var FileName = $"Loai_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            return File(stream,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", FileName);
        }
    }
}
