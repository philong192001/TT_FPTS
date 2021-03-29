using Jwt_Api_demo.Interface;
using Jwt_Api_demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt_Api_demo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }

        public IUserRepository UserRepository =>
            new UserRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
