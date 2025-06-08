using CarService.Core.Abstractions;
using CarService.Core.Models;


namespace CarService.ApplicationService.Services
{
    /// <summary>
    /// Класс сервиса для работы со складами
    /// </summary>
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="warehouseRepository">репозиторий склада</param>
        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        /// <summary>
        /// Получение всех складов
        /// </summary>
        /// <returns></returns>
        public async Task<List<Warehouse>> GetAllWarehouse()
        {
            return await _warehouseRepository.Get();
        }

        /// <summary>
        /// Получение склада по ID
        /// </summary>
        /// <param name="id">ID склада</param>
        /// <returns></returns>
        public async Task<Warehouse> GetByIdWarehouse(Guid id)
        {
            return await _warehouseRepository.GetById(id);
        }

        /// <summary>
        /// Создание склада
        /// </summary>
        /// <param name="warehouse">Новый склад</param>
        /// <returns></returns>
        public async Task<Guid> CreateWarehouse(Warehouse warehouse)
        {
            return await _warehouseRepository.Create(warehouse);
        }

        /// <summary>
        /// Обновление склада
        /// </summary>
        /// <param name="id">ID склада</param>
        /// <param name="title">Название</param>
        /// <param name="address">Адрес</param>
        /// <param name="city">Город</param>
        /// <returns></returns>
        public async Task<Guid> UpdateWarehouse(Guid id, string title, string address, string city)
        {
            return await _warehouseRepository.Update(id, title, address, city);
        }

        /// <summary>
        /// Удаление склада
        /// </summary>
        /// <param name="id">ID Склада</param>
        /// <returns></returns>
        public async Task<Guid> DeleteWarehouse(Guid id)
        {
            return await _warehouseRepository.Delete(id);
        }
    }
}