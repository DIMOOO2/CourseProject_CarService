namespace CarService.ApplicationService.Contracts.Responses
{
    public record OrderResponse(Guid orderId, DateTime orderDate, bool orderStatus, Guid clientId, Guid warehouseContratorId);
}
