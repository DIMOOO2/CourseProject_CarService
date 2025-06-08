namespace CarService.ApplicationService.Contracts.Requests
{
    /// <summary>
    /// Запись запроса запчасти в заказе
    /// </summary>
    /// <param name="amount">количество</param>
    /// <param name="orderId">ID заказа</param>
    /// <param name="autoPartId">ID автозапчасти</param>
    /// <param name="departureWarehouseId">ID склада-отправителя</param>
    public record OrderedPartRequest(uint amount, Guid orderId, Guid autoPartId,
            Guid departureWarehouseId);
}
