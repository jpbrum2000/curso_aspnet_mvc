using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SakilaWeb.DB.Models;
using SakilaWeb.Models;
using SakilaWeb.Service;
using SakilaWeb.ViewModel;
using SakilaWeb.DB;

namespace SakilaWeb.Controllers
{

    public class FilmController : Controller
    {
        private FilmService filmService;
        public FilmController(FilmService filmService)
        {
            this.filmService = filmService;
        }
        public IActionResult Index()
        {
            var userModel = new FilmViewModel();
            return View(userModel);
        }

        [HttpPost]
        public IActionResult Index(FilmViewModel model)
        {
            Film f = filmService.findById(model.codigo);
            model.move = (f is null) ? "Filme não Existe" : f.Title;
            return View(model);
        }
        public IActionResult List()
        {
            List<Film> filmsList = filmService.listAll();
            return View(filmsList);
        }

        public IActionResult ListAll(FilmsListAllViewModel viewModel) {
            
            List<Film> filmsList = null;
            
            if(viewModel != null && viewModel.SearchId != null){
                filmsList = new List<Film>();
                filmsList.Add(filmService.findById((int)viewModel.SearchId));
            }else{
                filmsList = filmService.listAll();
            }

            viewModel.FilmsList = filmsList;
            return View(viewModel);
        }

        public IActionResult CreateOrUpdate(CreateOrUpdateFilmViewModel viewModel){
            return View();
        }
    }
}