namespace CarService.ApplicationService.Contracts.Requests
{
    public record AutoPartRequest
        (
            string autoPartName, 
            long partNumber,
            decimal price,
            uint stockAmount, 
            Guid manufacturerId, 
            Guid? warehouseId
        );
}
