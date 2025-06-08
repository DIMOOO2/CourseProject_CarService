namespace CarService.ApplicationService.Contracts.Requests
{
    /// <summary>
    /// Запись запроса отчета по поставке
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    /// <param name="createDate">Дата создания</param>
    /// <param name="warehouseCreatorId">ID склада-создателя</param>
    /// <param name="fileReport">Файл отчета</param>
    public record DeliveryReportRequest(Guid id, DateTime createDate, Guid warehouseCreatorId, byte[] fileReport);
}
