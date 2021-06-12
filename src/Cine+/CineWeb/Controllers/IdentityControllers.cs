using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.Identity;
using DomainLayer.Identity;

namespace CineWeb.Controllers{
    public partial class IdentityController : Controller
    {
        private CinemaUserFacade _cineUserManager;

        public IdentityController(IAuthorizeUser auth, IUserStore userStore)
        {
            this._cineUserManager = new CinemaUserFacade(auth, userStore);
        }
    }
}