namespace CarService.ApplicationService.Contracts.Responses
{
    /// <summary>
    /// Запись ответа запчасти в заказе
    /// </summary>
    /// <param name="orderedPartId">ID запчасти в заказе</param>
    /// <param name="amount">количество</param>
    /// <param name="orderId">ID заказа</param>
    /// <param name="autoPartId">ID автозапчасти</param>
    /// <param name="departureWarehouseId">ID склада-отправителя</param>
    public record OrderedPartResponse(Guid orderedPartId, uint amount, Guid orderId, Guid autoPartId,
            Guid departureWarehouseId);
}
