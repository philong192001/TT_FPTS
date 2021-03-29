using Jwt_Api_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt_Api_demo.Interface
{
    public interface IUserRepository
    {
        Task<UsersJWT> Authenticate(string userName, string password);
        void Register(string userName, string password);

        Task<bool> UserAlreadyExists(string userName);
    }
}
