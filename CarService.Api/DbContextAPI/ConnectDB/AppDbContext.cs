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
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; DataBase = CarServiceDB; Trusted_Connection = true; TrustServerCertificate = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutoPart>().HasKey(u => u.AutoPartId);
            modelBuilder.Entity<Client>().HasKey(u => u.ClientId);
            modelBuilder.Entity<Manufacturer>().HasKey(u => u.ManufacturerId);
            modelBuilder.Entity<Order>().HasKey(u => u.OrderId);
            modelBuilder.Entity<OrderedPart>().HasKey(u => u.OrderedPartId);
            modelBuilder.Entity<Warehouse>().HasKey(u => u.WarehouseId);
            modelBuilder.Entity<CorporateAccount>().HasKey(u => u.AccountId);
            modelBuilder.Entity<Organization>().HasKey(u => u.OrganizationId);
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