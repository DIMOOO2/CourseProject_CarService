using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.ApplicationService.Services
{
    /// <summary>
    /// Класс реализующий интерфейс сервиса для работы с автозапчастями
    /// </summary>
    public class AutoPartService : IAutoPartService
    {
        private readonly IAutoPartRepository _autoPartRepository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="autoPartRepository">Интерфейс репозитория для работы с автозапчастями</param>
        public AutoPartService(IAutoPartRepository autoPartRepository)
        {
            _autoPartRepository = autoPartRepository;
        }

        /// <summary>
        /// Получение всех автозапчастей
        /// </summary>
        /// <returns></returns>
        public async Task<List<AutoPart>> GetAllAutoParts()
        {
            return await _autoPartRepository.Get();
        }
        /// <summary>
        /// Получение всех автозапчастей на конкретном складе
        /// </summary>
        /// <param name="warehouseId">ID склада</param>
        /// <returns></returns>
        public async Task<List<AutoPart>> GetAutoPartsFromCurrentWarehouse(Guid warehouseId)
        {
            return await _autoPartRepository.GetByCurrentWarehouse(warehouseId);
        }

        /// <summary>
        /// Получение автозапчасти по ID
        /// </summary>
        /// <param name="id">ID автозапчасти</param>
        /// <returns></returns>
        public async Task<AutoPart> GetByIdAutoPart(Guid id)
        {
            return await _autoPartRepository.GetById(id);
        }

        /// <summary>
        /// Создание автозапчасти
        /// </summary>
        /// <param name="autoPart">Новая автозапчасть</param>
        /// <returns></returns>
        public async Task<Guid> CreateAutopart(AutoPart autoPart)
        {
            return await _autoPartRepository.Create(autoPart);
        }

        /// <summary>
        /// Обновление автозапчасти
        /// </summary>
        /// <param name="autoPartId">ID обновляемой автозапчасти</param>
        /// <param name="autoPartName">новое название</param>
        /// <param name="partNumber">новый партийный номер</param>
        /// <param name="price">новая цена</param>
        /// <param name="stockAmount">новое количество</param>
        /// <param name="manufacturerId">новый ID производителя</param>
        /// <param name="warehouseId">новый ID склада</param>
        /// <returns></returns>
        public async Task<Guid> UpdateAutoPart(Guid autoPartId, string autoPartName, long partNumber,
            decimal price, uint stockAmount, Guid manufacturerId, Guid? warehouseId)
        {
            return await _autoPartRepository.Update(autoPartId, autoPartName, partNumber, price,
                stockAmount, manufacturerId, warehouseId);
        }

        /// <summary>
        /// Удаление автозапчасти
        /// </summary>
        /// <param name="id">ID автозапчасти которую нужно удалить</param>
        /// <returns></returns>
        public async Task<Guid> DeleteAutoPart(Guid id)
        {
            return await _autoPartRepository.Delete(id);
        }
    }
}
