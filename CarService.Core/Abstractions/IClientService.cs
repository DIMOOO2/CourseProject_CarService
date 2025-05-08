using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IClientService
    {
        Task<Guid> CreateClient(Client client);
        Task<Guid> DeleteClient(Guid clientId);
        Task<List<Client>> GetAllClients();
        Task<Client> GetByIdClient(Guid id);
        Task<Guid> UpdateClient(Guid clientId, string firstName, string lastName, string? middleName, string phoneNumber, string email, string address, string city, Guid? organizationId);
    }
}