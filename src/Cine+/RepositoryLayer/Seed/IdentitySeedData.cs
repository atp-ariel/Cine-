using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RepositoryLayer.Identity;
using DomainLayer.Identity;
using System;

namespace RepositoryLayer.Seed
{
    public static class IdentitySeedData {
        public static async void EnsurePopulated(IApplicationBuilder app) {
            AppIdentityContext context =  app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppIdentityContext>();
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }
            Tuple<AppUser, string>[] users = new Tuple<AppUser, string>[]{
                Tuple.Create(
                    new AppUser(){
                        UserName = "Admin",
                        Email = "admin@example.com",
                        PhoneNumber = "5-555-1234",
                        Address = "Concepcion 177",
                    },
                    "Secret123$"
                ),
                Tuple.Create(
                    new AppUser(){
                        UserName = "Susy",
                        Email = "susannyvegacintra@gmail.com",
                        PhoneNumber = "5-510-9955",
                        Address = "Vista Alegre 110",
                    }, 
                    "1997.Hola."
                )
            };


            UserManager<AppUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            foreach (var user in users)
            {
                AppUser tempUser = await userManager.FindByNameAsync(user.Item1.UserName);
                if (tempUser == null)
                    await userManager.CreateAsync(user.Item1, user.Item2);
            }
        }
    }
}