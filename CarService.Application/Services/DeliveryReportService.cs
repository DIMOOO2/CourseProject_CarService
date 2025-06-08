using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.ApplicationService.Services
{
    /// <summary>
    /// Класс сервиса для работы с отчетами по поставкам
    /// </summary>
    public class DeliveryReportService : IDeliveryReportService
    {
        private readonly IDeliveryReportRepository _repository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="repository">Репозиторий отчетов</param>
        public DeliveryReportService(IDeliveryReportRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Получение всех отчетов
        /// </summary>
        /// <returns></returns>
        public async Task<List<DeliveryReport>> GetAllReports()
        {
            return await _repository.Get();
        }

        /// <summary>
        /// Получение всех отчетов на определенном складе
        /// </summary>
        /// <param name="warehouseId">ID склада</param>
        /// <returns></returns>
        public async Task<List<DeliveryReport>> GetDeliveryReportsFromWarehouse(Guid warehouseId)
        {
            return await _repository.GetByCurrentWarehouseId(warehouseId);
        }

        /// <summary>
        /// Получение отчета по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DeliveryReport> GetDeliveryReportById(Guid id)
        {
            return await GetDeliveryReportById(id);
        }

        /// <summary>
        /// Создание отчета
        /// </summary>
        /// <param name="deliveryReport">Новый отчет</param>
        /// <returns></returns>
        public Task<Guid> CreateReport(DeliveryReport deliveryReport)
        {
            return _repository.Create(deliveryReport);
        }

        /// <summary>
        /// Обновление отчета
        /// </summary>
        /// <param name="id">ID отчета</param>
        /// <param name="createDate">Дата создания</param>
        /// <param name="warehouseCreatorId">ID склада-создателя</param>
        /// <param name="file">файл отчета</param>
        /// <returns></returns>
        public async Task<Guid> UpdateReport(Guid id, DateTime createDate, Guid warehouseCreatorId, byte[] file)
        {
            return await _repository.Update(id, createDate, warehouseCreatorId, file);
        }

        /// <summary>
        /// Удаление отчета
        /// </summary>
        /// <param name="id">ID отчета</param>
        /// <returns></returns>
        public async Task<Guid> DeleteReport(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}
