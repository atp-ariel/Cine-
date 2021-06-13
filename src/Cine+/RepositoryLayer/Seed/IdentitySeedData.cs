using DomainLayer.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Identity;
using System;
using System.Linq;

namespace RepositoryLayer.Seed
{
    public class IdentitySeedData: ISeed {

        #region Datas
        private (AppUser, string, string)[] users = new (AppUser, string, string)[]{
                (
                    instance: new AppUser(){
                        UserName = "Admin",
                        Email = "admin@example.com",
                        PhoneNumber = "5-555-1234",
                        Address = "Concepcion 177",
                    },
                    password: "Secret123$",
                    role: "Manager"
                ),
                (
                    instance: new AppUser(){
                        UserName = "Susy",
                        Email = "susannyvegacintra@gmail.com",
                        PhoneNumber = "5-510-9955",
                        Address = "Vista Alegre 110",
                    },
                    password: "1997.Hola.",
                    role: "BoxOfficer"
                ),
                (
                    instance: new AppUser()
                    {
                        UserName = "Ariel",
                        Email = "usich37@gmail.com",
                        PhoneNumber = "5-428-96-07",
                        Address = "San Lazaro 20",
                    },
                    password: "Happy.1199",
                    role:"Member"
                )
            };

        private IdentityRole[] roles = new[]
            {
                new IdentityRole{Name="Member"},
                new IdentityRole{Name="BoxOfficer"},
                new IdentityRole{Name="Manager"}
            };
        #endregion

        #region Seeds Methods
        private async void EnsurePopulatedUsers(UserManager<AppUser> userManager) {
            
            foreach (var user in users)
            {
                var tempUser = await userManager.FindByNameAsync(user.Item1.UserName);
                IdentityResult result;
                if (tempUser == null)
                    result = await userManager.CreateAsync(user.Item1, user.Item2);
            }
        }
        
        private async void EnsurePopulatedRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in roles)
                await roleManager.CreateAsync(role);
        }

        private async void EnsurePopulatedUserRoles(UserManager<AppUser> userManager)
        {
            foreach (var user in users)
                if ((await userManager.FindByNameAsync(user.Item1.UserName)) != null)
                    await userManager.AddToRoleAsync(user.Item1, user.Item3);
        }

        public void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppIdentityContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            UserManager<AppUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
            EnsurePopulatedUsers(userManager);
            EnsurePopulatedRoles(roleManager);
            EnsurePopulatedUserRoles(userManager);
        }
        #endregion
    }
}