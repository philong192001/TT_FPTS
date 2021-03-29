using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jwt_Api_demo.Models;
using Jwt_Api_demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Api_demo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateServices _authenticateServices;
        public AuthenticationController(IAuthenticateServices authenticateServices)
        {
            _authenticateServices = authenticateServices;
        }
        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            var user = _authenticateServices.Authentication(model.UserName, model.Password);
            if(user == null)
            {
                return BadRequest(new
                {
                    message = "USerName and Password incorrect , Try Again Data"
                });
            }
            return Ok(user);
        }
    }
}
