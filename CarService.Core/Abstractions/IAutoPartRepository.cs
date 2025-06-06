using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория для работы с автозапчастями
    /// </summary>
    public interface IAutoPartRepository
    {
        /// <summary>
        /// Метод создания автозачасти
        /// </summary>
        /// <param name="autoPart">Автозапчасть</param>
        /// <returns></returns>
        Task<Guid> Create(AutoPart autoPart);
        /// <summary>
        /// Удаление автозапчасти по ID
        /// </summary>
        /// <param name="id">ID автозапчасти</param>
        /// <returns></returns>
        Task<Guid> Delete(Guid id);
        /// <summary>
        /// Получение списка автозапчастей
        /// </summary>
        /// <returns></returns>
        Task<List<AutoPart>> Get();
        /// <summary>
        /// Получение списка автозапчастей на определенном складе
        /// </summary>
        /// <param name="warehouseId">ID склада</param>
        /// <returns></returns>
        Task<List<AutoPart>> GetByCurrentWarehouse(Guid warehouseId);
        /// <summary>
        /// Получение автозачасти по ID
        /// </summary>
        /// <param name="id">ID автозапчасти</param>
        /// <returns></returns>
        Task<AutoPart> GetById(Guid id);
        /// <summary>
        /// Обновление автозапчасти
        /// </summary>
        /// <param name="autoPartId">ID автозапчасти которую нужно обновить</param>
        /// <param name="autoPartName">название автозапчасти</param>
        /// <param name="partNumber">партийный номер</param>
        /// <param name="price">цена</param>
        /// <param name="stockAmount">количество</param>
        /// <param name="manufacturerId">ID производителя</param>
        /// <param name="warehouseId">ID склада</param>
        /// <returns></returns>
        Task<Guid> Update(Guid autoPartId, string autoPartName, long partNumber, decimal price, uint stockAmount, Guid manufacturerId, Guid? warehouseId);
    }
}