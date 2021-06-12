using Microsoft.AspNetCore.Mvc;
using DomainLayer.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;

namespace CineWeb.Controllers
{
    public partial class ClubCinePlusController : Controller
    {
        [Authorize(Roles = "BoxOfficer, Manager")]
        public IActionResult AddMembersClub(){
            return View(new SignUpModel());
        }


        [HttpPost]
        [Authorize(Roles = "BoxOfficer, Manager")]
        public async Task<IActionResult> AddMembersClub(SignUpModel model){
            // if there are no errors in the model from the view, then the user is created
            if(ModelState.IsValid){
                //if there is no user with that username then the same one is created
                if((await _cineUserManager.FindUserByUserName(model.Username)) == null){
                    // verify that the passwords match, if they don't match then the error is reported
                    if(!model.MatchPasswords()){
                        ModelState.AddModelError("SignUp", "Las contraseñas no coinciden");
                        return View(model);
                    }
                    
                    // create user
                    IdentityResult result = await _cineUserManager.SignUpUser(model, "Member");
                    
                    if(result.Succeeded)
                        return RedirectToAction("Index", "Home", null);
                    
                    ModelState.AddModelError("SignUp", string.Join(string.Empty, result.Errors.Select(error => error.Description)));
                    return View(model);
                }
                else ModelState.AddModelError("SignUp", "El nombre de usuario ya está en uso.");
            }
            return View(model);
        }
    }
}