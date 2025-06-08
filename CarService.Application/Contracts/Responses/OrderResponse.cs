namespace CarService.ApplicationService.Contracts.Responses
{
    /// <summary>
    /// Запись ответа заказа
    /// </summary>
    /// <param name="orderId">ID заказа</param>
    /// <param name="orderDate">Дата оформления</param>
    /// <param name="orderStatus">Статус выполнения</param>
    /// <param name="clientId">ID Клиента</param>
    /// <param name="warehouseContratorId">ID склада-исполнителя</param>
    public record OrderResponse(Guid orderId, DateTime orderDate, bool orderStatus, Guid clientId, Guid warehouseContratorId);
}
