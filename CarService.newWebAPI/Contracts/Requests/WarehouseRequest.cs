namespace CarService.newWebAPI.Contracts.Requests
{
    public record WarehouseRequest
        (
            string Title,
            string Address,
            string City
        );
}
