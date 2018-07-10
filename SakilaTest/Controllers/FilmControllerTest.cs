using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SakilaWeb.Controllers;
using SakilaWeb.DB.Models;
using SakilaWeb.Service;
using SakilaWeb.ViewModel;
using Xunit;

namespace SakilaTest {
    public class FilmControllerTest {
        [Fact]
        public void testListAll(){
            Func<List<Film>> listAllMock = () => {
                List<Film> filmslist = new List<Film>();
                filmslist.Add(new Film(){Title = "Teste"});
                return filmslist;
            };

            var filmServiceMock = new Mock<IFilmService>();
            filmServiceMock.Setup(filmService => filmService.listAll()).Returns(listAllMock());
            var controller = new FilmController(filmServiceMock.Object);
            var result = controller.ListAll(null);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<FilmsListAllViewModel>(viewResult.ViewData.Model);
            Assert.Equal(1,model.FilmsList.Count);
        }

        [Fact]
        public void testCreateOrUpdate()
        {
            var filmServiceMock = new Mock<IFilmService>();
            filmServiceMock.Setup(filmService => filmService.saveOrUpdate(It.IsAny<Film>()));

            var controller = new FilmController(filmServiceMock.Object);
            var result = controller.CreateOrUpdate(new CreateOrUpdateFilmViewModel(){
                Film = new Film(){Title = "Teste"}
            });
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result); 
            Assert.Equal("ListAll",redirectToActionResult.ActionName);
        }
    }
}