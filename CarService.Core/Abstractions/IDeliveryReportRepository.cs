using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория отчета по поставке
    /// </summary>
    public interface IDeliveryReportRepository
    {
        /// <summary>
        /// Создание отчета
        /// </summary>
        /// <param name="report">Новый отчет по поставке</param>
        /// <returns></returns>
        Task<Guid> Create(DeliveryReport report);

        /// <summary>
        /// Удаление отчета
        /// </summary>
        /// <param name="id">ID отчета</param>
        /// <returns></returns>
        Task<Guid> Delete(Guid id);

        /// <summary>
        /// Получение всех отчетов
        /// </summary>
        /// <returns></returns>
        Task<List<DeliveryReport>> Get();

        /// <summary>
        /// Получение всех отчетов на конкретном складе
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        Task<List<DeliveryReport>> GetByCurrentWarehouseId(Guid warehouseId);

        /// <summary>
        /// Получение отчета по ID
        /// </summary>
        /// <param name="id">ID отчета</param>
        /// <returns></returns>
        Task<AutoPart> GetById(Guid id);

        /// <summary>
        /// Обновление отчета
        /// </summary>
        /// <param name="reportId">ID отчета</param>
        /// <param name="createDate">Новая дата создания</param>
        /// <param name="warehouseCreatorId">ID склада-создателя</param>
        /// <param name="file">Файл-отчета</param>
        /// <returns></returns>
        Task<Guid> Update(Guid reportId, DateTime createDate, Guid warehouseCreatorId, byte[] file);
    }
}