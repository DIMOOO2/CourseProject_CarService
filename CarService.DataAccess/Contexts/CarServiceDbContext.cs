using CarService.DataAccess.Configurations;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace CarService.DataAccess.Contexts
{
    /// <summary>
    /// Класс контекста для подклчения к базе данных
    /// </summary>
    public class CarServiceDbContext : DbContext
    {
        /// <summary>
        /// Конструктор класса контекста
        /// </summary>
        /// <param name="options">Параметры контекста</param>
        public CarServiceDbContext(DbContextOptions<CarServiceDbContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Создание представления таблиц
        /// </summary>
        /// <param name="modelBuilder"></param>
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
            modelBuilder.ApplyConfiguration<DeliveryReportEntity>(new DeliveryReportConfiguration());             
        }

        /// <summary>
        /// Таблица складов
        /// </summary>
        public DbSet<WarehouseEntity> Warehouses { get; set; }

        /// <summary>
        /// Таблица производителей
        /// </summary>
        public DbSet<ManufacturerEntity> Manufacturers { get; set; }

        /// <summary>
        /// Таблица организаций
        /// </summary>
        public DbSet<OrganizationEntity> Organizations { get; set; }

        /// <summary>
        /// Таблица корпоративных аккаунтов
        /// </summary>
        public DbSet<CorporateAccountEntity> CorporateAccounts { get; set; }

        /// <summary>
        /// Таблица клиентов
        /// </summary>
        public DbSet<ClientEntity> Clients { get; set; }

        /// <summary>
        /// Таблица автозапчастей
        /// </summary>
        public DbSet<AutoPartEntity> AutoParts { get; set; }

        /// <summary>
        /// Таблица заказов
        /// </summary>
        public DbSet<OrderEntity> Orders { get; set; }

        /// <summary>
        /// Таблица запчастей в заказах
        /// </summary>
        public DbSet<OrderPartEntity> OrderParts { get; set; }

        /// <summary>
        /// Таблица отчетов по поставкам
        /// </summary>
        public DbSet<DeliveryReportEntity> DeliveryReports { get; set; }
    }
}