using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SakilaWeb.DB.Models;
using SakilaWeb.Models;
using SakilaWeb.Service;

namespace SakilaWeb.Controllers {
    
    public class FilmController : Controller
    {
        private FilmService filmService;
        public FilmController(FilmService filmService){
            this.filmService = filmService;
        }
        public IActionResult Index(){
            var userModel = new FilmViewModel();
            return View(userModel);
        }

        [HttpPost]
        public IActionResult Index(FilmViewModel model){
            
            Film f = filmService.findById(int.Parse(model.codigo.ToString()));
            if (f == null){
                model.move = "Filme não Existe";
            } 
            else {
                model.move = f.Title;
            }            

            return View(model);
        }
        public IActionResult List() {
           
                List<Film> filmsList = filmService.listAll();
                return View(filmsList);
        }
    }
}