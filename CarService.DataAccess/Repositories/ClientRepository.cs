using CarService.Core.Models;
using CarService.Core.Abstractions;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;



namespace CarService.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий клиента
    /// </summary>
    public class ClientRepository : IClientRepository
    {
        private readonly CarServiceDbContext _context;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public ClientRepository(CarServiceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение всех клиентов
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Получение клиента по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Создание клиента
        /// </summary>
        /// <param name="client">Новый клиент</param>
        /// <returns></returns>
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

        /// <summary>
        /// Обновление клиента
        /// </summary>
        /// <param name="clientId">ID клиента</param>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="address">Адрес</param>
        /// <param name="city">Город</param>
        /// <param name="organizationId">ID организации</param>
        /// <returns></returns>
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

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="id">ID клиента</param>
        /// <returns></returns>
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Clients
                .Where(c => c.ClientId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}