using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pronia.Models;
using Pronia.ViewModel.Auths;

namespace Pronia.Controllers
{
    public class AccountController(UserManager<User> userManager) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(UserCreateVM vm)
        {
            if(!ModelState.IsValid)
                return View();
            User user = new User
            {
                Email = vm.Email,
                Fullname = vm.Fullname,
                UserName = vm.Username,
                ProfileImageUrl = "photo.jpg"
            };
            var result = await userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
                return View();
            }
            return View();
        }
    }
}
