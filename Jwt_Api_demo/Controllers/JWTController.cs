using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Jwt_Api_demo.Interface;
using Jwt_Api_demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Jwt_Api_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;
        public JWTController(IUnitOfWork uow, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.uow = uow;
        }
        // api/account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReq loginReq)
        {
            var user = await uow.UserRepository.Authenticate(loginReq.UserName, loginReq.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var loginRes = new LoginRes();
            loginRes.UserName = user.Username;
            loginRes.Token = CreateJWT(user);
            return Ok(loginRes);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(LoginReq loginReq)
        {
            if (await uow.UserRepository.UserAlreadyExists(loginReq.UserName))
                return BadRequest("User already exists, please try something else");

            uow.UserRepository.Register(loginReq.UserName, loginReq.Password);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        private string CreateJWT(UsersJWT user)
        {
            var secretKey = configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var signingCredentials = new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
