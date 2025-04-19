using CarService.Api.DbContextAPI.ConnectDB;
using CarService.Models.Entities;
using System.Diagnostics;

namespace CarService.Api.Services
{
    public static class WarehouseService
    {
        public static async Task<bool> AddWarehouse(Warehouse warehouse)
        {
            await using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    if (warehouse.Title != string.Empty &&
                        warehouse.City != string.Empty
                        && warehouse.Address != string.Empty)
                    {
                        context.Warehouses.Add(warehouse);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return false;
                }
            };
        }
        
        public static async Task<bool> AddWarehouse(Guid oldWarehouseId, Warehouse newWarehouse)
        {
            await using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    Warehouse oldWarehouse = context.Warehouses.Find(oldWarehouseId)!;


                    if (newWarehouse.Title != string.Empty &&
                        newWarehouse.City != string.Empty
                        && newWarehouse.Address != string.Empty)
                    {
                        oldWarehouse.Title = newWarehouse.Title;
                        oldWarehouse.Address = newWarehouse.Address;
                        oldWarehouse.City = newWarehouse.City;

                        context.Warehouses.Update(oldWarehouse);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return false;
                }
            };
        }
        
        public static async Task<bool> AddWarehouse(Guid warehouseId)
        {
            await using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    Warehouse warehouse = context.Warehouses.Find(warehouseId)!;

                    context.Warehouses.Remove(warehouse);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return false;
                }
            };
        }
    }
}