using CarService.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
            optionsBuilder.UseSqlServer("Server = DOTER; DataBase = CarServiceDB; Trusted_Connection = true; TrustServerCertificate = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderedPart>()
                .HasOne(o => o.DepartureWarehouse)
                .WithOne()
                .HasForeignKey<Warehouse>("DepartureWarehouseId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderedPart>()
                .HasOne(o => o.ArrivalWarehouse)
                .WithOne()
                .HasForeignKey<Warehouse>("ArrivalWarehouseId")
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<AutoPart> AutoParts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedPart> OrderedParts { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<CorporateAccount> CorporateAccounts { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}