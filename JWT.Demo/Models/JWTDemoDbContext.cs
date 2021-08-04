using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT.Demo.Models
{
    public class JWTDemoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public JWTDemoDbContext(DbContextOptions<JWTDemoDbContext> options) : base(options)
        {

        }

    }
}
