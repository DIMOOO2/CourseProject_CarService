namespace CarService.ApplicationService.Contracts.Responses
{
    public record OrderedPartResponse(Guid orderedPartId, uint amount, Guid orderId, Guid autoPartId,
            Guid departureWarehouseId, Guid? arrivalWarehouseId);
}
