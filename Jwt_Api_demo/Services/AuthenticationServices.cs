using Jwt_Api_demo.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Jwt_Api_demo.Services
{
    public class AuthenticationServices : IAuthenticateServices
    {
        private readonly AppSettings _appSettings;
        public AuthenticationServices(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        private List<User> users = new List<User>()
        {
            new User{UserID = 1 ,FirstName = "Long",LastName="Phi",UserName="Phong",Password="12345"}
        };
        public User Authentication(string userName, string password)
        {
            var user = users.SingleOrDefault(x => x.UserName == userName && x.Password == password);

            //return null if user is not found
            if (user == null)
            {
                return null;
            }

            //If user is found 
            var tokenHandle = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            //var ki = Convert.ToInt32(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserID.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandle.CreateToken(tokenDescriptor);
            user.Token = tokenHandle.WriteToken(token);

            user.Password = null;   

            return user;
        }
        public User CheckUser(string tokenUser)
        {
            var token = users.SingleOrDefault(x => x.Token == tokenUser);

            if (token == null)
            {
                return null;
            }
                  
            return token;
        }
    }
}
