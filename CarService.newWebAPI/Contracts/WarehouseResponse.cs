namespace CarService.newWebAPI.Contracts
{
    public record WarehouseResponse
        (
            Guid Id,
            string Title,
            string Address,
            string City
        );
}
