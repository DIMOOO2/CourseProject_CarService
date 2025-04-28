using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IClientRepository
    {
        Task<Guid> Create(Client client);
        Task<Guid> Delete(Guid id);
        Task<List<Client>> Get();
        Task<Guid> Update(Guid clientId, string firstName, string lastName, string? middleName, string phoneNumber, string email, string address, string city, Guid? organizationId);
    }
}