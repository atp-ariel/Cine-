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
                if((await _userManager.FindByEmailAsync(model.Email)) != null){
                    IdentityUser user = new IdentityUser{
                        Email = model.Email,
                        UserName = model.Email
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if(result.Succeeded)
                        return RedirectToAction("Index");
                    
                    ModelState.AddModelError("SignUp", string.Join(string.Empty, result.Errors.Select(error => error.Description)));
                    return View(model);
                }
            }
            return View(model);
        }
    }
}