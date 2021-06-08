using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DomainLayer.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace CineWeb.Controllers
{
    public partial class IdentityController : Controller
    {
        public IActionResult SignUp(){
            SignUpModel model = new SignUpModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model){
            // if there are no errors in the model from the view, then the user is created
            if(ModelState.IsValid){
                //if there is no user with that username then the same one is created
                if((await _cineUserManager.FindByUsername(model.Username)) == null){
                    // verify that the passwords match, if they don't match then the error is reported
                    if(!model.MatchPasswords()){
                        ModelState.AddModelError("SignUp", "Las contraseñas no coinciden");
                        return View(model);
                    }
                    
                    // create user
                    IdentityResult result = await _cineUserManager.CreateUserAsync(model);
                    
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