namespace CarService.ApplicationService.Contracts.Requests
{
    public record OrderedPartRequest(uint amount, Guid orderId, Guid autoPartId,
            Guid departureWarehouseId);
}
