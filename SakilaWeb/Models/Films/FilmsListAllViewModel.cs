using System.Collections.Generic;
using SakilaWeb.DB.Models;

namespace SakilaWeb.ViewModel{

    public class FilmsListAllViewModel{

        public int? SearchId {get;set;}

        public List<Film> FilmsList {get;set;}
    }
}