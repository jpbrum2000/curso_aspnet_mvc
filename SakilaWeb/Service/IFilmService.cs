using System.Collections.Generic;
using SakilaWeb.DB.Models;

namespace SakilaWeb.Service {
    public interface IFilmService {
        List<Film> listAll();

        void saveOrUpdate(Film film);

        Film findById(int? id);

        void delete (int? id);
    }
}