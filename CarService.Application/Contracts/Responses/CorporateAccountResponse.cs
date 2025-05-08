namespace CarService.ApplicationService.Contracts.Responses
{
    public record CorporateAccountResponse(Guid accountId, string logIn, string password, Guid warehouseId);
}
