using CarService.Api.DbContextAPI.ConnectDB;
using CarService.Api.Services;
using CarService.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
            app.MapGet("/api/autoParts", () => appDbContext.AutoParts
            .Include(m => m.Manufacturer)
            .Include(w => w.Warehouse));

            app.MapGet("/api/clients", () => appDbContext.Clients
            .Include(o => o.Organization));

            app.MapGet("/api/manufacturers", () => appDbContext.Manufacturers);

            app.MapGet("/api/orders", () => appDbContext.Orders
            .Include(c => c.Client));

            app.MapGet("/api/orderParts", () => appDbContext.OrderedParts
            .Include(o => o.Order)
            .Include(a => a.AutoPart)
            .Include(dw => dw.DepartureWarehouse)
            .Include(aw => aw.ArrivalWarehouse));

            app.MapGet("/api/accounts", () => appDbContext.CorporateAccounts
            .Include(w => w.Warehouse));

            app.MapGet("/api/organizations", () => appDbContext.Organizations);

            app.MapGet("/api/warehouses", () => appDbContext.Warehouses);

            #endregion 
            #region POST-Запросы
            app.MapPost("/api/autoParts", (AutoPart autoPart) =>
            {
                appDbContext.AutoParts.Add(autoPart);
                appDbContext.SaveChangesAsync();
            });

            app.MapPost("/api/clients", (Client client) =>
            {
                ClientService.AddClient(client).GetAwaiter();
                return client;
            });

            app.MapPost("/api/manufacturers", (Manufacturer manufacturer) =>
            {
                appDbContext.Manufacturers.Add(manufacturer);
                appDbContext.SaveChangesAsync();
            });

            app.MapPost("/api/orders", (Order order) =>
            {
                appDbContext.Orders.Add(order);
                appDbContext.SaveChangesAsync();
                return order;
            });

            app.MapPost("/api/orderParts", (OrderedPart orderPart) =>
            {
                appDbContext.OrderedParts.Add(orderPart);
                appDbContext.SaveChangesAsync();
                return orderPart;
            });

            app.MapPost("/api/accounts", (CorporateAccount corporateAccount) =>
            {
                appDbContext.CorporateAccounts.Add(corporateAccount);
                appDbContext.SaveChangesAsync();
            });
            
            app.MapPost("/api/organizations", (Organization organization) =>
            {
                appDbContext.Organizations.Add(organization);
                appDbContext.SaveChangesAsync();
                return organization;
            });
            
            app.MapPost("/api/warehouses", (Warehouse warehouse) =>
            {
                appDbContext.Warehouses.Add(warehouse);
                appDbContext.SaveChangesAsync();
            });
            #endregion
            #region DELETE-Запросы
            app.MapDelete("/api/autoParts", (long id) =>
            {
                appDbContext.AutoParts.Remove(appDbContext.AutoParts.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/api/clients", (long id) =>
            {
                ClientService.DeleteClient(id).GetAwaiter();
            });

            app.MapDelete("/api/manufacturers", (long id) =>
            {
                appDbContext.Manufacturers.Remove(appDbContext.Manufacturers.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/api/orders", (long id) =>
            {
                appDbContext.Orders.Remove(appDbContext.Orders.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/api/orderParts", (long id) =>
            {
                appDbContext.OrderedParts.Remove(appDbContext.OrderedParts.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/api/accounts", (long id) =>
            {
                appDbContext.CorporateAccounts.Remove(appDbContext.CorporateAccounts.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/api/organizations", (long id) =>
            {
                appDbContext.Organizations.Remove(appDbContext.Organizations.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/api/warehouses", (long id) =>
            {
                appDbContext.Warehouses.Remove(appDbContext.Warehouses.Find(id)!);
                appDbContext.SaveChangesAsync();
            });
            #endregion
            #region PUT-Запросы
            app.MapPut("/api/autoParts", (AutoPart newAutopart) =>
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
            app.MapPut("/api/clients", (long id, Client newClient) =>
            {
                ClientService.UpdateClient(id, newClient).GetAwaiter();
            });
            app.MapPut("/api/manufacturers", (Manufacturer newManufacturer) =>
            {
                Manufacturer oldManufacturer = appDbContext.Manufacturers.Find(newManufacturer)!;
                oldManufacturer.ManufacturerName = newManufacturer.ManufacturerName;
                oldManufacturer.ContactInfo = newManufacturer.ContactInfo;

                appDbContext.Update(oldManufacturer);
                appDbContext.SaveChangesAsync();
            });
            app.MapPut("/api/orders", (Order newOrder) =>
            {
                Order oldOrder = appDbContext.Orders.Find(newOrder)!;
                oldOrder.OrderDate = newOrder.OrderDate;
                oldOrder.Client = newOrder.Client;
                oldOrder.OrderStatus = newOrder.OrderStatus;

                appDbContext.Update(oldOrder);
                appDbContext.SaveChangesAsync();
            });
            app.MapPut("/api/orderParts", ( OrderedPart newPart) =>
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