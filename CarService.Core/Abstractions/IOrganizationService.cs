using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IOrganizationService
    {
        Task<Guid> CreateOrganization(Organization organization);
        Task<Guid> DeleteOrganization(Guid id);
        Task<List<Organization>> GetAllOrganizations();
        Task<Organization> GetByIdOrganization(Guid id);
        Task<Guid> UpdateOrganization(Guid organizationId, string titleOrganization, long tIN, string address, string city);
    }
}