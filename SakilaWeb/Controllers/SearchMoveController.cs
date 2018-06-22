using Microsoft.AspNetCore.Mvc;
using SakilaWeb.Models;

namespace SakilaWeb.Controllers{
    public class SearchMoveController : Controller{
        public IActionResult Index(){
            return View();
        }

        [HttpPost]
        public IActionResult Index(SearchMoveViewModel model){
            switch(model.codigo) {
                case 1: model.move = "Vingadores";
                break;
                case 2: model.move = "Harry Potter";
                break;
                case 3: model.move = "Logan";
                break;
                default: model.move = "Filme não Existe";
                break;
            } 
            return View(model);
        }
    }
}