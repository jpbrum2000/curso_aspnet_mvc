using Microsoft.AspNetCore.Mvc;

namespace SakilaWeb.Controllers {

    public class HelloController : Controller {
        public IActionResult HelloWorld () {
            return View();
        }
    }
}