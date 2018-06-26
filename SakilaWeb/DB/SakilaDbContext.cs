using Microsoft.EntityFrameworkCore;
using SakilaWeb.DB.Models;

namespace SakilaWeb.DB
{
    public class SakilaDbContext : DbContext
    {
        public SakilaDbContext(DbContextOptions options) :
        base(options){ }

        public DbSet<Film> Films { get; set; }
    }
}