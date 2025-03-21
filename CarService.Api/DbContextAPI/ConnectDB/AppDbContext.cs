using Microsoft.EntityFrameworkCore;
using CarService.;


namespace CarService.Api.DbContextAPI.ConnectDB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = CarServiceDB;");
        }

        public DbSet<AutoPart> Autoparts;
    }
}
