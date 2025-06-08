using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса для работы со складами
    /// </summary>
    public interface IWarehouseService
    {
        /// <summary>
        /// Создание склада
        /// </summary>
        /// <param name="warehouse">Новый склад</param>
        /// <returns></returns>
        Task<Guid> CreateWarehouse(Warehouse warehouse);

        /// <summary>
        /// Удаление склада
        /// </summary>
        /// <param name="id">ID склада</param>
        /// <returns></returns>
        Task<Guid> DeleteWarehouse(Guid id);

        /// <summary>
        /// Получение всех складов
        /// </summary>
        /// <returns></returns>
        Task<List<Warehouse>> GetAllWarehouse();

        /// <summary>
        /// Получение склада по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Warehouse> GetByIdWarehouse(Guid id);


        /// <summary>
        /// Обновление склада
        /// </summary>
        /// <param name="id">ID склада</param>
        /// <param name="title">Название</param>
        /// <param name="address">Адрес</param>
        /// <param name="city">Город</param>
        /// <returns></returns>
        Task<Guid> UpdateWarehouse(Guid id, string title, string address, string city);
    }
}