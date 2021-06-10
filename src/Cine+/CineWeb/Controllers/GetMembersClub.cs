using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace CineWeb.Controllers
{
    public partial class ClubCinePlusController : Controller
    {
        [Authorize(Roles = "BoxOfficer, Manager")]
        public async Task<IActionResult> GetMembersClub(){
            var members = await _cineUserManager.GetUsers("Member");
            return View(members);
        }
    }
}