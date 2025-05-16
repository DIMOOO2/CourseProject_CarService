namespace CarService.ApplicationService.Contracts.Requests
{
    public record OrderRequest
    (
        DateTime orderDate, bool orderStatus, Guid clientId, Guid warehouseContractorId
    );
}
