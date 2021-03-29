using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt_Api_demo.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task<bool> SaveAsync();
    }
}
