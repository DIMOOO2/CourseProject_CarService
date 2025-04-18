using CarService.Api.DbContextAPI.ConnectDB;
using CarService.Models.Entities;
using System.Diagnostics;

namespace CarService.Api.Services
{
    public static class OrganizationService
    {
        public async static Task<bool> AddOrganization(Organization organization)
        {
            await using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    if (organization.IsCorrectData)
                    {
                        organization.OrganizationId = Guid.NewGuid();
                        context.Organizations.Add(organization);
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
        public async static Task<bool> UpdateOrganization(Guid oldOrganizationId, Organization newOrganization)
        {
            await using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    Organization oldOrganization = context.Organizations.Find(oldOrganizationId)!;


                    if (newOrganization.IsCorrectData)
                    {
                        oldOrganization.TitleOrganization = newOrganization.TitleOrganization;
                        oldOrganization.TIN = newOrganization.TIN;
                        oldOrganization.CorporateNumber = newOrganization.CorporateNumber;
                        oldOrganization.CorporateEmail = newOrganization.CorporateEmail;
                        oldOrganization.City = newOrganization.City;
                        oldOrganization.Address = newOrganization.Address;

                        context.Organizations.Update(oldOrganization);
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

        public async static Task<bool> DeleteOrderedPart(Guid OrganizationId)
        {
            await using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    Organization organization = context.Organizations.Find(OrganizationId)!;

                    context.Organizations.Remove(organization);
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
}
