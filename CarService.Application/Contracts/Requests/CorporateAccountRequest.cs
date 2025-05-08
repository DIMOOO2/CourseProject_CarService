namespace CarService.ApplicationService.Contracts.Requests
{
    public record CorporateAccountRequest
        (
            string logIn, string password, Guid warehouseId
        );
}
