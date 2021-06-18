using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DomainLayer.Identity;
using ServiceLayer.Identity;

namespace CineWeb.Controllers
{
    public partial class ClubCinePlusController : Controller
    {
        private CinemaUserFacade _cineUserManager;

        public ClubCinePlusController(IAuthorizeUser authorizeUser, IUserStore userStore)
        {
            this._cineUserManager = new CinemaUserFacade(authorizeUser, userStore);
        }

        
    }
}