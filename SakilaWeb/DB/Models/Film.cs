using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SakilaWeb.DB.Models {
    [Table("film")]
    public class Film {
        [Key]
        [Column("film_id")]
        public int? Id {get;set;}
        [Column("title")]
        public string Title {get;set;}
        [Column("description")]
        public string Description {get;set;}
        [Column("release_year")]
        public int? RealeaseYear {get;set;}
    }
}