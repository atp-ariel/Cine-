using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DomainLayer.Identity;
using Moq;
using System.Collections.Generic;
using DomainLayer.Identity;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.HttpSys;
using RepositoryLayer.Identity;
using Microsoft.EntityFrameworkCore;

namespace TestProject5
{
    [TestClass]
    public class CinemaUserFacadeTest
    {
        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>(new AppIdentityContext(new DbContextOptions<AppIdentityContext>()));
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(X => X.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(X => X.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
            mgr.Setup(X => X.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            //mgr.Setup(X => X.FindByNameAsync(It.IsAny<string>())).Returns(Task<TUser>.FromResult(IdentityResult));

            return mgr;
        }

        private static List<AppUser> _users = new List<AppUser> { new AppUser { UserName = "user1", Email = "user1@gmail.com" }, new AppUser { UserName = "user2", Email = "user2@gmail.com" } };
        private static Mock<UserManager<AppUser>> _mockUserManager = MockUserManager<AppUser>(_users);
        private static UserManager<AppUser> _userManager = MockUserManager<AppUser>(_users).Object;

        //private Mock<SignInManager<AppUser>> GetMockSignInManager()
        //{
        //    var _user_store = new Mock<IUserStore<AppUser>>(new AppIdentityContext(new DbContextOptions<AppIdentityContext>()));
        //    var _mockUserManager = new Mock<AppUser>(new Mock<IUserStore<AppUser>>().Object, null, null, null, null, null, null, null, null);
        //    var contextAccesor = new Mock<IHttpContextAccessor>();
        //    var _userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<AppUser>>();

        //    Mock<SignInManager<AppUser>> mockAppsignmanager = new Mock<SignInManager<AppUser>>(_mockUserManager.Object, contextAccesor.Object, _userPrincipalFactory.Object, null, null, null);

        //    var mockUsrMgr = GetMockSignInManager();
        //    var mockAuthMgr = new Mock<AuthenticationManager>();
        //    return new Mock<SignInManager<AppUser>>(mockUsrMgr.Object, mockAuthMgr.Object);
        //}
        
        //private static Mock<SignInManager<TUser>> MockSingnInManager<TUser>(List<TUser> ls) where TUser : class
        //{
        //    var context = new Mock<HttpContext>();
        //    var manager = MockUserManager<TUser>(ls);
        //    return new Mock<SignInManager<TUser>>(manager.Object, new HttpContextAccessor { HttpContext = context.Object }, new Mock<IUserClaimsPrincipalFactory<TUser>>().Object, null, null) { CallBase = true };
        //}

        //private static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        //{
        //    IList<IUserValidator<TUser>> UserValidators = new List<IUserValidator<TUser>>();
        //    IList<IPasswordValidator<TUser>> PasswordValidators = new List<IPasswordValidator<TUser>>();

        //    var store = new Mock<IUserStore<TUser>>();
        //    UserValidators.Add(new UserValidator<TUser>());
        //    PasswordValidators.Add(new PasswordValidator<TUser>());
        //    var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, UserValidators, PasswordValidators, null, null, null, null, null);
        //    return mgr;
        //}

        //private static Mock<SignInManager<AppUser>> _signInManager = MockSingnInManager<AppUser>(_users);


        public async Task<string> CreateUser(AppUser user, string pasword) => (await _userManager.CreateAsync(user, pasword)).Succeeded ? user.Id : "";
        public async Task<AppUser> FindByName(string name) => (await _userManager.FindByNameAsync(name));

        [TestMethod]
        public async Task CreateAUser()
        {
            var _user_store = new CinemaUsersStore(_userManager);
            var new_user = new SignUpModel{ Username = "New_User", Password = "1234User#", ConfirmedPassword = "1234User#" , Phone = "1234567", Email = "newUser@gmail.com", Address = "1234"};
            var temp = _user_store.Users;
            if(_user_store.SignUp(new_user, "Member").IsCompleted)
            {
                var find_user = _user_store.FindByUsername("New_User");
                //Assert.IsTrue(find_user.IsCompleted);
                var a = 2;
                if (find_user.IsCompleted)
                {
                    Assert.AreEqual(find_user.Result.UserName, "New_User");
                }
            }
                
            


            //Assert.IsNotNull(_sign_up);
            //var find_user = _user_store.FindByUsername("New_User");
            //find_user;
            //var a = 5;
            //Assert.IsNotNull(find_user.Result);                 
            //Assert.AreEqual(find_user.UserName, "New_User");

        }

        //[TestMethod]
        //public async Task FindUserByName()
        //{
        //    //var _signInManager = GetMockSignInManager();
        //    //Mock<UserValidator<AppUser>> mockUsrMgr = GetMoc;
        //    //var cinema_user_autorization = new CinemaAuthorization(_signInManager.Object);
        //    //var cinema_user_store = new CinemaUsersStore(_mockUserManager.Object);
        //    //var cinema_user_facade = new CinemaUserFacade(cinema_user_autorization, cinema_user_store);

        //    //_signInManager.Setup(m => m.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), true, false));
        //    //var result = await cinema_user_facade.Login(new SignInModel() { Username = "User3", Password = "1234User#", RememberMe = true });
        //    var new_user = new AppUser { UserName = "NewUser1", Email = "newUser1@gmail.com" };
        //    var password = "1234User$";
        //    var result = await CreateUser(new_user, password);
        //    var user_store = new CinemaUsersStore(_userManager);
        //    var user_find = await user_store.FindByUsername("NewUser1");


        //    Assert.AreEqual(user_find.UserName, "NewUser1");
        //}
    }
}
