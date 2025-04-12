using CarService.Api.DbContextAPI.ConnectDB;
using CarService.Models.Entities;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

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
                    if (IsCorrectName(client.FirstName) &&
                        IsCorrectName(client.LastName) &&
                        IsCorrectEmail(client.Email)
                        && IsCorrectPhoneNumber(client.PhoneNumber))
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


                    if (IsCorrectName(newClient.FirstName) &&
                        IsCorrectName(newClient.LastName) &&
                        IsCorrectEmail(newClient.Email)
                        && IsCorrectPhoneNumber(newClient.PhoneNumber))
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
        #region Methods
        private static bool IsCorrectName(string data)
        {
            foreach (char c in data)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            if (data == string.Empty)
                return false;

            else return true;

        }
        private static bool IsCorrectEmail(string data)
        {
            bool isContainsSeparator = false;
            bool isContainsDomen = false;

            foreach (char c in data)
            {
                if (c == '@')
                {
                    isContainsSeparator = true;
                }
                else if (c == '.' && isContainsSeparator)
                    isContainsDomen |= true;
            }

            if (data == string.Empty)
                return false;

            else if (!isContainsDomen || !isContainsSeparator)
                return false;

            else return true;
        }
        private static bool IsCorrectPhoneNumber(string number)
        {
            Regex rg = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})");
            MatchCollection matchNumber = rg.Matches(number);
            if (matchNumber.Count > 0) return true;
            else return false;
        }
        #endregion
    }
}
