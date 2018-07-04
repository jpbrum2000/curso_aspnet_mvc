using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SakilaWeb.Security;
using SakilaWeb.ViewModel;

namespace SakilaWeb.Controllers {
    public class UsersController : Controller {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;
        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Register(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel model) {
            ApplicationUser user = new ApplicationUser(){
                Email = model.Email,
                UserName = model.Email
            };
            var result = await userManager.CreateAsync(user,model.Password);
            return View();
        }

        public async Task<IActionResult> RegisterRole(string Name) {
            ApplicationRole role = new ApplicationRole(){
                Name = Name
            };
            var result = await roleManager.CreateAsync(role);
            return RedirectToAction("Register");
        }
    }
}