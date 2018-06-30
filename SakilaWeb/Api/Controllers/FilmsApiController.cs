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
        [HttpGet("{id}")]
        public Film findById(int id)
        {
            return filmService.findById(id);
        }
        [HttpPost]
        public IActionResult save([FromBody]Film film)
        {
            filmService.saveOrUpdate(film);
            return Ok();
        }
        [HttpPut]
        public IActionResult update([FromBody]Film film)
        {
            if (film.Id == null)
            {
                return BadRequest();
            }
            filmService.saveOrUpdate(film);
            return Ok();
        }
    }
}