using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.ApplicationService.Services
{
    /// <summary>
    /// Класс сервиса для работы с организациями
    /// </summary>
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="organizationRepository">Репозиторий организации</param>
        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        /// <summary>
        /// Получение всех организаций
        /// </summary>
        /// <returns></returns>
        public async Task<List<Organization>> GetAllOrganizations()
        {
            return await _organizationRepository.Get();
        }

        /// <summary>
        /// Получение организации по ID
        /// </summary>
        /// <param name="id">ID организации</param>
        /// <returns></returns>
        public async Task<Organization> GetByIdOrganization(Guid id)
        {
            return await GetByIdOrganization(id);
        }

        /// <summary>
        /// Создание организации
        /// </summary>
        /// <param name="organization">Новая организация</param>
        /// <returns></returns>
        public async Task<Guid> CreateOrganization(Organization organization)
        {
            return await _organizationRepository.Create(organization);
        }

        /// <summary>
        /// Обновление организации
        /// </summary>
        /// <param name="organizationId">ID организации</param>
        /// <param name="titleOrganization">Название организации</param>
        /// <param name="tIN">ИНН</param>
        /// <param name="address">Адрес</param>
        /// <param name="city">Город</param>
        /// <returns></returns>
        public async Task<Guid> UpdateOrganization(Guid organizationId, string titleOrganization, long tIN,
            string address, string city)
        {
            return await _organizationRepository.Update(organizationId, titleOrganization, tIN, address, city);
        }

        /// <summary>
        /// Удаление организации
        /// </summary>
        /// <param name="id">ID организации</param>
        /// <returns></returns>
        public async Task<Guid> DeleteOrganization(Guid id)
        {
            return await _organizationRepository.Delete(id);
        }
    }
}
