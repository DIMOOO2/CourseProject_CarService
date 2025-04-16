using CarService.Api.DbContextAPI.ConnectDB;
using CarService.Api.Services;
using CarService.Models.Entities;

namespace CarService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDbContext appDbContext = new AppDbContext();
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            #region GET-Запросы
            app.MapGet("/autoParts", () => appDbContext.AutoParts);
            app.MapGet("/clients", () => appDbContext.Clients);
            app.MapGet("/manufacturers", () => appDbContext.Manufacturers);
            app.MapGet("/orders", () => appDbContext.Orders);
            app.MapGet("/orderParts", () => appDbContext.OrderedParts);
            app.MapGet("/accounts", () => appDbContext.CorporateAccounts);
            app.MapGet("/organizations", () => appDbContext.Organizations);
            app.MapGet("/warehouses", () => appDbContext.Warehouses);
            #endregion 
            #region POST-Запросы
            app.MapPost("/autoParts", (AutoPart autoPart) =>
            {
                autoPart.AutoPartId = Guid.NewGuid();
                appDbContext.AutoParts.Add(autoPart);
                appDbContext.SaveChangesAsync();
            });

            app.MapPost("/clients", (Client client) =>
            {
                ClientService.AddClient(client).GetAwaiter();
            });

            app.MapPost("/manufacturers", (Manufacturer manufacturer) =>
            {
                manufacturer.ManufacturerId = Guid.NewGuid();
                appDbContext.Manufacturers.Add(manufacturer);
                appDbContext.SaveChangesAsync();
            });

            app.MapPost("/orders", (Order order) =>
            {
                order.OrderId = Guid.NewGuid();
                appDbContext.Orders.Add(order);
                appDbContext.SaveChangesAsync();
            });

            app.MapPost("/orderParts", (OrderedPart orderPart) =>
            {
                orderPart.OrderedPartId = Guid.NewGuid();
                appDbContext.OrderedParts.Add(orderPart);
                appDbContext.SaveChangesAsync();
            });

            app.MapPost("/accounts", (CorporateAccount corporateAccount) =>
            {
                corporateAccount.AccountId = Guid.NewGuid();
                appDbContext.CorporateAccounts.Add(corporateAccount);
                appDbContext.SaveChangesAsync();
            });
            
            app.MapPost("/organizations", (Organization organization) =>
            {
                organization.OrganizationId = Guid.NewGuid();
                appDbContext.Organizations.Add(organization);
                appDbContext.SaveChangesAsync();
            });
            
            app.MapPost("/warehouses", (Warehouse warehouse) =>
            {
                warehouse.WarehouseId = Guid.NewGuid();
                appDbContext.Warehouses.Add(warehouse);
                appDbContext.SaveChangesAsync();
            });
            #endregion
            #region DELETE-Запросы
            app.MapDelete("/autoParts", (Guid id) =>
            {
                appDbContext.AutoParts.Remove(appDbContext.AutoParts.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/clients", (Guid id) =>
            {
                ClientService.DeleteClient(id).GetAwaiter();
            });

            app.MapDelete("/manufacturers", (Guid id) =>
            {
                appDbContext.Manufacturers.Remove(appDbContext.Manufacturers.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/orders", (Guid id) =>
            {
                appDbContext.Orders.Remove(appDbContext.Orders.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/orderParts", (Guid id) =>
            {
                appDbContext.OrderedParts.Remove(appDbContext.OrderedParts.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/accounts", (Guid id) =>
            {
                appDbContext.CorporateAccounts.Remove(appDbContext.CorporateAccounts.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/organizations", (Guid id) =>
            {
                appDbContext.Organizations.Remove(appDbContext.Organizations.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/warehouses", (Guid id) =>
            {
                appDbContext.Warehouses.Remove(appDbContext.Warehouses.Find(id)!);
                appDbContext.SaveChangesAsync();
            });
            #endregion
            #region PUT-Запросы
            app.MapPut("/autoParts", (AutoPart newAutopart) =>
            {
                AutoPart autopart = appDbContext.AutoParts.Find(newAutopart)!;
                autopart.AutoPartName = newAutopart.AutoPartName;
                autopart.Manufacturer = newAutopart.Manufacturer;
                autopart.PartNumber = newAutopart.PartNumber;
                autopart.Price = newAutopart.Price;
                autopart.StockAmount = newAutopart.StockAmount;

                appDbContext.AutoParts.Update(newAutopart);
                appDbContext.SaveChangesAsync();
            });
            app.MapPut("/clients", (Guid id, Client newClient) =>
            {
                ClientService.UpdateClient(id, newClient).GetAwaiter();
            });
            app.MapPut("/manufacturers", (Manufacturer newManufacturer) =>
            {
                Manufacturer oldManufacturer = appDbContext.Manufacturers.Find(newManufacturer)!;
                oldManufacturer.ManufacturerName = newManufacturer.ManufacturerName;
                oldManufacturer.ContactInfo = newManufacturer.ContactInfo;

                appDbContext.Update(oldManufacturer);
                appDbContext.SaveChangesAsync();
            });
            app.MapPut("/orders", (Order newOrder) =>
            {
                Order oldOrder = appDbContext.Orders.Find(newOrder)!;
                oldOrder.OrderDate = newOrder.OrderDate;
                oldOrder.Client = newOrder.Client;
                oldOrder.OrderStatus = newOrder.OrderStatus;

                appDbContext.Update(oldOrder);
                appDbContext.SaveChangesAsync();
            });
            app.MapPut("/orderParts", ( OrderedPart newPart) =>
            {
                OrderedPart oldPart = appDbContext.OrderedParts.Find(newPart)!;
                oldPart.Order = newPart.Order;
                oldPart.AutoPart = newPart.AutoPart;
                oldPart.Amount = newPart.Amount;

                appDbContext.Update(oldPart);
                appDbContext.SaveChangesAsync();
            });
            #endregion
            app.Run();
        }
    }
}