using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория производителя
    /// </summary>
    public interface IManufacturerRepository
    {
        /// <summary>
        /// Создание производителя
        /// </summary>
        /// <param name="manufacturer">Новый производитель</param>
        /// <returns></returns>
        Task<Guid> Create(Manufacturer manufacturer);

        /// <summary>
        /// Удаление производителя
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <returns></returns>
        Task<Guid> Delete(Guid id);

        /// <summary>
        /// Получение всех производителей
        /// </summary>
        /// <returns></returns>
        Task<List<Manufacturer>> Get();

        /// <summary>
        /// Получение производителя по ID
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <returns></returns>
        Task<Manufacturer> GetById(Guid id);

        /// <summary>
        /// Обновление производителя
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <param name="name">Название производителя</param>
        /// <param name="contactInfo">Контактная информация производителя (email)</param>
        /// <returns></returns>
        Task<Guid> Update(Guid id, string name, string contactInfo);
    }
}