using Microsoft.EntityFrameworkCore;
using TalabaProMVC.Models;

namespace TalabaMVC.DBConatext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Talaba> talabas { get; set; }
    }
}
