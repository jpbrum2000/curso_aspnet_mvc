using System;
using System.Collections.Generic;
using SakilaWeb.DB;
using SakilaWeb.DB.Models;
using System.Linq;

namespace SakilaWeb.Service {
    public class FilmService : IFilmService {
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
            try {
                return dbContext.Films.ToList();
                //return (from f in dbContext.Films select f).ToList<Film>();
            }
            catch {
                return(new List<Film>());
            }
        }

        public Film findById(int? id) {
            return dbContext.Films.Find(id);
        }

        public void delete (int? id) {
            Film film = new Film {Id = id};
            dbContext.Remove(film);
            dbContext.SaveChanges();
        }
    }
}