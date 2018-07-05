using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SakilaWeb.Security;
using SakilaWeb.ViewModel;
using System.Linq;
using SakileWeb.ViewModel;

namespace SakilaWeb.Controllers {
    public class UsersController : Controller {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;
        private SignInManager<ApplicationUser> singInManager;
        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager) {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.singInManager = signInManager;
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

        public IActionResult AssignUserToRole() {
            ViewBag.UserList = userManager.Users.ToList();
            ViewBag.RoleList = roleManager.Roles.ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AssignUserToRole(AssignUserToRoleViewModel model) {
            ApplicationUser user = await userManager.FindByIdAsync(model.UserId);
            ApplicationRole role = await roleManager.FindByIdAsync(model.RoleId);

            await userManager.AddToRoleAsync(user,role.Name);

            return Ok();
        }

        public async Task<IActionResult> Login(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) {
            var result = await singInManager.PasswordSignInAsync(model.UserName,model.Password,true,false);
            if(result.Succeeded) {
                return RedirectToAction("ListAll","Film");
            }

            return View();
        }
        public async Task<IActionResult> Logoff(LoginViewModel model) {
            await singInManager.SignOutAsync();
            return RedirectToAction("ListAll","Film");
           
        }
       

    }
}