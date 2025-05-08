using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly CarServiceDbContext _context;

        public OrganizationRepository(CarServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Organization>> Get()
        {
            var organizationEntities = await _context.Organizations
                .AsNoTracking()
                .ToListAsync();

            var organizations = _context.Organizations
                .Select(o => Organization.Create(o.OrganizationId, o.TitleOrganization, o.TIN,
                o.Address, o.City).Organization)
                .ToList();

            return organizations;
        }

        public async Task<Organization> GetById(Guid id)
        {
            var organizationEntity = await _context.Organizations.FirstOrDefaultAsync(o => o.OrganizationId == id);

            if (organizationEntity != null)
            {
                var organization = Organization.Create(organizationEntity.OrganizationId, organizationEntity.TitleOrganization, organizationEntity.TIN,
                organizationEntity.Address, organizationEntity.City).Organization;

                return organization;
            }

            else return null!;
        }

        public async Task<Guid> Create(Organization organization)
        {
            OrganizationEntity organizationEntity = new OrganizationEntity()
            {
                OrganizationId = organization.OrganizationId,
                TitleOrganization = organization.TitleOrganization,
                TIN = organization.TIN,
                Address = organization.Address,
                City = organization.City
            };

            await _context.Organizations.AddAsync(organizationEntity);
            await _context.SaveChangesAsync();
            return organization.OrganizationId;
        }

        public async Task<Guid> Update(Guid organizationId, string titleOrganization, long tIN, string address, string city)
        {
            await _context.Organizations
                .Where(o => o.OrganizationId == organizationId)
                .ExecuteUpdateAsync(u => u
                .SetProperty(o => o.TitleOrganization, titleOrganization)
                .SetProperty(o => o.TIN, tIN)
                .SetProperty(o => o.Address, address)
                .SetProperty(o => o.City, city)
                );

            return organizationId;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Organizations
                .Where(o => o.OrganizationId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}