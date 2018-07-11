using Microsoft.AspNetCore.Mvc;

namespace SakilaWeb.Area2.Controllers {
    [Area("Area2")]
    public class HomeController: Controller {
        public IActionResult Index() {
            return View();
        }
    }
}