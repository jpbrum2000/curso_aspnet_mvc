using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SakilaWeb.DB.Models;
using SakilaWeb.Models;

namespace SakilaWeb.Controllers {
    public class FilmController : Controller{
        public IActionResult Index(){
            var userModel = new FilmViewModel();
            return View(userModel);
        }

        [HttpPost]
        public IActionResult Index(FilmViewModel model){
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
        public IActionResult List() {
           
                Func<List<Film>> fakeList = () => 
                {
                    List<Film> list = new List<Film>();
                    list.Add(new Film()
                    {
                        Id = 1,
                        Title = "Vingadores"
                    });
                    list.Add(new Film (){
                        Id = 2,
                        Title = "Harry Potter"
                    });
                    return list;
                };
                List<Film> filmsList = fakeList();
                return View(filmsList);
        }
    }
}