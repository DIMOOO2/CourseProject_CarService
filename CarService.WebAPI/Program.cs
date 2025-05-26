using CarService.ApplicationService.Services;
using CarService.Core.Abstractions;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using CarService.WebAPI;

namespace CarService.newWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<CarServiceDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(CarServiceDbContext)));
            });

            builder.Services.AddScoped<IWarehouseService, WarehouseService>();
            builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();

            builder.Services.AddScoped<IAutoPartService, AutoPartService>();
            builder.Services.AddScoped<IAutoPartRepository, AutoPartRepository>();

            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();

            builder.Services.AddScoped<ICorporateAccountService, CorporateAccountService>();
            builder.Services.AddScoped<ICorporateAccountRepository, CorporateAccountRepository>();

            builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
            builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();

            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<IOrderedPartService, OrderedPartService>();
            builder.Services.AddScoped<IOrderPartRepository, OrderPartRepository>();

            builder.Services.AddScoped<IOrganizationService, OrganizationService>();
            builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            
            builder.Services.AddScoped<IDeliveryReportService, DeliveryReportService>();
            builder.Services.AddScoped<IDeliveryReportRepository, DeliveryReportRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }      

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}