using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SakilaWeb.DB;
using SakilaWeb.DB.Models;
using SakilaWeb.Service;
using Xunit;


namespace SakilaTest.Service
{
    public class FilmServiceTest {
        private string ConnectionString = "server=192.168.1.36;userid=root;pwd=1q2w3e4r;port=3306;database=sakila;sslmode=none;";

        [Fact]
        public void testListAll() {
            DbContextOptions options = MySqlDbContextOptionsExtensions.UseMySql(new DbContextOptionsBuilder(),ConnectionString).Options;
            SakilaDbContext ctx = new SakilaDbContext(options);
            IFilmService filmService = new FilmService(ctx);

            List<Film> filmsList = filmService.listAll();
            Assert.Equal(1000,filmsList.Count); 
        }
        [Fact]
        public void testFindById() {
            DbContextOptions options = MySqlDbContextOptionsExtensions.UseMySql(new DbContextOptionsBuilder(),ConnectionString).Options;
            SakilaDbContext ctx = new SakilaDbContext(options);
            IFilmService filmService = new FilmService(ctx);
            
            Film film = filmService.findById(83);
            Assert.Equal("BLUES INSTINCT", film.Title);
        }
        [Fact]
        public void testSaveOrUpdate_insercao(){
            DbContextOptions options = MySqlDbContextOptionsExtensions.UseMySql(new DbContextOptionsBuilder(),ConnectionString).Options;
            SakilaDbContext ctx = new SakilaDbContext(options);
            IFilmService filmService = new FilmService(ctx);
            
            Film film = new Film(){
                Title = "Filme Teste",
                Description = "Description",
                ReleaseYear = 2018
            };
            
            filmService.saveOrUpdate(film); 

            Assert.Equal(film, filmService.findById(1001));
            Assert.Equal(1001,filmService.listAll().Count);
        }
        [Fact]
        public void testSaveOrUpdate_atualizacao(){
            DbContextOptions options = MySqlDbContextOptionsExtensions.UseMySql(new DbContextOptionsBuilder(),ConnectionString).Options;
            SakilaDbContext ctx = new SakilaDbContext(options);
            IFilmService filmService = new FilmService(ctx);
            
            Film film = new Film(){
                Id = 2,
                Title = "Filme Teste2",
                Description = "Description2",
                ReleaseYear = 2019
            };
            
            filmService.saveOrUpdate(film); 
            Assert.Equal("Filme Teste2", filmService.findById(2).Title);
        }
        


    }
}