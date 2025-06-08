namespace CarService.ApplicationService.Contracts.Requests
{
    /// <summary>
    /// Запись запроса заказа
    /// </summary>
    /// <param name="orderDate">Дата оформления</param>
    /// <param name="orderStatus">Статус выполнения</param>
    /// <param name="clientId">ID Клиента</param>
    /// <param name="warehouseContractorId">ID склада-исполнителя</param>
    public record OrderRequest
    (
        DateTime orderDate, bool orderStatus, Guid clientId, Guid warehouseContractorId
    );
}
