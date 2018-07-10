using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SakilaWeb.DB.Models {
    [Table("country")]
    public class Country {
        [Key]
        [Column("country_id")]
        public int? Id {get;set;}
        [Column("country")]
        public string CountryName {get;set;}
        [Column("last_update")]
        public string LastUpdate {get;set;}
    }
}