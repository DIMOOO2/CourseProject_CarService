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
    }
}
