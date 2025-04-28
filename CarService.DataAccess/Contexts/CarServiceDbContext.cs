using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Contexts
{
    public class CarServiceDbContext : DbContext
    {
        public CarServiceDbContext(DbContextOptions<CarServiceDbContext> options) 
            : base(options)
        {
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
