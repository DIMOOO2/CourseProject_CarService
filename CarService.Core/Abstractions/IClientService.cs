using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса для работы с клиентами
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Создание клиента
        /// </summary>
        /// <param name="client">Новый клиент</param>
        /// <returns></returns>
        Task<Guid> CreateClient(Client client);

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="clientId">ID клиента</param>
        /// <returns></returns>
        Task<Guid> DeleteClient(Guid clientId);

        /// <summary>
        /// Получение всех клиентов
        /// </summary>
        /// <returns></returns>
        Task<List<Client>> GetAllClients();

        /// <summary>
        /// Получение клиента по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Client> GetByIdClient(Guid id);

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
        Task<Guid> UpdateClient(Guid clientId, string firstName, string lastName, string? middleName, string phoneNumber, string email, string address, string city, Guid? organizationId);
    }
}