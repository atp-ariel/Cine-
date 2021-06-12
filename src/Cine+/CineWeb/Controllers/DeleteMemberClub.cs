using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineWeb.Controllers
{
    public partial class ClubCinePlusController : Controller
    {
        [Authorize(Roles="Manager, BoxOfficer")]
        public async Task<IActionResult> DeleteMember(string username)
        {
            if (username == null)
                return NotFound();
            
            var resultDelete = await this._cineUserManager.DeleteUser(username);
            if (!resultDelete.Succeeded)
                return RedirectToAction("Error501", "Home");

            TempData["message"] = $"Se ha eliminado el socio '{username}' correctamente";
            return RedirectToAction("GetMembersClub", "ClubCinePlus");
        }

    }
}
