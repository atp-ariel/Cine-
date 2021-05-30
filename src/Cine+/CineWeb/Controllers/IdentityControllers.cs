using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace CineWeb.Controllers{
    public partial class IdentityController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public IdentityController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
    }
}