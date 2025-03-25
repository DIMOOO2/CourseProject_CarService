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
            app.MapDelete("/autoparts", (AutoPart autopart) =>
            {
                appDbContext.Autoparts.Remove(autopart);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/clients", (Client client) =>
            {
                appDbContext.Clients.Remove(client);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/manufacturers", (Manufacturer manufacturer) => 
            {
                appDbContext.Manufacturers.Remove(manufacturer);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/orders", (Order order) =>
            {
                appDbContext.Orders.Remove(order);
                appDbContext.SaveChangesAsync();
            });

            app.MapDelete("/orderParts", (OrderedPart orderPart) =>
            {
                appDbContext.OrderedParts.Remove(orderPart);
                appDbContext.SaveChangesAsync();
            });
            #endregion
            #region PUT-Запросы
            app.MapPut("/autoparts", (AutoPart oldAutoPart, AutoPart newAutoPart) =>
            {
                oldAutoPart.AutoPartName = newAutoPart.AutoPartName;
                oldAutoPart.PartNumber = newAutoPart.PartNumber;
                oldAutoPart.Price = newAutoPart.Price;
                oldAutoPart.Manufacturer = oldAutoPart.Manufacturer;
                oldAutoPart.StockAmount = newAutoPart.StockAmount;

                appDbContext.Autoparts.Update(oldAutoPart);
                appDbContext.SaveChangesAsync();
            });
            app.MapPut("/clients", (Client oldClient, Client newClient) =>
            {
                oldClient.FirstName = newClient.FirstName;
                oldClient.LastName = newClient.LastName;
                oldClient.PhoneNumber = newClient.PhoneNumber;
                oldClient.Email = newClient.Email;

                appDbContext.Update(oldClient);
                appDbContext.SaveChangesAsync();
            });
            app.MapPut("/manufacturers", (Manufacturer oldManufacturer, Manufacturer newManufacturer) =>
            {
                oldManufacturer.ManufacturerName = newManufacturer.ManufacturerName;
                oldManufacturer.ContactInfo = newManufacturer.ContactInfo;

                appDbContext.Update(oldManufacturer);
                appDbContext.SaveChangesAsync();
            });
            app.MapPut("/orders", (Order oldOrder, Order newOrder) =>
            {
                oldOrder.OrderDate = newOrder.OrderDate;
                oldOrder.Client = newOrder.Client;
                oldOrder.OrderStatus = newOrder.OrderStatus;

                appDbContext.Update(oldOrder);
                appDbContext.SaveChangesAsync();
            });
            app.MapPut("/orderParts", (OrderedPart oldPart, OrderedPart newPart) =>
            {
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