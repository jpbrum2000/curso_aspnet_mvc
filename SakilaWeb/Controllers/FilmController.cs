using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SakilaWeb.DB.Models;
using SakilaWeb.Models;
using SakilaWeb.Service;
using SakilaWeb.ViewModel;
using SakilaWeb.DB;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "Admin")]
        public IActionResult CreateOrUpdate(int? updateId){
            if(updateId != null) {
                Film film = filmService.findById((int)updateId);
                return View(new CreateOrUpdateFilmViewModel(){ 
                    Film = film
                });
            } else {
                return View();
            }
        }

        [HttpPost]
        public IActionResult CreateOrUpdate(CreateOrUpdateFilmViewModel viewModel){
            if(viewModel != null && viewModel.Film != null) {
                filmService.saveOrUpdate(viewModel.Film);
                return RedirectToAction("ListAll");
            } else {
                return View();
            }
        }

        public IActionResult Delete(int? id) {
            if (id != null) {
                filmService.delete(id);
            }

            return RedirectToAction("ListAll");
        }

        public IActionResult GetFilmsTable() {
            List<Film> filmsList = filmService.listAll();
            Url.Action("GetFilmsTable","Film",null);
            return View(filmsList);
            
        }
    }
}