using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.ApplicationService.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<List<Organization>> GetAllOrganizations()
        {
            return await _organizationRepository.Get();
        }

        public async Task<Organization> GetByIdOrganization(Guid id)
        {
            return await GetByIdOrganization(id);
        }

        public async Task<Guid> CreateOrganization(Organization organization)
        {
            return await _organizationRepository.Create(organization);
        }

        public async Task<Guid> UpdateOrganization(Guid organizationId, string titleOrganization, long tIN,
            string address, string city)
        {
            return await _organizationRepository.Update(organizationId, titleOrganization, tIN, address, city);
        }

        public async Task<Guid> DeleteOrganization(Guid id)
        {
            return await _organizationRepository.Delete(id);
        }
    }
}
