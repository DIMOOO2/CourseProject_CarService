using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IOrganizationRepository
    {
        Task<Guid> Create(Organization organization);
        Task<Guid> Delete(Guid id);
        Task<List<Organization>> Get();
        Task<Guid> Update(Guid organizationId, string titleOrganization, long tIN, 
            string address, string city);
    }
}