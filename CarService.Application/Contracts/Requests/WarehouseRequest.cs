namespace CarService.ApplicationService.Contracts.Requests
{
    public record WarehouseRequest
        (
            string Title,
            string Address,
            string City
        );
}
