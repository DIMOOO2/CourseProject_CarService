using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    /// <summary>
    /// Сервис для работы с организациями
    /// </summary>
    public interface IOrganizationService
    {
        /// <summary>
        /// Создание организации
        /// </summary>
        /// <param name="organization">ID организации</param>
        /// <returns></returns>
        Task<Guid> CreateOrganization(Organization organization);

        /// <summary>
        /// Удаление организации
        /// </summary>
        /// <param name="id">ID организации</param>
        /// <returns></returns>
        Task<Guid> DeleteOrganization(Guid id);

        /// <summary>
        /// Получение всех организаций
        /// </summary>
        /// <returns></returns>
        Task<List<Organization>> GetAllOrganizations();

        /// <summary>
        /// Получение организации по ID
        /// </summary>
        /// <param name="id">ID организации</param>
        /// <returns></returns>
        Task<Organization> GetByIdOrganization(Guid id);

        /// <summary>
        /// Обновление организации
        /// </summary>
        /// <param name="organizationId">ID организации</param>
        /// <param name="titleOrganization">Название организации</param>
        /// <param name="tIN">ИНН</param>
        /// <param name="address">Адрес</param>
        /// <param name="city">Город</param>
        /// <returns></returns>
        Task<Guid> UpdateOrganization(Guid organizationId, string titleOrganization, long tIN, string address, string city);
    }
}