using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SakilaWeb.DB.Models;
using SakilaWeb.Service;

namespace SakilaWeb.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Films")]
    public class FilmsApiController : Controller
    {
        private FilmService filmService;
        public FilmsApiController(FilmService filmService) { this.filmService = filmService; }
        [HttpGet]
        public List<Film> listAll() => filmService.listAll();
    }
}