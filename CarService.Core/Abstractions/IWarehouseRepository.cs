using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    /// <summary>
    /// Интерфйс репозитория складов
    /// </summary>
    public interface IWarehouseRepository
    {
        /// <summary>
        /// Создание склада
        /// </summary>
        /// <param name="warehouse">Новый склад</param>
        /// <returns></returns>
        Task<Guid> Create(Warehouse warehouse);

        /// <summary>
        /// Удаление склада
        /// </summary>
        /// <param name="id">ID склада</param>
        /// <returns></returns>
        Task<Guid> Delete(Guid id);

        /// <summary>
        /// Получение всех складов
        /// </summary>
        /// <returns></returns>
        Task<List<Warehouse>> Get();

        /// <summary>
        /// Получение склада по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Warehouse> GetById(Guid id);

        /// <summary>
        /// Обновление склада
        /// </summary>
        /// <param name="id">ID склада</param>
        /// <param name="title">Название</param>
        /// <param name="address">Адрес</param>
        /// <param name="city">Город</param>
        /// <returns></returns>
        Task<Guid> Update(Guid id, string title, string address, string city);
    }
}