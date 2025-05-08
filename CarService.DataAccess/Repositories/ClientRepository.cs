using CarService.Core.Models;
using CarService.Core.Abstractions;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace CarService.DataAccess.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly CarServiceDbContext _context;

        public ClientRepository(CarServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> Get()
        {
            var clientEntities = await _context.Clients
                .AsNoTracking()
                .ToListAsync();

            var clients = clientEntities
                .Select(c => Client.Create(c.ClientId, c.FirstName, c.LastName, c.MiddleName,
                c.PhoneNumber, c.Email, c.Address, c.City, c.OrganizationId).Client)
                .ToList();

            return clients;
        }

        public async Task<Client> GetById(Guid id)
        {
            var clientEntity = await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == id);
            if (clientEntity != null)
            {
                var client = Client.Create(clientEntity.ClientId, clientEntity.FirstName, clientEntity.LastName, clientEntity.MiddleName,
                clientEntity.PhoneNumber, clientEntity.Email, clientEntity.Address, clientEntity.City, clientEntity.OrganizationId).Client;
                return client;
            }
            else return null!;
        }

        public async Task<Guid> Create(Client client)
        {
            ClientEntity clientEntity = new ClientEntity()
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                MiddleName = client.MiddleName,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Address = client.Address,
                City = client.City,
                OrganizationId = client.OrganizationId
            };

            await _context.Clients.AddAsync(clientEntity);
            await _context.SaveChangesAsync();

            return clientEntity.ClientId;
        }

        public async Task<Guid> Update(Guid clientId, string firstName, string lastName, string? middleName,
            string phoneNumber, string email, string address, string city, Guid? organizationId)
        {
            await _context.Clients
                .Where(c => c.ClientId == clientId)
                .ExecuteUpdateAsync(u => u
                .SetProperty(c => c.FirstName, firstName)
                .SetProperty(c => c.LastName, lastName)
                .SetProperty(c => c.MiddleName, middleName)
                .SetProperty(c => c.PhoneNumber, phoneNumber)
                .SetProperty(c => c.Email, email)
                .SetProperty(c => c.Address, address)
                .SetProperty(c => c.City, city)
                .SetProperty(c => c.OrganizationId, organizationId));

            return clientId;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Clients
                .Where(c => c.ClientId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}