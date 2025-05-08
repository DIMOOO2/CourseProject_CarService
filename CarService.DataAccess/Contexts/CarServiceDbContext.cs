using CarService.DataAccess.Configurations;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CarService.DataAccess.Contexts
{
    public class CarServiceDbContext : DbContext
    {
        public CarServiceDbContext(DbContextOptions<CarServiceDbContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<AutoPartEntity>(new AutoPartConfiguration());
            modelBuilder.ApplyConfiguration<ClientEntity>(new ClientConfiguration());
            modelBuilder.ApplyConfiguration<CorporateAccountEntity>(new CorporateAccountConfiguration());
            modelBuilder.ApplyConfiguration<ManufacturerEntity>(new ManufacturerConfiguration());
            modelBuilder.ApplyConfiguration<OrderEntity>(new OrderConfiguration());
            modelBuilder.ApplyConfiguration<OrderPartEntity>(new OrderPartConfiguration());
            modelBuilder.ApplyConfiguration<OrganizationEntity>(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration<WarehouseEntity>(new WarehouseConfiguration());             
        }

        public DbSet<WarehouseEntity> Warehouses { get; set; }
        public DbSet<ManufacturerEntity> Manufacturers { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<CorporateAccountEntity> CorporateAccounts { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<AutoPartEntity> AutoParts { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderPartEntity> OrderParts { get; set; }
    }
}