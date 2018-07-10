using System.Collections.Generic;
using SakilaWeb.DB;
using SakilaWeb.DB.Models;

namespace SakilaWeb.Service {
    public class CountryService {
        private SakilaDbContext dbContext;

        public void ContryService(SakilaDbContext dbcontext) {
            this.dbContext = dbcontext;
        }

        public List<City> findCities(string countryname){
            return (from city in dbContext.Cities select CityName).where(where Country = countryname) .ToList<City>();
        }
    }
}