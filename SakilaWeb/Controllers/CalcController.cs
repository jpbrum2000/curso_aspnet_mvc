using Microsoft.AspNetCore.Mvc;

namespace SakilaWeb.Controllers {

    public class CalcController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}