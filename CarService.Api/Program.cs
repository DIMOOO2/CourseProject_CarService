using CarService.Api.DbContextAPI.ConnectDB;
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
            app.MapGet("/autoparts", () => appDbContext.Autoparts);
            app.MapGet("/clients", () => appDbContext.Clients);
            app.MapGet("/manufacturers", () => appDbContext.Manufacturers);
            app.MapGet("/orders", () => appDbContext.Orders);
            app.MapGet("/orderParts", () => appDbContext.OrderedParts);
            #endregion 
            #region POST-Запросы
            app.MapPost("/autoparts", (AutoPart autopart) =>
            {
                appDbContext.Autoparts.Add(autopart);
                appDbContext.SaveChangesAsync();
            });

            app.MapPost("/clients", (Client client) =>
            {
                appDbContext.Clients.Add(client);
                appDbContext.SaveChangesAsync();
            });

            app.MapPost("/manufacturers", (Manufacturer manufacturer) =>
            {
                appDbContext.Manufacturers.Add(manufacturer);
                appDbContext.SaveChangesAsync();
            });

            app.MapPost("/orders", (Order order) =>
            {
                appDbContext.Orders.Add(order);
                appDbContext.SaveChangesAsync();
            });

            app.MapPost("/orderParts", (OrderedPart orderPart) =>
            {
                appDbContext.OrderedParts.Add(orderPart);
                appDbContext.SaveChangesAsync();
            });
            #endregion
            #region DELETE-Запросы
            app.MapDelete("/autoparts/{id}", (int id) =>
            {
                appDbContext.Autoparts.Remove(appDbContext.Autoparts.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/clients", (int id) =>
            {
                appDbContext.Clients.Remove(appDbContext.Clients.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/manufacturers", (int id) =>
            {
                appDbContext.Manufacturers.Remove(appDbContext.Manufacturers.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/orders", (int id) =>
            {
                appDbContext.Orders.Remove(appDbContext.Orders.Find(id)!);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/orderParts", (int id) =>
            {
                appDbContext.OrderedParts.Remove(appDbContext.OrderedParts.Find(id)!);
                appDbContext.SaveChangesAsync();
            });
            #endregion
            #region PUT-Запросы
            app.MapPut("/autoparts", (AutoPart newAutopart) =>
            {
                AutoPart autopart = appDbContext.Autoparts.Find(newAutopart)!;
                autopart.AutoPartName = newAutopart.AutoPartName;
                autopart.Manufacturer = newAutopart.Manufacturer;
                autopart.PartNumber = newAutopart.PartNumber;
                autopart.Price = newAutopart.Price;
                autopart.StockAmount = newAutopart.StockAmount;

                appDbContext.Autoparts.Update(newAutopart);
                appDbContext.SaveChangesAsync();
            });
            app.MapPut("/clients", (Client newClient) =>
            {
                Client oldClient = appDbContext.Clients.Find(newClient)!;
                oldClient.FirstName = newClient.FirstName;
                oldClient.LastName = newClient.LastName;
                oldClient.PhoneNumber = newClient.PhoneNumber;
                oldClient.Email = newClient.Email;

                appDbContext.Update(oldClient);
                appDbContext.SaveChangesAsync();
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