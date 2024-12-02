using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pronia.Models;
using Pronio.Models;

namespace Pronia.DataAccess
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
