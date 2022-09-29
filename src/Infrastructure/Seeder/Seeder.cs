using Core.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Seeder;

 
    public class DataSeeder 
    {
        
        public static async Task SeedAsync(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<DataSeeder>>();
                
            string userName = "vicosoft4real@gmail.com";

            if (!await userManager.Users.AnyAsync(x => Equals(x.UserName, userName)))
            {
                logger.LogInformation("Generating inbuilt accounts for super admin user");
                var user = await userManager.CreateAsync(new User
                {
                    Email = "vicosoft4real@gmail.com",
                    PhoneNumber = "08060956363",
                    UserName = userName,

                }, "P@ssw0rd123");
 
                    
               if(user is { Succeeded: true })
                logger.LogInformation("Inbuilt super admin account generation completed");
            }
        }

 

    }

