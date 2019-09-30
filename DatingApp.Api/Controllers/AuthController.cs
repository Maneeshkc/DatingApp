using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Api.Data;
using DatingApp.Api.Dto;
using DatingApp.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyDatingapp.Api.Model;

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authservice;

        public AuthController(IAuth authservice)
        {
            this._authservice = authservice;

        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDto userdto)
        {

            if (await _authservice.CheckUserName(userdto.UserName))
                return BadRequest("User Already exists");
            try
            {
                var user = new Tuser
                {
                    Name = userdto.UserName,
                    Password = userdto.Password
                };
                await _authservice.Register(user);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest("Error found" + ex.Message);
            }

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            
            var userFromDb = await _authservice.Login(login.UserName, login.Password);
            if (userFromDb == null)
                return Unauthorized("not authorized to view this page");

            var claims = new[]{
                    new Claim(ClaimTypes.NameIdentifier,userFromDb.Id.ToString()),
                    new Claim(ClaimTypes.Name,userFromDb.Name)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("maneeshkorothchamplone"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenhandler = new JwtSecurityTokenHandler();
            var token = tokenhandler.CreateToken(descriptor);

            return Ok(new { token = tokenhandler.WriteToken(token) });

        }

    }
}