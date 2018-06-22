using Microsoft.AspNetCore.Mvc;
using SakilaWeb.ViewModel;

namespace SakilaWeb.Controllers {

    public class CalcController : Controller {
        public IActionResult Index() {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CalcViewModel model) {
            switch (model.Operation) {
                case "SUM": model.Result = model.N1 + model.N2;
                break;
                case "SUBTRACT": model.Result = model.N1 - model.N2;
                break;
                case "MULTIPLY": model.Result = model.N1 * model.N2;
                break;
                case "DIVIDE": model.Result = model.N1 / model.N2;
                break;
            }
            return View(model);
        }
    }
}