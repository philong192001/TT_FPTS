using Jwt_Api_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt_Api_demo.Services
{
    public interface IAuthenticateServices
    {
        User Authentication(string userName, string password);
    }
}
