using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса для работы с автозапчастями
    /// </summary>
    public interface IAutoPartService
    {
        /// <summary>
        /// Создание автозапчасти
        /// </summary>
        /// <param name="autoPart">Новая автозапчасть</param>
        /// <returns></returns>
        Task<Guid> CreateAutopart(AutoPart autoPart);

        /// <summary>
        /// Удаление автозапчасти
        /// </summary>
        /// <param name="id">ID автозапчасти</param>
        /// <returns></returns>
        Task<Guid> DeleteAutoPart(Guid id);

        /// <summary>
        /// Получение всех автозапчастей
        /// </summary>
        /// <returns></returns>
        Task<List<AutoPart>> GetAllAutoParts();

        /// <summary>
        /// Полученние всех автозапчастей на конкретном складе
        /// </summary>
        /// <param name="warehouseId">ID склада</param>
        /// <returns></returns>
        Task<List<AutoPart>> GetAutoPartsFromCurrentWarehouse(Guid warehouseId);

        /// <summary>
        /// Получение автозапчасти по ID
        /// </summary>
        /// <param name="id">ID автозапчасти</param>
        /// <returns></returns>
        Task<AutoPart> GetByIdAutoPart(Guid id);

        /// <summary>
        /// Обновление автозапчасти
        /// </summary>
        /// <param name="autoPartId">ID автозапчасти</param>
        /// <param name="autoPartName">Название автозапчасти</param>
        /// <param name="partNumber">Партийный номер</param>
        /// <param name="price">Цена</param>
        /// <param name="stockAmount">Количество</param>
        /// <param name="manufacturerId">ID производителя</param>
        /// <param name="warehouseId">ID склада</param>
        /// <returns></returns>
        Task<Guid> UpdateAutoPart(Guid autoPartId, string autoPartName, long partNumber, decimal price, uint stockAmount, Guid manufacturerId, Guid? warehouseId);
    }
}