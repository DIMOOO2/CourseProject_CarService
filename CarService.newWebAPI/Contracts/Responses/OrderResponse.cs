namespace CarService.newWebAPI.Contracts.Responses
{
    public record OrderResponse(Guid orderId, DateTime orderDate, bool orderStatus, Guid clientId);
}
