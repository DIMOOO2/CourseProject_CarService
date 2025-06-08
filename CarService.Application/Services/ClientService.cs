using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.ApplicationService.Services
{
    /// <summary>
    /// Класс сервиса для работы с клиентом
    /// </summary>
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="clientRepository">Интерфейс репозитория клиента</param>
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        /// <summary>
        /// Получение всех клиентов
        /// </summary>
        /// <returns></returns>
        public async Task<List<Client>> GetAllClients()
        {
            return await _clientRepository.Get();
        }

        /// <summary>
        /// Получение клиента по ID
        /// </summary>
        /// <param name="id">ID клиента</param>
        /// <returns></returns>
        public async Task<Client> GetByIdClient(Guid id)
        {
            return await _clientRepository.GetById(id);
        }

        /// <summary>
        /// Создание клиента
        /// </summary>
        /// <param name="client">Новый клиент</param>
        /// <returns></returns>
        public async Task<Guid> CreateClient(Client client)
        {
            return await _clientRepository.Create(client);
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
        public async Task<Guid> UpdateClient(Guid clientId, string firstName, string lastName, string? middleName, string phoneNumber, string email, string address, string city, Guid? organizationId)
        {
            return await _clientRepository.Update(clientId, firstName, lastName, middleName,
                phoneNumber, email, address, city, organizationId);
        }

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="clientId">ID Клиента</param>
        /// <returns></returns>
        public async Task<Guid> DeleteClient(Guid clientId)
        {
            return await _clientRepository.Delete(clientId);
        }
    }
}
