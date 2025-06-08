using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса для работы с отчетами по поставкам
    /// </summary>
    public interface IDeliveryReportService
    {
        /// <summary>
        /// Создание отчета
        /// </summary>
        /// <param name="deliveryReport">Новый отчет по поставке</param>
        /// <returns></returns>
        Task<Guid> CreateReport(DeliveryReport deliveryReport);

        /// <summary>
        /// Удаление отчета
        /// </summary>
        /// <param name="id">ID отчет</param>
        /// <returns></returns>
        Task<Guid> DeleteReport(Guid id);

        /// <summary>
        /// Получение всех отчетов
        /// </summary>
        /// <returns></returns>
        Task<List<DeliveryReport>> GetAllReports();

        /// <summary>
        /// Получение отчета по ID
        /// </summary>
        /// <param name="id">ID отчета</param>
        /// <returns></returns>
        Task<DeliveryReport> GetDeliveryReportById(Guid id);

        /// <summary>
        /// Получение всех отчетов на конкретном складе
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        Task<List<DeliveryReport>> GetDeliveryReportsFromWarehouse(Guid warehouseId);

        /// <summary>
        /// Обновление отчета
        /// </summary>
        /// <param name="id">ID отчета</param>
        /// <param name="createDate">Новая дата создания</param>
        /// <param name="warehouseCreatorId">ID склада-создателя</param>
        /// <param name="file">Файл-отчета</param>
        /// <returns></returns>
        Task<Guid> UpdateReport(Guid id, DateTime createDate, Guid warehouseCreatorId, byte[] file);
    }
}