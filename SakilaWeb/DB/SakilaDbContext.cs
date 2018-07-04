using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SakilaWeb.DB.Models;
using SakilaWeb.Security;

namespace SakilaWeb.DB
{
    public class SakilaDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public SakilaDbContext(DbContextOptions options) :
        base(options){ }

        public DbSet<Film> Films { get; set; }
    }
}