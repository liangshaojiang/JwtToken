using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenDemo.Data
{
    public class SeeDatabase
    {

        public static void Initiailze(IServiceProvider serviceProvider) {
            var context = serviceProvider.GetRequiredService<JwtTokenDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>(); 
            context.Database.EnsureCreated();

            if (!context.Users.Any()) {
                User user = new User {
                    Email="abc@a.com",
                    SecurityStamp=Guid.NewGuid().ToString(),
                    UserName="Admin",
                };

                  var result= userManager.CreateAsync(user,"Password@123").Result;
            }

        }

    }
}
