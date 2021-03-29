using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JsonWebToken.Context;
using JsonWebToken.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JsonWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly JwtDbContext _context;
        public TokenController(IConfiguration configuration, JwtDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserInfo userInfo)
        {
            if(userInfo != null && userInfo.UserName != null && userInfo.Password != null)
            {
                var user = await GetUser(userInfo.UserName, userInfo.Password);
                if(user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim ("Id",user.Id.ToString()),
                        new Claim("UserName",user.UserName),
                        new Claim("Password",user.Password)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                       _configuration["Jwt:Issuer"],
                       _configuration["Jwt:Audience"],
                       claims,
                       expires: DateTime.Now.AddMinutes(20),
                       signingCredentials: signIn
                    );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest("Xem lai API ddi b eii co token chua");
            }
        }
        [HttpGet]
        public async Task<UserInfo> GetUser(string userName,string pass)
        {                                                       
            return await _context.UserInfo.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == pass);
        }
    }
}
