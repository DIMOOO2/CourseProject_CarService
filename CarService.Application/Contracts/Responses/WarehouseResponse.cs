namespace CarService.ApplicationService.Contracts.Responses
{
    public record WarehouseResponse
        (
            Guid Id,
            string Title,
            string Address,
            string City
        );
}
