using Idics.BUS;
using Idics.DAL;
using Idics.MOD;
using Idics.ULT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Idics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;
        private string _key => _configuration.GetValue<string>("AppSettings:SecretKey");
        public UserController(IConfiguration configuration, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _configuration = configuration;
            _appSettings = optionsMonitor.CurrentValue;

        }
        /*public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }*/

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] UserMOD item)
        {
            if (item == null) return BadRequest();
            var Result = new UserBUS().RegisterBUS(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpGet("DataUserLogin")]
        [Authorize]
        public IActionResult DataUserToken(int id)
        {
            var Result = new UserEntityBUS().ChiTiet(id);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginMOD login)
        {
            if (login == null) return BadRequest();
            var Result = new UserBUS().LoginBUS(login);
            List<Claim> claims = new List<Claim>();

            if (Result != null && Result.Status == 1)
            {
                claims.Add(new Claim("user_id", ((ListUserMOD)Result.Data).Id_user.ToString()));
                List<AuthorizeAttributeMOD> authorize = new UserDAL().getRole();
                foreach (var item in authorize)
                {
                    if (((ListUserMOD)Result.Data).Id_user == item.id_user)
                        claims.Add(new Claim(item.name_GroupUser.ToString(), item.role.ToString()));
                }
                var newResult = new
                {
                    Email = ((ListUserMOD)Result.Data).Email,
                    Password = ((ListUserMOD)Result.Data).Password,
                    name_GroupUser = ((ListUserMOD)Result.Data).name_GroupUser
                };

                Result.Data = newResult;

                return Ok(new
                {
                    Result,
                    Token = GenerateToken(claims),
                });
            }
            else
            {
                return Ok(new
                {
                    Result
                });
            }
            return NotFound();
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_key);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),

                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }

        [HttpGet("Email")]
        [Authorize]
        public IActionResult Email(string Email)
        {
            if (Email == null) return BadRequest();
            var Result = new UserBUS().Email(Email);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        [HttpGet]
        [Route("PhanQuyen")]
        public IActionResult DSPhanQuyen()
        {

            var Result = new UserBUS().ListPhanQuyen();

            List<Claim> claims = new List<Claim>();
            List<AuthorizeAttributeMOD> authorize = new UserDAL().getRole();
            foreach (var item in authorize)
            {
                claims.Add(new Claim(item.name_GroupUser.ToString(), item.role.ToString()));
            }

            var toke = GenerateToken(claims);

            return Ok(new
            {
                toke,
                Result
            });
        }

        // Quên mật khẩu 
        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(string Email, string IdCart)
        {
            if (Email == null && IdCart == null) return BadRequest();
            var Result = new UserBUS().ForgotPassword(Email, IdCart);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        // reseet mật khâủ
        [HttpPost]
        [Route("ResetMatKhau")]
        public IActionResult ResetMatKhau(string Email)
        {
            if (Email == null) return BadRequest();
            var Result = new UserBUS().ResetMatKhau(Email);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}
