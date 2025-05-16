namespace CarService.ApplicationService.Contracts.Requests
{
    public record DeliveryReportRequest(DateTime createDate, Guid warehouseCreatorId, byte[] fileReport);
}
