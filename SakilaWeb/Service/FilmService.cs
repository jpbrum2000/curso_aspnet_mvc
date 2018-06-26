using System;
using System.Collections.Generic;
using SakilaWeb.DB;
using SakilaWeb.DB.Models;
using System.Linq;

namespace SakilaWeb.Service {
    public class FilmService {
        private SakilaDbContext dbContext;
        public FilmService(SakilaDbContext dbContext){
            this.dbContext = dbContext;
        }
        public void saveOrUpdate(Film film) {
            if (film.Id == null)
            {
                dbContext.Films.Add(film);
            } else {
                dbContext.Films.Update(film);
            }
            dbContext.SaveChanges();
        }
        
        public List<Film> listAll(){
            return (from f in dbContext.Films select f).ToList<Film>();
        }

        public Film findById(int id) {
            return (from f in dbContext.Films where f.Id == id select f).FirstOrDefault();
        }
    }
}