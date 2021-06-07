using Microsoft.AspNetCore.Mvc;
using DomainLayer.Identity;
using System.Threading.Tasks;

namespace CineWeb.Controllers
{
    public partial class IdentityController : Controller
    {
        public IActionResult SignIn(){
            return View(new SignInModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if(ModelState.IsValid){
                var result = await _cineUserManager.Login(model);
                if (result.Succeeded)
                    return Redirect("Index");
                else ModelState.AddModelError("Login", "Acceso denegado.");
            }
            return View(model);
        }
    
    }
}