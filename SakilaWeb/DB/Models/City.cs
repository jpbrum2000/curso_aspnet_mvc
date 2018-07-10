using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SakilaWeb.DB.Models {
    [Table("city")]
    public class City {
        [Key]
        [Column("city_id")]
        public int? Id {get;set;}
        [Column("city")]
        public string CityName {get;set;}
        [Column("country_id")]
        public string countryId {get;set;}
        [Column("last_update")]
        public string LastUpdate {get;set;}

        public virtual Country Country {get;set;}
    }
}