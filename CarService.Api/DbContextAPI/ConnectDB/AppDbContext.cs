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
            modelBuilder.Entity<AutoPart>(b =>
            {
                b.Property(b => b.AutoPartId).ValueGeneratedOnAdd();
            });
            
            modelBuilder.Entity<Client>(b =>
            {
                b.Property(b => b.ClientId).ValueGeneratedOnAdd();
            });
            
            modelBuilder.Entity<CorporateAccount>(b =>
            {
                b.Property(b => b.AccountId).ValueGeneratedOnAdd();
            });
            
            modelBuilder.Entity<Manufacturer>(b =>
            {
                b.Property(b => b.ManufacturerId).ValueGeneratedOnAdd();
            });
            
            modelBuilder.Entity<Order>(b =>
            {
                b.Property(b => b.OrderId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<OrderedPart>(b =>
            {
                b.Property(b => b.OrderedPartId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<OrderedPart>()
                .HasOne(b => b.DepartureWarehouse)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderedPart>()
                .HasOne(b => b.ArrivalWarehouse)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Organization>(b =>
            {
                b.Property(b => b.OrganizationId).ValueGeneratedOnAdd();
            }).Entity<Organization>().HasKey(k => new { k.OrganizationId, k.TIN });

            
            modelBuilder.Entity<Warehouse>(b =>
            {
                b.Property(b => b.WarehouseId).ValueGeneratedOnAdd();
            });
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