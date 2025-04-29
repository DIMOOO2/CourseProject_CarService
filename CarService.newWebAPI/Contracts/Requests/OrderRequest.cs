namespace CarService.newWebAPI.Contracts.Requests
{
    public record OrderRequest
    (
        DateTime orderDate, bool orderStatus, Guid clientId
    );
}
