using Xunit;
using DomainLayer.Identity;
using ServiceLayer.Identity;
using Microsoft.AspNetCore.Identity;
using Moq;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class TestingIdentity
    {
/*
        private UserManager<AppUser> GetMockUserManager()
        {
            //var store = new Mock<IUserPasswordStore<AppUser>>();
            //var mockUserManager = new UserManager<AppUser>(store.Object, null, null, null, null, null, null, null, null);
            //mockUserManager.UserValidators.Add(new UserValidator<AppUser>());
            //mockUserManager.PasswordValidators.Add(new PasswordValidator<AppUser>());
            

            /*mockUserManager.Setup(x => x.DeleteAsync(It.IsAny<AppUser>())).ReturnsAsync(IdentityResult.Success);
            mockUserManager.Setup(x => x.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            mockUserManager.Setup(x => x.UpdateAsync(It.IsAny<AppUser>())).ReturnsAsync(IdentityResult.Success);
            mockUserManager.Setup(x => x.FindByNameAsync(It.IsAny<string>()));
            mockUserManager.Setup(x => x.GetClaimsAsync(It.IsAny<AppUser>()));
            mockUserManager.Setup(x => x.RemoveClaimAsync(It.IsAny<AppUser>(), It.IsAny<Claim>())).ReturnsAsync(IdentityResult.Success);
            mockUserManager.Setup(x => x.AddToRoleAsync(It.IsAny<AppUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            mockUserManager.Setup(x => x.AddClaimAsync(It.IsAny<AppUser>(), It.IsAny<Claim>())).ReturnsAsync(IdentityResult.Success);
            
            return new UserManager<AppUser>(
                new UserStore<AppUser>(new AppIdentityContext(new DbContextOptions<AppIdentityContext>())), 
                null,
                new PasswordHasher<AppUser>(),
                new List<IUserValidator<AppUser>>() { new UserValidator<AppUser>() },
                new List<IPasswordValidator<AppUser>>() { new PasswordValidator<AppUser>() },
                null,
                null,
                null,
                null);
        }

        private SignInManager<AppUser> GetSignInManager()
        {
            var mockUserManager = GetMockUserManager();
            var contextAccesor = new Mock<IHttpContextAccessor>().Object;
            var userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<AppUser>>().Object;
            return new SignInManager<AppUser>(mockUserManager, contextAccesor, userPrincipalFactory, null, null, null);
        }
        [Fact]
        public async void TestCreatingUser()
        {
            var model = new SignUpModel() { 
                Username = "juanchito",
                Email = "juan@gmail.com",
                Password = "pedrito.Calv0",
                ConfirmedPassword = "pedrito.Calv0",
                Address = "Cerca de la plaza de la revolucion", 
                Phone = "5-523-22-22"
            };

            var userManager = GetMockUserManager();
            var signInManager = GetSignInManager();

            var facade = new CinemaUserFacade(new CinemaAuthorization(signInManager), new CinemaUsersStore(userManager));
            var result = await facade.SignUpUser(model, "Member");
            Assert.True(result.Succeeded);
        }*/
    }
}
