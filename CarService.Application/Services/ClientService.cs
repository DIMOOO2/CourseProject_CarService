using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await _clientRepository.Get();
        }

        public async Task<Client> GetByIdClient(Guid id)
        {
            return await _clientRepository.GetById(id);
        }

        public async Task<Guid> CreateClient(Client client)
        {
            return await _clientRepository.Create(client);
        }

        public async Task<Guid> UpdateClient(Guid clientId, string firstName, string lastName, string? middleName, string phoneNumber, string email, string address, string city, Guid? organizationId)
        {
            return await _clientRepository.Update(clientId, firstName, lastName, middleName,
                phoneNumber, email, address, city, organizationId);
        }

        public async Task<Guid> DeleteClient(Guid clientId)
        {
            return await _clientRepository.Delete(clientId);
        }
    }
}
