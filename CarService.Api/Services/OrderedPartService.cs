using CarService.Api.DbContextAPI.ConnectDB;
using CarService.Models.Entities;
using System.Diagnostics;

namespace CarService.Api.Services
{
    public static class OrderedPartService
    {
        public async static Task<bool> AddOrderedPart(OrderedPart orderedPart)
        {
            await using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    if (orderedPart.IsCorrectData)
                    {
                        orderedPart.OrderedPartId = Guid.NewGuid();
                        context.OrderedParts.Add(orderedPart);
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
        public async static Task<bool> UpdateOrderedPart(Guid oldOrderedPartId, OrderedPart newOrderedPar)
        {
            await using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    OrderedPart oldOrderedPart = context.OrderedParts.Find(oldOrderedPartId)!;


                    if (newOrderedPar.IsCorrectData)
                    {
                        oldOrderedPart.Amount = newOrderedPar.Amount;
                        oldOrderedPart.Order = newOrderedPar.Order;
                        oldOrderedPart.AutoPart = newOrderedPar.AutoPart;
                        oldOrderedPart.DepartureWarehouse = newOrderedPar.DepartureWarehouse;
                        oldOrderedPart.ArrivalWarehouse = newOrderedPar.ArrivalWarehouse;

                        context.OrderedParts.Update(oldOrderedPart);
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

        public async static Task<bool> DeleteOrderedPart(Guid orderedPartId)
        {
            await using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    OrderedPart orderedPart = context.OrderedParts.Find(orderedPartId)!;

                    context.OrderedParts.Remove(orderedPart);
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