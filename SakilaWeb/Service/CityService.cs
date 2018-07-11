using System.Collections.Generic;
using SakilaWeb.DB;
using SakilaWeb.DB.Models;
using System.Linq;

namespace SakilaWeb.Service
{
    public class CityService : ICityService
    {
        private SakilaDbContext ctx;

        public CityService(SakilaDbContext ctx)
        {
            this.ctx = ctx;
        }
        public List<City> listByCountryName(string countryName)
        {
            return (from c in ctx.Cities
                    where c.Country.CountryName == countryName
                    select c).ToList<City>();
        }
    }
}