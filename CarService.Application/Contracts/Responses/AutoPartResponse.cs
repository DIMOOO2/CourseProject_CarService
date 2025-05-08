namespace CarService.ApplicationService.Contracts.Responses
{
    public record AutoPartResponse
        (
            Guid autoPartId, string autoPartName, long partNumber,
            decimal price, uint stockAmount, Guid manufacturerId, Guid? warehouseId
        );
}
