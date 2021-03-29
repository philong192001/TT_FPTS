using JsonWebToken.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonWebToken.Context
{
    public class JwtDbContext : DbContext
    {
        public JwtDbContext(DbContextOptions<JwtDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
    }
}
