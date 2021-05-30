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
            if(ModelState.IsValid){
                if((await _userManager.FindByNameAsync(model.Username)) == null){
                    if(!model.MatchPasswords()){
                        ModelState.AddModelError("SignUp", "Las contraseñas no coinciden");
                        return View(model);
                    }
                    IdentityUser user = new IdentityUser{
                        Email = model.Email,
                        UserName = model.Username
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if(result.Succeeded)
                        return RedirectToAction("Index");
                    
                    ModelState.AddModelError("SignUp", string.Join(string.Empty, result.Errors.Select(error => error.Description)));
                    return View(model);
                }
                else ModelState.AddModelError("SignUp", "El nombre de usuario ya está en uso.");
            }
            return View(model);
        }
    }
}