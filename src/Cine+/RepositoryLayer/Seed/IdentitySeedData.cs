using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RepositoryLayer.Identity;
using System;
namespace RepositoryLayer.Seed
{
    public static class IdentitySeedData {
        public static async void EnsurePopulated(IApplicationBuilder app) {
            AppIdentityContext context =  app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppIdentityContext>();
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }
            Tuple<IdentityUser, string>[] users = new Tuple<IdentityUser, string>[]{
                Tuple.Create(
                    new IdentityUser("Admin"){
                        Email = "admin@example.com",
                        PhoneNumber = "5-555-1234",
                    },
                    "Secret123$"
                ),
                Tuple.Create(
                    new IdentityUser("Susy"){
                        Email = "susannyvegacintra@gmail.com",
                        PhoneNumber = "5-510-9955"
                    }, 
                    "1997.Hola."
                )
            };


            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            foreach (var user in users)
            {
                IdentityUser tempUser = await userManager.FindByNameAsync(user.Item1.UserName);
                if (tempUser == null)
                    await userManager.CreateAsync(user.Item1, user.Item2);
            }
        }
    }
}