using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса для работы с производителями
    /// </summary>
    public interface IManufacturerService
    {
        /// <summary>
        /// Создание производителя
        /// </summary>
        /// <param name="manufacturer">Новый производитель</param>
        /// <returns></returns>
        Task<Guid> CreateManufacturer(Manufacturer manufacturer);

        /// <summary>
        /// Удаление производителя
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <returns></returns>
        Task<Guid> DeleteManufacturer(Guid id);

        /// <summary>
        /// Получение всех производителей
        /// </summary>
        /// <returns></returns>
        Task<List<Manufacturer>> GetAllManufacturers();

        /// <summary>
        /// Получение производителя по ID
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <returns></returns>
        Task<Manufacturer> GetByIdManufacturer(Guid id);

        /// <summary>
        /// Обновление производителя
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <param name="name">Название производителя</param>
        /// <param name="contactInfo">Контактная информация производителя (email)</param>
        /// <returns></returns>
        Task<Guid> UpdateManufacturer(Guid id, string name, string contactInfo);
    }
}