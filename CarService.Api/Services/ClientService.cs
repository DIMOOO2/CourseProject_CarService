using CarService.Api.DbContextAPI.ConnectDB;
using CarService.Models.Entities;
using System.Diagnostics;

namespace CarService.Api.Services
{
    public static class ClientService
    {
        public async static Task<bool> AddClient(Client client)
        {
            await using (AppDbContext context = new AppDbContext())
            { 
                try
                {
                    Client? dublicate = context.Clients.FirstOrDefault(d => d.ClientId == client.ClientId 
                    && d.PhoneNumber == client.PhoneNumber
                    && d.Email == client.Email);

                    if (client.IsCorrectName &&
                        client.IsCorrectEmail
                        && client.IsCorrectPhoneNumber
                        && dublicate == null)
                    {
                        context.Clients.Add(client);
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
        public async static Task<bool> UpdateClient(Guid oldClientId, Client newClient)
        {
            await using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    Client oldClient = context.Clients.Find(oldClientId)!; 


                    if (newClient.IsCorrectName &&
                        newClient.IsCorrectEmail
                        && newClient.IsCorrectPhoneNumber)
                    {
                        oldClient.FirstName = newClient.FirstName;
                        oldClient.LastName = newClient.LastName;
                        oldClient.Email = newClient.Email;
                        oldClient.PhoneNumber = newClient.PhoneNumber;

                        context.Clients.Update(oldClient);
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

        public async static Task<bool> DeleteClient(Guid id)
        {
            await using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    Client client = context.Clients.Find(id)!;

                    context.Clients.Remove(client);
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