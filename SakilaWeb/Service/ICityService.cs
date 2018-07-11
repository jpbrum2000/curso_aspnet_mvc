using System.Collections.Generic;
using SakilaWeb.DB.Models;

namespace SakilaWeb.Service {
    public interface ICityService {
        List<City> listByCountryName(string countryName);
    }
}