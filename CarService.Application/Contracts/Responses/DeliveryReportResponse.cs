namespace CarService.ApplicationService.Contracts.Responses
{
    /// <summary>
    /// Запись ответа отчета по поставке
    /// </summary>
    /// <param name="reportId">Уникальный идентификатор</param>
    /// <param name="createDate">Дата создания</param>
    /// <param name="warehouseCreatorId">ID склада-создателя</param>
    /// <param name="fileReport">Файл отчета</param>
    public record DeliveryReportResponse(Guid reportId, DateTime createDate, Guid warehouseCreatorId, byte[] fileReport);
}
