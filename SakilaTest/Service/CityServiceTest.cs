using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SakilaWeb.DB;
using SakilaWeb.DB.Models;
using SakilaWeb.Service;
using Xunit;

namespace SakilaTest.Service {
    public class CityServiceTest {

        private string ConnectionString = "server=192.168.1.36;userid=root;pwd=1q2w3e4r;port=3306;database=sakila;sslmode=none;";
        private ICityService getCityService()
        {
            DbContextOptions options = MySqlDbContextOptionsExtensions.UseMySql(new DbContextOptionsBuilder(), ConnectionString).Options;
            SakilaDbContext ctx = new SakilaDbContext(options);
            ICityService cityService = new CityService(ctx);

            return cityService;
        }
        
        [Fact]
        public void testListByCountryName() {
            string countryName = "India";
            int expectedNumberOfCities = 60;
            ICityService cityService = getCityService();
            List<City> citiesList = cityService.listByCountryName(countryName);

            Assert.Equal(expectedNumberOfCities,citiesList.Count);
        }
    }
}