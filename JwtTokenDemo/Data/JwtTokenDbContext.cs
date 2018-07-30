using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenDemo.Data
{
    public class JwtTokenDbContext:IdentityDbContext<User>
    {
        public JwtTokenDbContext(DbContextOptions<JwtTokenDbContext> options):base(options) {


        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
