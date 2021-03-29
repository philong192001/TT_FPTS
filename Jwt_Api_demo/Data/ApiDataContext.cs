using Jwt_Api_demo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt_Api_demo.Data
{
    public class ApiDataContext : IdentityDbContext
    {
        public virtual DbSet<ItemData> Items { get; set; }

        public ApiDataContext(DbContextOptions<ApiDataContext> options)
            : base(options)
        {

        }
    }
}
